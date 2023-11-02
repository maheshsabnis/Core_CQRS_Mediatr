using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_CQRS_Mediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadProductInfoController : ControllerBase
    {
        IMediator mediator;

        public ReadProductInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetProductInfoQuery());
            if (!response.IsSuccess)
                throw new Exception($"Error occurred while reading data");
            response.StatusCode = 200;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await mediator.Send(new GetProductInfoByIdQuery() { Id = id});
            if (!response.IsSuccess)
                throw new Exception($"Error occurred while reading data base don Id= {id}");
            response.StatusCode = 200;
            return Ok(response);
        }

        
    }
}
