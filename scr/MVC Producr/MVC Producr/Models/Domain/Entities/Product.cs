namespace MVC_Producr.Models.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? Quantity { get; set; }
        public double? Price { get; set; }

    }
}
