
using AutoMapper;
using Core_CQRS_Mediatr.Commands;
using Core_CQRS_Mediatr.Models;
using Core_CQRS_Mediatr.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core_CQRS_Mediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteProductInfoController : ControllerBase
    {
        IMediator Mediator;
        IMapper Mapper;

        public WriteProductInfoController(IMapper mapper, IMediator mediator)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductInfoViewModel product)
        {
            if (!ModelState.IsValid)
                throw new Exception(GetModelErrorMessagesHelper(ModelState));
            ProductInfo prd = Mapper.Map<ProductInfo>(product);
            var response = await Mediator.Send(new RegisterProductInfoCommand(prd));
            if(!response.IsSuccess)
                throw new Exception($"The create request faild");
            response.StatusCode = 200;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProductInfoViewModel product)
        {
         
            if (String.IsNullOrEmpty(id))
                throw new Exception($"The Id={id} value is invalid");
            if (!ModelState.IsValid)
                throw new Exception(GetModelErrorMessagesHelper(ModelState));
            if (!id.Equals(product.ProductId))
                throw new Exception($"The update request cannot be processed because the provided data is mismatched");
            ProductInfo prd = Mapper.Map<ProductInfo>(product);
            var response = await Mediator.Send(new UpdateProductInfoCommand(prd));
            if (!response.IsSuccess)
                throw new Exception($"The update request faild");
            response.StatusCode = 200;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(String.IsNullOrEmpty(id))
                throw new Exception($"The Id={id} value is invalid");
            var response = await Mediator.Send(new DeleteProductInfoCommand(id));
            if (!response.IsSuccess)
                throw new Exception($"The delete request faild for Id= {id}");
            response.StatusCode = 200;
            return Ok(response);
        }


        private string GetModelErrorMessagesHelper(ModelStateDictionary errors)
        {
            string messages = "";
            foreach (var item in errors)
            {
                for (int j = 0; j < item.Value.Errors.Count; j++)
                {
                    messages += $"{item.Key} \t {item.Value.Errors[j].ErrorMessage} \n";
                }
            }
            return messages;
        }
    }
}
