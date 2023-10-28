using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class UpdateProductInfoHandler : IRequestHandler<UpdateProductInfoCommand, ResponseObject<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> _ProductInfoService;

        public UpdateProductInfoHandler(IDataAccessService<ProductInfo, string> ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;
        }

        public async Task<ResponseObject<ProductInfo>> Handle(UpdateProductInfoCommand request, CancellationToken cancellationToken)
        {
            return await _ProductInfoService.UpdateAsync(request.productInfo.ProductId, request.productInfo);
        }
    }
}
