using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.ContaServices
{
    public class AddContaService : ContaServiceBase, ISendService
    {
        public AddContaService(IContaService contaService, InjectorServiceBaseApresentation injector) 
            : base(contaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await ContaService.AddAsync(Injector.Mapper.Map<Conta>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
