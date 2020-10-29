using Apresentation.Services.Base;
using Dominio.Interfaces.Service;

namespace Apresentation.Services.CursoServices
{
    public class BaseCursoService : ServiceBase
    {
        protected readonly ICursoService CursoService;
        public BaseCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector)
            : base(injector)
        {
            CursoService = cursoService;
        }
    }
}
