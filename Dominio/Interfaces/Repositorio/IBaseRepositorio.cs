using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : Base
    {
        Task AddAynsc(TEntidade entidade);
        Task AddAynsc(IEnumerable<TEntidade> entidade);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(IEnumerable<Guid> id);
        Task UpdateAsync(TEntidade entidade);
        Task UpdateAsync(IEnumerable<TEntidade> entidade);
        Task<IQueryable<TEntidade>> GetAsync(Func<TEntidade, bool> query = null);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}
