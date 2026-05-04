using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectifyWebApp.ViewModels;

public class ItemFormViewModel
{
    public int ItemId { get; set; }

    [Required]
    [StringLength(200)]
    [Display(Name = "Item Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a collection.")]
    [Display(Name = "Collection")]
    public int CollectionId { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Purchase price cannot be negative.")]
    [DataType(DataType.Currency)]
    [Display(Name = "Purchase Price")]
    public decimal PurchasePrice { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Estimated value cannot be negative.")]
    [DataType(DataType.Currency)]
    [Display(Name = "Estimated Value")]
    public decimal EstimatedValue { get; set; }

    [StringLength(500)]
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [StringLength(150)]
    public string? Source { get; set; }

    // Populated by the controller for the dropdown
    public IEnumerable<SelectListItem>? Collections { get; set; }
}
