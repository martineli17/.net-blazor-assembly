using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Service.Validators;

namespace Service.Services
{
    public class DisciplinaService : BaseService<Disciplina>
    {
        public DisciplinaService(IDisciplinaRepositorio repositorio, IValidacaoFluent validation) : base(repositorio, validation)
        {

        }
    }
}
