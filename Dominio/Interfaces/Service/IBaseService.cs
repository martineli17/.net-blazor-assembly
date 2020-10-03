using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseService<TEntidade> where TEntidade : class
    {
        Task<bool> AddAynsc(TEntidade entidade);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(TEntidade entidade);
        Task<bool> GetAsync(Func<TEntidade, bool> query = null);
        Task<bool> GetByIdAsync(Guid id);
    }
}
