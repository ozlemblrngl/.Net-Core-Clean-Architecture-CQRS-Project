using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // burada mediatr a diyoruz ki git mevcut bütün assemblyi tara commandleri queryleri bul, onların handlerlarını bul,
                // onları birbirleriyle eşleştir listele koy, ben sana ne zaman command send yaparsam gir onun handlerını çalıştır. 
            });

            return services;
        }
    }
}
