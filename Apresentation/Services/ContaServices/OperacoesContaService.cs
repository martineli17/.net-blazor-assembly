using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.ContaViewModel;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.ContaServices
{
    public class OperacoesContaService : ContaServiceBase, ISendService
    {
        public OperacoesContaService(IContaService contaService, InjectorServiceBaseApresentation injector)
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var modelCast = (ContaOperacoesViewModel)model;
            await ContaService.RealizarOperacao(modelCast.Operacao, modelCast.IdConta, modelCast.Valor, modelCast.IdContaDestino);
            return Injector.Notificador.IsValido();
        }
    }
}
