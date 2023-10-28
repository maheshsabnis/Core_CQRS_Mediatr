using System;
using System.Collections.Generic;

namespace Core_CQRS_Mediatr.Models;

public partial class ProductInfo
{
    public int ProductRecordId { get; set; }

    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal BasePrice { get; set; }

    public decimal? Tax { get; set; }

    public decimal? TotalPrice { get; set; }
}
