using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        Task<Aluno> AddAsync(Aluno entidade);
        Task<Aluno> UpdateAsync(Aluno entidade);
    }
}
