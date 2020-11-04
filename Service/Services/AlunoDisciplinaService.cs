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
    public class AlunoDisciplinaService : BaseService<AlunoDisciplina>, IAlunoDisciplinaService
    {
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoDisciplinaService(IAlunoDisciplinaRepositorio repositorio, InjectorServiceBase injector, 
                                IDisciplinaRepositorio disciplinaRepositorio, IAlunoRepositorio alunoRepositorio) 
            : base(repositorio, injector)
        {
            _disciplinaRepositorio = disciplinaRepositorio;
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<AlunoDisciplina> AddAsync(AlunoDisciplina entidade)
        {
            if (!await ExisteDisciplina(entidade.IdDisciplina) || !await ExisteAluno(entidade.IdAluno) || !await ValidarDuplicidade(entidade))
                return entidade;
            await base.AddAsync(entidade, new AlunoDisciplinaValidator());
            return entidade;
        }

        public async Task<AlunoDisciplina> UpdateAsync(AlunoDisciplina entidade)
        {
            if (!await ExisteDisciplina(entidade.IdDisciplina) || !await ExisteAluno(entidade.IdAluno) || !await ValidarDuplicidade(entidade, true))
                return entidade;
            await base.UpdateAsync(entidade, new AlunoDisciplinaValidator());
            return entidade;
        }

        #region Metodos privados

        private async Task<bool> ExisteDisciplina(Guid idDisciplina)
        {
            if(await _disciplinaRepositorio.GetByIdAsync(idDisciplina) is null)
            {
                Injector.Notificador.Add("Disciplina solicitada não existe.");
                return false;
            }
            return true;
        }

        private async Task<bool> ExisteAluno(Guid idAluno)
        {
            if (await _alunoRepositorio.GetByIdAsync(idAluno) is null)
            {
                Injector.Notificador.Add("Aluno solicitado não existe.");
                return false;
            }
            return true;
        }

        private async Task<bool> ValidarDuplicidade(AlunoDisciplina entidade, bool update = false)
        {
            if ((await Repositorio.GetAsync(x => !update && (x.IdAluno == entidade.IdAluno && x.IdDisciplina == entidade.IdDisciplina))).HasValue())
            {
                Injector.Notificador.Add("Aluno já matriculado nesta disciplina.");
                return false;
            }
            return true;
        }

        #endregion
    }
}
