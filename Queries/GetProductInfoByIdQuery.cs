using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Queries
{
    public class GetProductInfoByIdQuery: IRequest<ResponseObject<ProductInfo>>
    {
        public string? Id { get; set; }
    }
}
