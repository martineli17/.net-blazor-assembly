using Apresentation.Services.Base;
using Dominio.Interfaces.Service;

namespace Apresentation.Services.AlunoServices
{
    public class BaseServiceAluno : ServiceBase
    {
        protected readonly IAlunoService AlunoService;
        public BaseServiceAluno(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(injector)
        {
            AlunoService = alunoService;
        }
    }
}
