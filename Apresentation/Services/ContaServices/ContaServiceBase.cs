using Apresentation.Services.Base;
using Dominio.Interfaces.Service;

namespace Apresentation.Services.ContaServices
{
    public class ContaServiceBase : ServiceBase
    {
        protected readonly IContaService ContaService;
        public ContaServiceBase(IContaService contaService, InjectorServiceBaseApresentation injector)
            : base(injector)
        {
            ContaService = contaService;
        }
    }
}
