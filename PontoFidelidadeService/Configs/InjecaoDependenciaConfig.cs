using Microsoft.Extensions.DependencyInjection;
using PontoFidelidade.Domain;
using PontoFidelidade.Persistence;

namespace PontoFidelidade.WebApi
{
    public static class InjecaoDependenciaConfig
    {
        public static void ConfigureDI(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioEntityFramework<>));

        }
    }
}
