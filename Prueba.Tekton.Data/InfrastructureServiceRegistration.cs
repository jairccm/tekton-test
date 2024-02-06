using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prueba.Tekton.Application.Contratcs.Cache;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Infraestructure.Cache;
using Prueba.Tekton.Infraestructure.Persistence;
using Prueba.Tekton.Infraestructure.Repositories;

namespace Prueba.Tekton.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PruebaTektonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStatusCache, ProductStatusCache>();

            return services;
        }
    }
}
