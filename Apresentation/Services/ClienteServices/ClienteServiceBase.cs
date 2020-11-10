using Apresentation.Services.Base;
using Dominio.Interfaces.Service;

namespace Apresentation.Services.ClienteServices
{
    public class ClienteServiceBase : ServiceBase
    {
        protected readonly IClienteService ClienteService;
        public ClienteServiceBase(IClienteService clienteService, InjectorServiceBaseApresentation injector)
            : base(injector)
        {
            ClienteService = clienteService;
        }
    }
}
