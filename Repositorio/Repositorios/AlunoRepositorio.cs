using Crosscuting.Notificacao;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>
    {
        public AlunoRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {
        }

        public async override Task<IQueryable<Aluno>> GetAsync(Func<Aluno, bool> query = null)
        {
            await Task.Yield();
            return query is null ?
               Context.Aluno.Include(x => x.Curso).Include(x => x.AlunoDisciplina).AsQueryable() :
                Context.Aluno.Include(x => x.Curso).Include(x => x.AlunoDisciplina).Where(query).AsQueryable();
        }
    }
}
