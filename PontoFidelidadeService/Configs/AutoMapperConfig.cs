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
                
                map.CreateMap<Loja, LojaConsultaDto>();                

                map.CreateMap<Cliente, ClienteConsultaDto>()
                    .ForMember(c => c.SaldoAtualDinheiro, c => c.MapFrom(d => d.SaldoAtual ?? 0))
                    .ForMember(c => c.SaldoAtualPontos, c => c.MapFrom(d => d.PontosAtual ?? 0));

                
            }, 
            Assembly.GetCallingAssembly());
        }
    }
}
