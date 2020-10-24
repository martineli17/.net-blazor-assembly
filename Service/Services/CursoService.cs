using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Service.Services.ServicesBase;

namespace Service.Services
{
    public class CursoService : BaseService<Curso>
    {
        public CursoService(ICursoRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {
                
        }
    }
}
