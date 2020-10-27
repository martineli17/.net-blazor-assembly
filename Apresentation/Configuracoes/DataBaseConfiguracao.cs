using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;

namespace Apresentation.Configuracoes
{
    public static class DataBaseConfiguracao
    {
        public static IServiceCollection AddDataBaseInMemory(this IServiceCollection service)
        {
            service.AddDbContext<Context>(options => options.UseInMemoryDatabase("POO")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return service;
        }
    }
}
