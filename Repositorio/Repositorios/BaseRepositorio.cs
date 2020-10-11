using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : Base
    {
        protected Context Context;

        public BaseRepositorio(Context context)
        {
            Context = context;
        }

        public virtual async Task AddAynsc(TEntity entidade) => await Context.Set<TEntity>().AddAsync(entidade);

        public virtual async Task AddAynsc(IEnumerable<TEntity> entidades) => await Context.Set<TEntity>().AddRangeAsync(entidades);

        public virtual async Task<IQueryable<TEntity>> GetAsync(Func<TEntity, bool> query = null)
        {
            await Task.Yield();
            return Context.Set<TEntity>().Where(query).AsQueryable();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await Context.Set<TEntity>().FindAsync(id);

        public virtual async Task RemoveAsync(Guid id) => Context.Set<TEntity>().Remove(await GetByIdAsync(id));

        public virtual async Task RemoveAsync(IEnumerable<Guid> id)
        {
            await Task.Yield();
            Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().Where(x => id.Contains(x.Id)));
        }

        public virtual async Task UpdateAsync(TEntity entidade)
        {
            await Task.Yield();
            Context.Set<TEntity>().Update(entidade);
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entidades)
        {
            await Task.Yield();
            Context.Set<TEntity>().UpdateRange(entidades);
        }
    }
}
