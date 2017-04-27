using System;

namespace DagelijkseInname.Model
{
    public class DagboekEntry
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public decimal GeconsumeerdInGram { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal TotaalAanEiwittenGeconsumeerdInGram { get; set; }
        public decimal TotaalAanVetGeconsumeerdInGram { get; set; }
        public decimal TotaalAanKoolhydratenGeconsumeerdInGram { get; set; }
        public decimal TotaalAanKiloCalorieen { get; set; }
    }
}
