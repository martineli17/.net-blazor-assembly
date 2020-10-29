using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.CursoServices
{
    public class UpdateCursoService : BaseCursoService, ISendService
    {
        public UpdateCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector) 
            : base(cursoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            await CursoService.UpdateAsync(Injector.Mapper.Map<Curso>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
