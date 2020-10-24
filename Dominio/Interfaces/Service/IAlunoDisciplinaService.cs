using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IAlunoDisciplinaService : IBaseService<AlunoDisciplina>
    {
        Task<AlunoDisciplina> AddAsync(AlunoDisciplina entidade);
        Task<AlunoDisciplina> UpdateAsync(AlunoDisciplina entidade);
    }
}
