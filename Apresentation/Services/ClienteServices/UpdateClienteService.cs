using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.ClienteViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.ClienteServices
{
    public class UpdateClienteService : ClienteServiceBase, ISendService
    {
        public UpdateClienteService(IClienteService contaService, InjectorServiceBaseApresentation injector) 
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            if (!ValidarId(((ClienteGetViewModel)model).Id, "Necessário selecionar o cliente."))
                return false;
            await ClienteService.UpdateAsync(Injector.Mapper.Map<Cliente>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
