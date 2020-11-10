using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.ContaViewModel;
using Crosscuting.Extensions;
using Dominio.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Services.ContaServices
{
    public class GetContaService : ContaServiceBase, ISendService
    {
        public GetContaService(IContaService contaService, InjectorServiceBaseApresentation injector)
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await ContaService.GetAsync();
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<ContaGetViewModel>>(result) : null;
        }
    }
}
