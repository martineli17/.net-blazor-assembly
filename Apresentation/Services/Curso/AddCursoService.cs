using Apresentation.ViewModels;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.Curso
{
    public class AddCursoService
    {
        private readonly ICursoService _cursoService;

        public AddCursoService(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public async Task AddCurso(CursoAddViewModel model)
        {

        }
    }
}
