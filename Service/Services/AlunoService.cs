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
            if (await ValidarCursoExistente(entidade.IdCurso))
                return entidade;
            await base.AddAsync(entidade, new AlunoValidator());
            return entidade;
        }

        public async Task<Aluno> UpdateAsync(Aluno entidade)
        {
            if (await ValidarCursoExistente(entidade.IdCurso))
                return entidade;
            await base.UpdateAsync(entidade, new AlunoValidator());
            return entidade;
        }

        #region Metodos privados
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
