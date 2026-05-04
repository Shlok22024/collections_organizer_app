using CollectifyWebApp.Models;

namespace CollectifyWebApp.ViewModels;

public class DashboardViewModel
{
    // Headline stats
    public int TotalItems { get; set; }
    public int TotalCollections { get; set; }
    public decimal TotalEstimatedValue { get; set; }
    public decimal TotalPurchasePrice { get; set; }
    public decimal TotalGainLoss { get; set; }
    public decimal GainLossPercent { get; set; }

    // Top 5 most valuable items (full Item with Collection navigation populated)
    public List<Item> TopValuableItems { get; set; } = new();

    // Category breakdown — for Dylan's chart and for the inline percentage bars
    public List<CategoryBreakdown> CategoryBreakdown { get; set; } = new();
}

public class CategoryBreakdown
{
    public string Category { get; set; } = string.Empty;
    public int ItemCount { get; set; }
    public decimal TotalValue { get; set; }
    public decimal Percentage { get; set; }  // percent of total portfolio value (0-100, rounded to 1 decimal)
}
