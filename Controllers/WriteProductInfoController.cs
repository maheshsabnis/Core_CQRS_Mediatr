
using AutoMapper;
using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_CQRS_Mediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteProductInfoController : ControllerBase
    {
        IMediator mediator;
        IMapper mapper;

        public WriteProductInfoController(IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductInfoViewModel product)
        {
            ProductInfo prd = mapper.Map<ProductInfo>(product);
            var response = await mediator.Send(new RegisterProductInfoCommand(prd));
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProductInfoViewModel product)
        {
            ProductInfo prd = mapper.Map<ProductInfo>(product);
            var response = await mediator.Send(new UpdateProductInfoCommand(prd));
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await mediator.Send(new DeleteProductInfoCommand(id));
            return Ok(response);
        }
    }
}
