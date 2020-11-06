using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.ClienteViewModel;
using Crosscuting.Extensions;
using Dominio.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Apresentation.Services.ClienteServices
{
    public class GetClienteService : ClienteServiceBase, ISendService
    {
        public GetClienteService(IClienteService alunoService, InjectorServiceBaseApresentation injector) : base(alunoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await ClienteService.GetAsync();
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<ClienteGetViewModel>>(result) : null;
        }
    }
}
