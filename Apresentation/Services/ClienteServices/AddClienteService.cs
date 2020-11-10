using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.ClienteServices
{
    public class AddClienteService : ClienteServiceBase, ISendService
    {
        public AddClienteService(IClienteService contaService, InjectorServiceBaseApresentation injector) 
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await ClienteService.AddAsync(Injector.Mapper.Map<Cliente>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
