using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using FluentValidation;
using Service.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services.ServicesBase
{
    public class BaseService<TEntidade> : IBaseService<TEntidade> where TEntidade : Base
    {
        protected readonly IBaseRepositorio<TEntidade> Repositorio;
        protected readonly InjectorServiceBase Injector;

        public BaseService(IBaseRepositorio<TEntidade> repositorio, InjectorServiceBase injector)
        {
            Repositorio = repositorio;
            Injector = injector;
        }
        public async Task<TEntidade> AddAsync(TEntidade entidade, AbstractValidator<TEntidade> validation)
        {
            if (Injector.Validator.Executar(validation, entidade))
                await Repositorio.AddAsync(entidade);
            return entidade;
        }

        public async Task<IQueryable<TEntidade>> GetAsync(Func<TEntidade, bool> query = null) => await Repositorio.GetAsync(query);

        public async Task<TEntidade> GetByIdAsync(Guid id) => await Repositorio.GetByIdAsync(id);

        public async Task<bool> RemoveAsync(Guid id)
        {
            if (await ValidarExistenciaEntidade(id))
                return false;
            await Repositorio.RemoveAsync(id);
            return true;
        }

        public async Task<TEntidade> UpdateAsync(TEntidade entidade, AbstractValidator<TEntidade> validation)
        {
            if (await ValidarExistenciaEntidade(entidade.Id))
                return entidade;
            if (Injector.Validator.Executar(validation, entidade))
                await Repositorio.UpdateAsync(entidade);
            return entidade;
        }

        #region Metodos privados
        private async Task<bool> ValidarExistenciaEntidade(Guid id)
        {
            if (await Repositorio.GetByIdAsync(id) is null)
            {
                Injector.Notificador.Add("Registro solicitado não existe.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
