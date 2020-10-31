using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.DisciplinaViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class AddDisciplinaService : DisciplinaServiceBase, ISendService
    {
        public AddDisciplinaService(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector)
            : base(disciplinaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            if (ValidarId(((DisciplinaAddViewModel)model).IdCurso, "Necessário selecionar um curso"))
                return false;
            await DisciplinaService.AddAsync(Injector.Mapper.Map<Disciplina>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
