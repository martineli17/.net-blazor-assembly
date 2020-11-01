using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoDisciplinaServices
{
    public class RemoveAlunoDisciplinaServices : AlunoDisiciplinaServiceBase, ISendService
    {
        public RemoveAlunoDisciplinaServices(InjectorServiceBaseApresentation injector, IAlunoDisciplinaService alunoDisciplina)
            : base(injector, alunoDisciplina)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var modelCast = (BaseRemoveViewModel)model;
            if (!ValidarId(modelCast.Id, "Necessário selecionar o registro.")) return false;
            await AlunoDisciplina.RemoveAsync(modelCast.Id);
            return Injector.Notificador.IsValido();
        }
    }
}
