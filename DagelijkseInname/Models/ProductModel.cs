using System.ComponentModel;

namespace DagelijkseInname.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Naam { get; set; }
        [DisplayName("Vet per gram")]
        public decimal HoeveelheidVetPerGram { get; set; }
        [DisplayName("Eiwitten per gram")]
        public decimal HoeveelheidEiwitPerGram { get; set; }
        [DisplayName("Koolhydraten per gram")]
        public decimal HoeveelheidKoolhydratenPerGram { get; set; }
        [DisplayName("Kcal per gram")]
        public decimal HoeveelheidKiloCalorieenPerGram { get; set; }
    }
}