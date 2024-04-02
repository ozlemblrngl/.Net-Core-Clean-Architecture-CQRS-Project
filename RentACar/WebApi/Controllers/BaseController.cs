using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        //sadece burayı injecte edenler kullanabilsin diye protected yazıyoruz

        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        // set edilmişi nasıl anlarız iki adet soru işaretinden, yani set edilmişse (elimizde mediator varsa) onu döndürür
        // yoksa yani null sa git ioc ortamında injectionlara bak bulduğun noktada onu set et demiş oluyoruz. 
        // buradaki kodla her controllerda gidip IMediator u sürekli injecte etmekten kurtuluyoruz.
        // tabiki bu class ı ilgili controllerda kalıtım almamız lazım.
    }
}
