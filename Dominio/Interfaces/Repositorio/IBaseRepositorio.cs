using Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : Base
    {
        Task<bool> AddAynsc(TEntidade entidade);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(TEntidade entidade);
        Task<bool> GetAsync(Func<TEntidade, bool> query = null);
        Task<bool> GetByIdAsync(Guid id);
    }
}
