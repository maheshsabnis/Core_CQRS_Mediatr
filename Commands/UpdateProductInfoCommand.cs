using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Commands
{
    public class UpdateProductInfoCommand : IRequest<ResponseObject<ProductInfo>>
    {
        public ProductInfo productInfo { get; set; }

        public UpdateProductInfoCommand(ProductInfo product)
        {
            productInfo = product;
        }
    }
}
