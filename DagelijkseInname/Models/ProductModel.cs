using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DagelijkseInname.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "Het veld Naam is verplicht.")]
        [StringLength(50, ErrorMessage = "Het veld {0} kan niet meer dan {1} tekens bevatten.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Het veld Vet Per Gram is verplicht.")]
        [DisplayName("Vet per gram")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public decimal HoeveelheidVetPerGram { get; set; }

        [Required(ErrorMessage = "Het veld Eiwitten Per Gram is verplicht.")]
        [DisplayName("Eiwitten per gram")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public decimal HoeveelheidEiwitPerGram { get; set; }

        [Required(ErrorMessage = "Het veld Koolhydraten Per Gram is verplicht.")]
        [DisplayName("Koolhydraten per gram")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public decimal HoeveelheidKoolhydratenPerGram { get; set; }

        [Required(ErrorMessage = "Het veld Kcal Per Gram is verplicht.")]
        [DisplayName("Kcal per gram")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public decimal HoeveelheidKiloCalorieenPerGram { get; set; }
    }
}