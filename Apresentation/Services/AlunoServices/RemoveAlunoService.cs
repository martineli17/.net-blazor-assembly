using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoViewModel;
using Dominio.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoServices
{
    public class RemoveAlunoService : AlunoServiceBase, ISendService
    {
        public RemoveAlunoService(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(alunoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await AlunoService.RemoveAsync(model == null ? Guid.Empty : ((BaseRemoveViewModel)model).Id);
            return Injector.Notificador.IsValido();
        }
    }
}
