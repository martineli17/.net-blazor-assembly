using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Service.Services.ServicesBase;

namespace Service.Services
{
    public class AlunoDisciplinaService : BaseService<AlunoDisciplina>
    {
        public AlunoDisciplinaService(IBaseRepositorio<AlunoDisciplina> repositorio, InjectorServiceBase injector) 
            : base(repositorio, injector)
        {

        }
    }
}
