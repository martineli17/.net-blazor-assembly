using Apresentation.Services.Base;
using Dominio.Interfaces.Service;

namespace Apresentation.Services.AlunoDisciplinaServices
{
    public class AlunoDisiciplinaServiceBase : ServiceBase
    {
        protected readonly IAlunoDisciplinaService AlunoDisciplina;
        public AlunoDisiciplinaServiceBase(InjectorServiceBaseApresentation injector, IAlunoDisciplinaService alunoDisciplina) 
            : base(injector)
        {
            AlunoDisciplina = alunoDisciplina;
        }
    }
}
