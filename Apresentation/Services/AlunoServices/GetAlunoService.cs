using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.AlunoViewModel;
using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.AlunoServices
{
    public class GetAlunoService : AlunoServiceBase, ISendService
    {
        public GetAlunoService(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(alunoService, injector)
        {
        }
        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await AlunoService.GetAsync(model is null ? null : GetFiltro((AlunoFiltroViewModel)model));
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<AlunoGetViewModel>>(result) : null;
        }

        #region Metodos privados
        private Func<Aluno, bool> GetFiltro(AlunoFiltroViewModel filtro) =>
            x => filtro == null || filtro.IdCurso == Guid.Empty || x.IdCurso == filtro.IdCurso;
        #endregion
    }
}
