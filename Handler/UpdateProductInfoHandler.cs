using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class UpdateProductInfoHandler : IRequestHandler<UpdateProductInfoCommand, ResponseRecord<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> ProductInfoService;

        public UpdateProductInfoHandler(IDataAccessService<ProductInfo, string> productInfoService)
        {
            ProductInfoService = productInfoService;
        }

        public async Task<ResponseRecord<ProductInfo>> Handle(UpdateProductInfoCommand request, CancellationToken cancellationToken)
        {
            return await ProductInfoService.UpdateAsync(request.ProductInfo.ProductId, request.ProductInfo);
        }
    }
}
