using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Commands
{
    public class UpdateProductInfoCommand : IRequest<ResponseRecord<ProductInfo>>
    {
        public ProductInfo ProductInfo { get; set; }

        public UpdateProductInfoCommand(ProductInfo product)
        {
            ProductInfo = product;
        }
    }
}
