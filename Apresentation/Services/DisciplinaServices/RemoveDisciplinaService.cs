using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.DisciplinaViewModel;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class RemoveDisciplinaService : DisciplinaServiceBase, ISendService
    {
        public RemoveDisciplinaService(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector)
           : base(disciplinaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await DisciplinaService.RemoveAsync(model == null ? Guid.Empty : ((DisciplinaRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
