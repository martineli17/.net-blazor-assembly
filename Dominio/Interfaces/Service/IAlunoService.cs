using Dominio.Entidades;

namespace Dominio.Interfaces.Service
{
    public interface IAlunoService : IBaseService<Aluno>, IBaseServiceEspecifico<Aluno>
    {
    }
}
