using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Queries;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class GetProductInfoByIdHandler : IRequestHandler<GetProductInfoByIdQuery, ResponseObject<ProductInfo>>
    {

        IDataAccessService<ProductInfo, string> _ProductInfoService;

        public GetProductInfoByIdHandler(IDataAccessService<ProductInfo, string> ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;
        }

        public async Task<ResponseObject<ProductInfo>> Handle(GetProductInfoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ProductInfoService.GetByIdAsync(request.Id);
        }
    }
}
