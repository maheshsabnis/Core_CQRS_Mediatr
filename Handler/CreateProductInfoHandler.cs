using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class CreateProductInfoHandler : IRequestHandler<RegisterProductInfoCommand, ResponseObject<ProductInfo>>
    {
        IDataAccessService<ProductInfo,string> _ProductInfoService;

        public CreateProductInfoHandler(IDataAccessService<ProductInfo, string> ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;  
        }


        public async Task<ResponseObject<ProductInfo>> Handle(RegisterProductInfoCommand request, CancellationToken cancellationToken)
        {
            
            return await _ProductInfoService.CreateAsync(request.productInfo);
        }
    }
}
