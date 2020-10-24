using Crosscuting.Notificacao;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class DisciplinaRepositorio : BaseRepositorio<Disciplina>
    {
        public DisciplinaRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {
        }

        public async override Task<IQueryable<Disciplina>> GetAsync(Func<Disciplina, bool> query = null)
        {
            await Task.Yield();
            return query is null ?
                  Context.Disciplina.Include(x => x.Curso).AsQueryable() :
                  Context.Disciplina.Include(x => x.Curso).Where(query).AsQueryable();
        }
    }
}
