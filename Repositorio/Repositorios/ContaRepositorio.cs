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
    public class ContaRepositorio : BaseRepositorio<Conta>, IContaRepositorio
    {
        public ContaRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {
        }

        public async override Task<IQueryable<Conta>> GetAsync(Func<Conta, bool> filter = null)
        {
            await Task.Yield();
            return filter is null ?
               Context.Conta.Include(x => x.Cliente).AsQueryable() :
                Context.Conta.Include(x => x.Cliente).Where(filter).AsQueryable();
        }
    }
}
