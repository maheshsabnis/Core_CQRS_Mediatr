using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Queries;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class GetProductInfoListHandler : IRequestHandler<GetProductInfoQuery, ResponseObject<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> _ProductInfoService;

        public GetProductInfoListHandler(IDataAccessService<ProductInfo, string> ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;
        }

        public async  Task<ResponseObject<ProductInfo>> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            return await _ProductInfoService.GetAsync();
        }
    }
}
