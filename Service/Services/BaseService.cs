using Dominio.Entidades;
using Dominio.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BaseService<TEntidade> : IBaseService<TEntidade> where TEntidade : Base
    {
        public Task<bool> AddAynsc(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetAsync(Func<TEntidade, bool> query = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
