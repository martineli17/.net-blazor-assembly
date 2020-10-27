using Apresentation.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Apresentation.Configuracoes
{
    public static class MapperConfiguracao
    {
        public static IServiceCollection AddMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(CursoMapper).Assembly);
            return service;
        }
    }
}
