using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DisciplinaService : BaseService<Disciplina>, IDisciplinaService
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public DisciplinaService(IDisciplinaRepositorio repositorio, InjectorServiceBase injector,
            ICursoRepositorio cursoRepositorio) : base(repositorio, injector)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public async Task<Disciplina> AddAsync(Disciplina entidade)
        {
            if (!await ValidarCursoExistente(entidade.IdCurso) || !await ValidarDisciplinaDuplicada(entidade))
                return entidade;
            await base.AddAsync(entidade, new DisciplinaValidator());
            return entidade;
        }

        public async Task<Disciplina> UpdateAsync(Disciplina entidade)
        {
            if (!await ValidarCursoExistente(entidade.IdCurso) || !await ValidarDisciplinaDuplicada(entidade, true)) 
                return entidade;
            await base.UpdateAsync(entidade, new DisciplinaValidator());
            return entidade;
        }

        #region Metodos privados
        private async Task<bool> ValidarDisciplinaDuplicada(Disciplina entidade, bool update = false)
        {
            if (entidade == null ||
                (await Repositorio.GetAsync(x => (!update || x.Id != entidade.Id)
                && x.Nome == entidade.Nome && x.IdCurso == entidade.IdCurso)).HasValue())
            {
                Injector.Notificador.Add("Disciplina já registrada no curso informado.");
                return false;
            }
            return true;
        }
        private async Task<bool> ValidarCursoExistente(Guid idCurso)
        {
            if (await _cursoRepositorio.GetByIdAsync(idCurso) is null)
            {
                Injector.Notificador.Add("Curso solicitado não existe.");
                return false;
            }
            return true;
        }
        #endregion

    }
}
