using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.CursoServices
{
    public class AddCursoService : BaseCursoService, ISendService
    {
        public AddCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector)
            : base(cursoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await CursoService.AddAsync(Injector.Mapper.Map<Curso>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
