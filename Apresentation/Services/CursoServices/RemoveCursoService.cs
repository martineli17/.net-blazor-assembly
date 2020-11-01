using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.CursoViewModel;
using Dominio.Interfaces.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.CursoServices
{
    public class RemoveCursoService : BaseCursoService, ISendService
    {
        public RemoveCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector) 
            : base(cursoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await CursoService.RemoveAsync(model == null ? Guid.Empty : ((BaseRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
