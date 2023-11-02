using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Queries;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class GetProductInfoByIdHandler : IRequestHandler<GetProductInfoByIdQuery, ResponseRecord<ProductInfo>>
    {

        IDataAccessService<ProductInfo, string> ProductInfoService;

        public GetProductInfoByIdHandler(IDataAccessService<ProductInfo, string> productInfoService)
        {
            ProductInfoService = productInfoService;
        }

        public async Task<ResponseRecord<ProductInfo>> Handle(GetProductInfoByIdQuery request, CancellationToken cancellationToken)
        {
            return await ProductInfoService.GetByIdAsync(request.Id);
        }
    }
}
