using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Interfaces.Service;
using System;
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
            await DisciplinaService.RemoveAsync(model == null ? Guid.Empty : ((BaseRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
