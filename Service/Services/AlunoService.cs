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
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public AlunoService(IAlunoRepositorio repositorio, InjectorServiceBase injector, ICursoRepositorio cursoRepositorio) 
            : base(repositorio, injector)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public async Task<Aluno> AddAsync(Aluno entidade)
        {
            if (!await ValidarCursoExistente(entidade.IdCurso) || !await ValidarAlunoDuplicado(entidade))
                return entidade;
            await base.AddAsync(entidade, new AlunoValidator());
            return entidade;
        }

        public async Task<Aluno> UpdateAsync(Aluno entidade)
        {
            if (!await ValidarCursoExistente(entidade.IdCurso) || !await ValidarAlunoDuplicado(entidade))
                return entidade;
            await base.UpdateAsync(entidade, new AlunoValidator());
            return entidade;
        }

        #region Metodos privados
        private async Task<bool> ValidarCursoExistente(Guid idCurso)
        {
            if (idCurso == null || idCurso == Guid.Empty || await _cursoRepositorio.GetByIdAsync(idCurso) is null)
            {
                Injector.Notificador.Add("Curso solicitado não existe.");
                return false;
            }
            return true;
        }

        private async Task<bool> ValidarAlunoDuplicado(Aluno entidade)
        {
            if (entidade == null || 
                (await Repositorio.GetAsync(x => x.Cpf == entidade.Cpf && x.IdCurso == entidade.IdCurso)).HasValue())
            {
                Injector.Notificador.Add("Aluno já registrado no curso informado.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
