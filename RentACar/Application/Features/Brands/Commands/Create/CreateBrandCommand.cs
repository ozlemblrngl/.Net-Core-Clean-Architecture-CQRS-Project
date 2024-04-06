using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


// peki mediator ne yapıyor, burada IRequest var burada bir command geldiğinde benim bunu handle etmem lazım diyor.
// command ve handler birlikte olmadan diğeri bir işe yaramaz.
// bir commandi sadece bir handler a yazabiliriz o nedenle kardeş gibi düşünebiliriz.
// aşağıdaki classı yandaki klasörde ayrı bir class olarak da açabiliriz ama sonuçta command ve handler birbirinden ayrılmaz 
// olduğu için burada yazmakta sakınca olmamakta. 

// aşağıdaki bir handler ama eğer interface ini yazmazsak handler olduğunu bilemez.
// kısaca sana bir CreateBrandCommand gelirse aşağıdakinin içini çalıştır diyoruz.
// aşağıdaki interface implementasyon yapmamızı bekliyor.

namespace Application.Features.Brands.Commands.Create
{

    public class CreateBrandCommand : IRequest<CreatedBrandResponse> // bu bir request nesnesidir ve işin sonunda bir CreatedBrandResponse döndürmeli.
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }
            public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request); // maple _mapperı ve requesti brande çevir.
                brand.Id = Guid.NewGuid();

                await _brandRepository.AddAsync(brand);

                CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
                return createdBrandResponse;
            }
        }
    }
}
