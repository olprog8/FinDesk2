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

            services.AddTransient<FinDeskDBInitializer>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSingleton<IIssuesData, InMemoryIssuesData>();

            services.AddSingleton<ICategoryData, InMemoryCategoryData>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
