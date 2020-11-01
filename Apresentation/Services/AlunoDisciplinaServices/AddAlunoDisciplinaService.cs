using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoDisciplinaViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoDisciplinaServices
{
    public class AddAlunoDisciplinaService : AlunoDisiciplinaServiceBase, ISendService
    {
        public AddAlunoDisciplinaService(InjectorServiceBaseApresentation injector, IAlunoDisciplinaService alunoDisciplina)
            : base(injector, alunoDisciplina)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var modelCast = (AlunoDisciplinaAddViewModel)model;
            if (!ValidarId(modelCast.IdAluno, "Necessário selecionar um aluno.") ||
                !ValidarId(modelCast.IdDisciplina, "Necessário selecionar uma disciplina.")) return false;
            await AlunoDisciplina.AddAsync(Injector.Mapper.Map<AlunoDisciplina>(modelCast));
            return Injector.Notificador.IsValido();
        }
    }
}
