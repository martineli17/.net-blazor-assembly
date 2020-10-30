using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoViewModel;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoServices
{
    public class AddAlunoService : AlunoServiceBase, ISendService
    {
        public AddAlunoService(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(alunoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            if (ValidarId(((AlunoAddViewModel)model).IdCurso, "Necessário selecionar um curso"))
                return false;
            await AlunoService.AddAsync(Injector.Mapper.Map<Aluno>(model));
            return Injector.Notificador.IsValido();
        }
    }
}
