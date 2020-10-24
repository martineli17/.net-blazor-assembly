using Dominio.Entidades;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface ICursoService : IBaseService<Curso>
    {
        Task<Curso> AddAsync(Curso entidade);
        Task<Curso> UpdateAsync(Curso entidade);
    }
}
