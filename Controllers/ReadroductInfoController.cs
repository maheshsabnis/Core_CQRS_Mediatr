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
    public class ReadroductInfoController : ControllerBase
    {
        IMediator mediator;

        public ReadroductInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetProductInfoQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await mediator.Send(new GetProductInfoByIdQuery() { Id = id});
            return Ok(response);
        }

        
    }
}
