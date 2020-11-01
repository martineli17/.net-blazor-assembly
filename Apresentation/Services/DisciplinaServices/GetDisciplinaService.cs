using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.DisciplinaViewModel;
using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class GetDisciplinaService : DisciplinaServiceBase, ISendService
    {
        public GetDisciplinaService(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector)
           : base(disciplinaService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await DisciplinaService.GetAsync(model is null ? null : GetFiltro((DisciplinaFiltroViewModel)model));
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<DisciplinaGetViewModel>>(result) : null;
        }

        #region Metodos privados
        private Func<Disciplina, bool> GetFiltro(DisciplinaFiltroViewModel filtro) =>
            x => x.IdCurso == filtro.IdCurso;
        #endregion
    }
}
