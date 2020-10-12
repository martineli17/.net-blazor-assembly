using Crosscuting.Notificacao;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using FluentValidation;
using Service.Validators;

namespace Service.Services
{
    public class AlunoService : BaseService<Aluno>
    {
        public AlunoService(IAlunoRepositorio repositorio, IValidacaoFluent validation) : base(repositorio, validation)
        {

        }
    }
}
