using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Apresentation.Services.ContaServices
{
    public class RemoveContaService : ContaServiceBase, ISendService
    {
        public RemoveContaService(IContaService contaService, InjectorServiceBaseApresentation injector)
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await ContaService.RemoveAsync(model == null ? Guid.Empty : ((BaseRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
