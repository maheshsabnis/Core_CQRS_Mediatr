using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Commands
{
    public class RegisterProductInfoCommand : IRequest<ResponseObject<ProductInfo>>
    {
        public ProductInfo productInfo { get; set; }
        public RegisterProductInfoCommand(ProductInfo product)
        {
            productInfo = product;
        }
    }
}
