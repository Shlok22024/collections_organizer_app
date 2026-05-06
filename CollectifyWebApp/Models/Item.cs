namespace CollectifyWebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? EstimatedValue { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string? Set { get; set; }
        public string? Rarity { get; set; }
    }
}