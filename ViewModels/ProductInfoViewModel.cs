using System.ComponentModel.DataAnnotations;

namespace Core_CQRS_Mediatr.ViewModels
{
    /// <summary>
    /// Data Validation
    /// </summary>
    public class ProductInfoViewModel
    {
        [Display(Name ="Product Id")]
        [Required(ErrorMessage = "Product Id is required.")]
        public string ProductId { get; set; } = null!;
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; } = null!;
        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; } = null!;
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;
        [Display(Name = "Base Price")]
        [Required(ErrorMessage = "Base Price is required.")]
        public decimal BasePrice { get; set; }
    }
}
