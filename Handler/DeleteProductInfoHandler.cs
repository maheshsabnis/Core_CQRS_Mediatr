using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Services;
using MediatR;

namespace Core_CQRS_Mediatr.Handler
{
    public class DeleteProductInfoHandler : IRequestHandler<DeleteProductInfoCommand, ResponseObject<ProductInfo>>
    {

        IDataAccessService<ProductInfo, string> _ProductInfoService;

        public DeleteProductInfoHandler(IDataAccessService<ProductInfo, string> ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;
        }

        public async Task<ResponseObject<ProductInfo>> Handle(DeleteProductInfoCommand request, CancellationToken cancellationToken)
        {
            return await _ProductInfoService.DeleteAsync(request.Id);
        }
    }
}
