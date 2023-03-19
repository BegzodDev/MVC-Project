namespace MVC_Producr.Models.Domain.Entities
{
    public class TotalPriceWithVAT
    {
        public int Id { get; set; }
        public int TotalPriceWithVat { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
