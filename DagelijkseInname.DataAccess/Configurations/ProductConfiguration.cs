using DagelijkseInname.Model;
using System.Data.Entity.ModelConfiguration;

namespace DagelijkseInname.DataAccess.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.HoeveelheidEiwitPerGram).HasPrecision(18, 4);
            Property(p => p.HoeveelheidKoolhydratenPerGram).HasPrecision(18, 4);
            Property(p => p.HoeveelheidVetPerGram).HasPrecision(18, 4);
        }
    }
}
