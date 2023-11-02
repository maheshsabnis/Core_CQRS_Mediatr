using Core_CQRS_Mediatr.Models;
using MediatR;

namespace Core_CQRS_Mediatr.Queries
{
    public class GetProductInfoQuery : IRequest<ResponseRecords<ProductInfo>>
    {
    }
}
