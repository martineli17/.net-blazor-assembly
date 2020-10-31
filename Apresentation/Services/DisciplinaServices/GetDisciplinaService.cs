using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.DisciplinaViewModel;
using Crosscuting.Extensions;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class GetDisciplinaService : DisciplinaServiceBase, ISendService
    {
        public GetDisciplinaService(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector)
           : base(disciplinaService, injector)
        {
        }
        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await DisciplinaService.GetAsync();
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<DisciplinaGetViewModel>>(result) : null;
        }
    }
}
