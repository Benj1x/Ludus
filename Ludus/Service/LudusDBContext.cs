using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Ludus_web.Models;

namespace Ludus.Service
{
    public class LudusDBContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public LudusDBContext()
        {
            Database.SetInitializer<LudusDBContext>(new CreateDatabaseIfNotExists<LudusDBContext>());
            Database.SetInitializer<LudusDBContext>(new DropCreateDatabaseIfModelChanges<LudusDBContext>());
        }
    }
}
