using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Commands
{
    public class RegisterProductInfoCommand : IRequest<ResponseRecord<ProductInfo>>
    {
        public ProductInfo ProductInfo { get; set; }
        public RegisterProductInfoCommand(ProductInfo product)
        {
            ProductInfo = product;
        }
    }
}
