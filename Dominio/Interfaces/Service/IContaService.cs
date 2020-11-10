using Dominio.Entidades;
using Dominio.ValuesType;
using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IContaService : IBaseService<Conta>, IBaseServiceEspecifico<Conta>
    {
        Task RealizarOperacao(EnumOperacaoConta operaco, Guid idConta, decimal valor, Guid? idContaDestino = null);
    }
}
