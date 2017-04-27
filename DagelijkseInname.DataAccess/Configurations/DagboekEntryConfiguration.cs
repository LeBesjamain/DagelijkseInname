using DagelijkseInname.Model;
using System.Data.Entity.ModelConfiguration;

namespace DagelijkseInname.DataAccess.Configurations
{
    public class DagboekEntryConfiguration : EntityTypeConfiguration<DagboekEntry>
    {
        public DagboekEntryConfiguration()
        {
            Property(d => d.GeconsumeerdInGram).HasPrecision(18, 4);
            Ignore(p => p.TotaalAanVetGeconsumeerdInGram);
            Ignore(p => p.TotaalAanKoolhydratenGeconsumeerdInGram);
            Ignore(p => p.TotaalAanEiwittenGeconsumeerdInGram);
            Ignore(p => p.TotaalAanKiloCalorieen);
        }
    }
}
