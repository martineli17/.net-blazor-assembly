using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoDisciplinaViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoDisciplinaServices
{
    public class UpdateAlunoDisciplinaService : AlunoDisiciplinaServiceBase, ISendService
    {
        public UpdateAlunoDisciplinaService(InjectorServiceBaseApresentation injector, IAlunoDisciplinaService alunoDisciplinaService)
        : base(injector, alunoDisciplinaService)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var modelCast = (AlunoDisciplinaGetViewModel)model;
            if (!ValidarId(modelCast.IdAluno, "Necessário selecionar um aluno.") ||
                !ValidarId(modelCast.IdDisciplina, "Necessário selecionar uma disciplina.")) return false;
            await AlunoDisciplina.AddAsync(Injector.Mapper.Map<AlunoDisciplina>(modelCast));
            return Injector.Notificador.IsValido();
        }
    }
}
