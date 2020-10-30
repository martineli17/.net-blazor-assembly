using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoViewModel;
using Crosscuting.Extensions;
using Dominio.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoServices
{
    public class GetAlunoService : BaseServiceAluno, ISendService
    {
        public GetAlunoService(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(alunoService, injector)
        {
        }
        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await AlunoService.GetAsync();
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<AlunoGetViewModel>>(result) : null;
        }
    }
}
