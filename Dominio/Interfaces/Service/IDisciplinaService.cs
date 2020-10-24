using Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IDisciplinaService : IBaseService<Disciplina>
    {
        Task<Disciplina> AddAsync(Disciplina entidade);
        Task<Disciplina> UpdateAsync(Disciplina entidade);
    }
}
