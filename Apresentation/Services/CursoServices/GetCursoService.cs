using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Apresentation.ViewModels.CursoViewModel;
using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Services.CursoServices
{
    public class GetCursoService : BaseCursoService, ISendService
    {
        public GetCursoService(ICursoService cursoService, InjectorServiceBaseApresentation injector)
            : base(cursoService, injector)
        {
        }

        public async Task<object> SendService(IBaseViewModel model = null)
        {
            var result = await CursoService.GetAsync(model is null ? null : GetFuncaoFiltro((CursoFiltroViewModel)model));
            return result.HasValue() ? Injector.Mapper.Map<IEnumerable<CursoGetViewModel>>(result) : null;
        }

        #region Metodos privados
        private Func<Curso, bool> GetFuncaoFiltro(CursoFiltroViewModel filtro)
        => x =>
               (filtro.Id == Guid.Empty || x.Id == filtro.Id)
            && (!filtro.Turno.HasValue || x.Turno == filtro.Turno.Value)
            && (!filtro.Nome.HasValue() || x.Nome.ToLower() == filtro.Nome.ToLower())
            && (!filtro.AreaAtuacao.HasValue() || x.AreaAtuacao.ToLower() == filtro.AreaAtuacao.ToLower());
        #endregion
    }
}
