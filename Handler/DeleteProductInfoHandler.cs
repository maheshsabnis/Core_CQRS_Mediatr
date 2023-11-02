using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class DeleteProductInfoHandler : IRequestHandler<DeleteProductInfoCommand, ResponseRecord<ProductInfo>>
    {

        IDataAccessService<ProductInfo, string> ProductInfoService;

        public DeleteProductInfoHandler(IDataAccessService<ProductInfo, string> productInfoService)
        {
            ProductInfoService = productInfoService;
        }

        public async Task<ResponseRecord<ProductInfo>> Handle(DeleteProductInfoCommand request, CancellationToken cancellationToken)
        {
            return await ProductInfoService.DeleteAsync(request.Id);
        }
    }
}
