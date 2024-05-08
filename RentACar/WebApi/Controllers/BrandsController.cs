using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
            return Ok(response);

            // basecontrollerdan kalıtım alıp injecte etmekten kurtulduk burada. 
            // Artık mediatorda da .Send metodu çalışır halde. 
            // burada mediator diyo ki bir tane command gönder.
            // normalde biz bu uygulamayı devreye aldığımızda mediator bütün sistemi tarıyor, command ve handler veya query ve handlerlarını sanki bir mapmiş gibi ekliyor lşstesine.
            // kısacası send dediğimizde gidip createBrandCommand'in ilgili classına gidiyor handlerına bakıyor ve onu çalıştırıyor ve bize bir response döndürüyor.
            // sonucu da CreatedBrandResponse response a setlemiş oluyoruz.
        }

        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);

        }
    }
}
