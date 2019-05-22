using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PontoFidelidade.WebApi
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(map =>
            {


            }, 
            Assembly.GetCallingAssembly());
        }
    }
}
