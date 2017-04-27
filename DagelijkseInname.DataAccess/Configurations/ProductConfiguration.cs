using DagelijkseInname.Model;
using System.Data.Entity.ModelConfiguration;

namespace DagelijkseInname.DataAccess.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Naam).HasMaxLength(50).IsRequired();
            Property(p => p.Foto).IsRequired();
            Property(p => p.HoeveelheidEiwitPerGram).HasPrecision(18, 4).IsRequired();
            Property(p => p.HoeveelheidKoolhydratenPerGram).HasPrecision(18, 4).IsRequired();
            Property(p => p.HoeveelheidVetPerGram).HasPrecision(18, 4).IsRequired();
            Property(p => p.HoeveelheidKiloCalorieenPerGram).HasPrecision(18, 4).IsRequired();
        }
    }
}
