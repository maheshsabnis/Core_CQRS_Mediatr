using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Queries;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class GetProductInfoListHandler : IRequestHandler<GetProductInfoQuery, ResponseRecords<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> ProductInfoService;

        public GetProductInfoListHandler(IDataAccessService<ProductInfo, string> productInfoService)
        {
            ProductInfoService = productInfoService;
        }

        public async  Task<ResponseRecords<ProductInfo>> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            return await ProductInfoService.GetAsync();
        }
    }
}
