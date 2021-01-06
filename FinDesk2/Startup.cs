using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using FinDesk2.Infrastructure.Interfaces;
using FinDesk2.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using FinDesk.DAL.Context;

using FinDesk2.Data;

using FinDesk2.Infrastructure.Services.InSQL;

using FinDesk.Domain.Identity;
using Microsoft.AspNetCore.Identity;

using System;


namespace FinDesk2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение к БД
            services.AddDbContext<FinDeskDB>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<FinDeskDB>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxABCD...1234567890";
                opt.User.RequireUniqueEmail = false;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "FinDesk";
                opt.Cookie.HttpOnly = true;
                //opt.Cookie.Expiration = TimeSpan.FromDays(10); - уже неподдерживается в 3.1
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);

                //L6 1.10 Identity Пути по которым система будет перенаправлять неавторизованных пользователей на контроллер Account, действие Login
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";

                opt.SlidingExpiration = true; //L6 ПШ Параметр который заставит систему автоматически подменять идентификатор сессии пользователя, как он авторизовался
            });

            services.AddTransient<FinDeskDBInitializer>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSingleton<IIssuesData, InMemoryIssuesData>();

            //services.AddSingleton<IBaseIssuesData, InMemoryBaseIssuesData>();
            services.AddScoped<IBaseIssuesData, SQLBaseIssuesData>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FinDeskDBInitializer db)
        {
            //Инициализируем БД
            db.Initialize();

            //Конвейер
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            //L6 1.14 добавили Identity промежуточное ПО
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            });

        }
    }
}
