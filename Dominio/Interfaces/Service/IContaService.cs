using Dominio.Entidades;

namespace Dominio.Interfaces.Service
{
    public interface IContaService : IBaseService<Conta>, IBaseServiceEspecifico<Conta>
    {
    }
}
