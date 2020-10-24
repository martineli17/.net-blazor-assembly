using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Service.Services.ServicesBase;

namespace Service.Services
{
    public class AlunoService : BaseService<Aluno>
    {
        public AlunoService(IAlunoRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {

        }
    }
}
