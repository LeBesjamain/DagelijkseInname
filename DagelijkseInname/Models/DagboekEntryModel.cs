using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DagelijkseInname.Models
{
    public class DagboekEntryModel
    {
        [DisplayName("Datum entry")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DatumDagboekentry { get; set; }

        [DisplayName("Vet (in gram)")]
        public decimal TotaalAanVetGeconsumeerdInGram { get; set; }

        [DisplayName("Koolhydraten (in gram)")]
        public decimal TotaalAanKoolhydratenGeconsumeerdInGram { get; set; }

        [DisplayName("Eiwit (in gram)")]
        public decimal TotaalAanEiwittenGeconsumeerdInGram { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Het veld Geconsumeerd (in gram) is verplicht.")]
        [DisplayName("Geconsumeerd (in gram)")]
        public decimal GeconsumeerdInGram { get; set; }

        [DisplayName("Totaal Kcal.")]
        public decimal TotaalAanCalorieenGeconsumeerd { get; set; }
    }
}