using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Apresentation.Services.ClienteServices
{
    public class RemoveClienteService : ClienteServiceBase, ISendService
    {
        public RemoveClienteService(IClienteService alunoService, InjectorServiceBaseApresentation injector)
            : base(alunoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await ClienteService.RemoveAsync(model == null ? Guid.Empty : ((BaseRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
