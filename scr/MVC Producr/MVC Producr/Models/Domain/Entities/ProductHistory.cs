namespace MVC_Producr.Models.Domain.Entities
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public DateTime WhenWasChanged { get; set; }
        public string? Discription { get; set; }

    }
}
