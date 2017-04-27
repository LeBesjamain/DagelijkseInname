namespace DagelijkseInname.Model
{
    public class Product
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Naam { get; set; }
        public decimal HoeveelheidVetPerGram { get; set; }
        public decimal HoeveelheidEiwitPerGram { get; set; }
        public decimal HoeveelheidKoolhydratenPerGram { get; set; }
        public decimal HoeveelheidKiloCalorieenPerGram { get; set; }
    }
}
