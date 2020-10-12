using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Service.Validators;

namespace Service.Services
{
    public class CursoService : BaseService<Curso>
    {
        public CursoService(ICursoRepositorio repositorio, IValidacaoFluent validation) : base(repositorio, validation)
        {
                
        }
    }
}
