using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.WebApi.Models;
using System.Reflection;

namespace PontoFidelidade.WebApi
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(map =>
            {
                map.CreateMap<UsuarioNovoDto, Usuario>();
                map.CreateMap<Usuario, UsuarioLoginDto>();
                map.CreateMap<Usuario, UsuarioNovoDto>();
            }, 
            Assembly.GetCallingAssembly());
        }
    }
}
