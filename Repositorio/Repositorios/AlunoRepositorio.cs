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
        public AlunoRepositorio(Context context) : base(context)
        {
        }

        public async override Task<IQueryable<Aluno>> GetAsync(Func<Aluno, bool> query = null)
        {
            await Task.Yield();
            return Context.Aluno.Include(x => x.Curso).Where(query).AsQueryable();
        }
    }
}
