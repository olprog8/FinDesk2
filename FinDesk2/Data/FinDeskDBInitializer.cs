using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinDesk.DAL.Context;

using Microsoft.EntityFrameworkCore;


namespace FinDesk2.Data
{
    public class FinDeskDBInitializer
    {
        private readonly FinDeskDB _db;

        public FinDeskDBInitializer(FinDeskDB db)
        {
            _db = db;
        }
        public void Initialize() => InitializeAsync().Wait();

        public async Task InitializeAsync() 
        {
            var db = _db.Database;

            //if(await db.EnsureCreatedAsync().ConfigureAwait(false))
            //{
            //    if (await db.EnsureCreatedAsync().ConfigureAwait(false))
            //        throw new InvalidOperationException("Не удалось создать БД");
            //}

            await db.MigrateAsync().ConfigureAwait(false);

            if (await _db.BaseIssues.AnyAsync()) return;


        }
    }
}
