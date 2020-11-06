using Dominio.Entidades;

namespace Dominio.Interfaces.Service
{
    public interface IClienteService : IBaseService<Cliente>, IBaseServiceEspecifico<Cliente>
    {
    }
}
