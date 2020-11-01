using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoDisciplinaViewModel;
using Crosscuting.Extensions;
using Dominio.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoDisciplinaServices
{
    public class GetAlunoDisciplinaServices : AlunoDisiciplinaServiceBase, ISendService
    {
        public GetAlunoDisciplinaServices(IAlunoDisciplinaService alunoDisciplinaService, InjectorServiceBaseApresentation injector)
            : base(injector, alunoDisciplinaService)
        {
        }
        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await AlunoDisciplina.GetAsync();
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<AlunoDisciplinaGetViewModel>>(result) : null;
        }
    }
}
