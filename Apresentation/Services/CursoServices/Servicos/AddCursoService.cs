using Apresentation.Services.Base;
using Apresentation.Services.CursoServices.Interface;
using Apresentation.ViewModels;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.CursoServices.Servicos
{
    public class AddCursoService : ServiceBase, IAddCursoService
    {
        private readonly ICursoService _cursoService;
        public AddCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector) : base(injector)
        {
            _cursoService = cursoService;
        }
        public async Task<bool> SendService(IBaseViewModel model)
        {
            await _cursoService.AddAsync(Injector.Mapper.Map<Curso>(model));
            return true;
        }
    }
}
