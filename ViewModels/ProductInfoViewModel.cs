using System.ComponentModel.DataAnnotations;

namespace Core_CQRS_Mediatr.ViewModels
{
    public class ProductInfoViewModel
    {
        [Display(Name ="Product Id")]
        public string ProductId { get; set; } = null!;
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
        [Display(Name = "Base Price")]
        public decimal BasePrice { get; set; }
    }
}
