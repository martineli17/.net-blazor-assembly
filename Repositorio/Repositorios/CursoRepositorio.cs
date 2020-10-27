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
    public class CursoRepositorio : BaseRepositorio<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {
        }

        public async override Task<IQueryable<Curso>> GetAsync(Func<Curso, bool> query = null)
        {
            await Task.Yield();
            return query is null ?
              Context.Curso.Include(x => x.Alunos).Include(x => x.Diciplinas).AsQueryable() :
              Context.Curso.Include(x => x.Alunos).Include(x => x.Diciplinas).Where(query).AsQueryable();
        }
    }
}
