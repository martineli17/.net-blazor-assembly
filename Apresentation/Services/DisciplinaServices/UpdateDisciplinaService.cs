using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.DisciplinaViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class UpdateDisciplinaService : DisciplinaServiceBase, ISendService
    {
        public UpdateDisciplinaService(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector)
            : base(disciplinaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            if (ValidarId(((DisciplinaGetViewModel)model).Curso.Id, "Necessário selecionar um curso"))
                return false;
            await DisciplinaService.UpdateAsync(Injector.Mapper.Map<Disciplina>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
