using Microsoft.Extensions.DependencyInjection;
using PontoFidelidade.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
