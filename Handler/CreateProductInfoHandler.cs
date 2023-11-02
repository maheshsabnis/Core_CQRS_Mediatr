using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class CreateProductInfoHandler : IRequestHandler<RegisterProductInfoCommand, ResponseRecord<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> ProductInfoService;

        public CreateProductInfoHandler(IDataAccessService<ProductInfo, string> productInfoService)
        {
            this.ProductInfoService = productInfoService;  
        }


        public async Task<ResponseRecord<ProductInfo>> Handle(RegisterProductInfoCommand request, CancellationToken cancellationToken)
        {
            return await ProductInfoService.CreateAsync(request.ProductInfo);
        }
    }
}
