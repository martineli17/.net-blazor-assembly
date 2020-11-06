using Crosscuting.Notificacao;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {
        }

        public async override Task<IQueryable<Cliente>> GetAsync(Func<Cliente, bool> filter = null)
        {
            await Task.Yield();
            return filter is null ?
               Context.Cliente.Include(x => x.Conta).AsQueryable() :
                Context.Cliente.Include(x => x.Conta).Where(filter).AsQueryable();
        }
    }
}
