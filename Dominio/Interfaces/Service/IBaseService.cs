using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseService<TEntidade> where TEntidade : class
    {
        Task<bool> RemoveAsync(Guid id);
        Task<IQueryable<TEntidade>> GetAsync(Func<TEntidade, bool> query = null);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}
