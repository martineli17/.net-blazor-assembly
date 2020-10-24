using Dominio.Entidades;

namespace Dominio.Interfaces.Service
{
    public interface ICursoService : IBaseService<Curso>, IBaseServiceEspecifico<Curso>
    {
    }
}
