using DagelijkseInname.DataAccess.Configurations;
using DagelijkseInname.Model;
using System.Data.Entity;

namespace DagelijkseInname.DataAccess
{
    public class DagelijkseInnameContext : DbContext
    {
        public DagelijkseInnameContext() : base("Name=DagelijkseInnameContext")
        {
            //Database.SetInitializer<DagelijkseInnameContext>(new DropCreateDatabaseAlways<DagelijkseInnameContext>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<DagboekEntry> DagboekEntries { get; set; }
        public DbSet<Product> Producten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new DagboekEntryConfiguration());
        }
    }
}
