using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> // bu bir request nesnesidir ve işin sonunda bir CreatedBrandResponse döndürmeli.
    {
        public string Name { get; set; }

        // peki mediator ne yapıyor, burada IRequest var burada bir command geldiğinde benim bunu handle etmem lazım diyor.
        // command ve handler birlikte olmadan diğeri bir işe yaramaz.
        // bir commandi sadece bir handler a yazabiliriz o nedenle kardeş gibi düşünebiliriz.
        // aşağıdaki classı yandaki klasörde ayrı bir class olarak da açabiliriz ama sonuçta command ve handler birbirinden ayrılmaz 
        // olduğu için burada yazmakta sakınca olmamakta. 

        // aşağıdaki bir handler ama eğer interface ini yazmazsak handler olduğunu bilemez.
        // kısaca sana bir CreateBrandCommand gelirse aşağıdakinin içini çalıştır diyoruz.
        // aşağıdaki interface implementasyon yapmamızı bekliyor.
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
                createdBrandResponse.Name = request.Name;
                createdBrandResponse.Id = new Guid();
                return null;
            }
        }
    }
}
