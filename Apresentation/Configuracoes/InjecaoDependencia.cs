using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repositorio.Repositorios;
using Service.Services;

namespace Apresentation.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInjecaoDependencia(this IServiceCollection service)
        {
            service.TryAddScoped<ICursoRepositorio, CursoRepositorio>();
            service.TryAddScoped<ICursoRepositorio, CursoRepositorio>();
            service.TryAddScoped<ICursoRepositorio, CursoRepositorio>();
            service.TryAddScoped<ICursoRepositorio, CursoRepositorio>();

            service.TryAddScoped<ICursoService, CursoService>();
            service.TryAddScoped<ICursoService, CursoService>();
            service.TryAddScoped<ICursoService, CursoService>();
            service.TryAddScoped<ICursoService, CursoService>();
            return service;
        }
    }
}
