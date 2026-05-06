namespace CollectifyWebApp.Models
{
    public class PokemonResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Rarity { get; set; }
        public PokemonSet? Set { get; set; }
        public PokemonPricing? Pricing { get; set; }
    }

    public class PokemonSet
    {
        public string Name { get; set; }
    }

    public class PokemonPricing
    {
        public CardmarketPricing? Cardmarket { get; set; }
    }

    public class CardmarketPricing
    {
        public decimal Avg { get; set; }
        public decimal Trend { get; set; }
        public string Unit { get; set; }
    }
}