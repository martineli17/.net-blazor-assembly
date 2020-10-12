using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseService<TEntidade> where TEntidade : class
    {
        Task<TEntidade> AddAsync(TEntidade entidade, AbstractValidator<TEntidade> validation);
        Task<bool> RemoveAsync(Guid id);
        Task<TEntidade> UpdateAsync(TEntidade entidade, AbstractValidator<TEntidade> validation);
        Task<IQueryable<TEntidade>> GetAsync(Func<TEntidade, bool> query = null);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}
