using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Teste_Partner.Models;

namespace Teste_Partner.Models
{
    public class MeuContext : DbContext
    {
        public MeuContext() : base("name=MeuContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeuContext, Teste_Partner.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MeuContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Patrimonio> Patrimonios { get; set; }
    }
}