using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Commands
{
    public class DeleteProductInfoCommand : IRequest<ResponseObject<ProductInfo>>
    {
        public string Id { get; set; }

        public DeleteProductInfoCommand(string id)
        {
            Id = id;
        }
    }
}
