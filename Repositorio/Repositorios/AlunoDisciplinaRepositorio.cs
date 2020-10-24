using Crosscuting.Notificacao;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class AlunoDisciplinaRepositorio : BaseRepositorio<AlunoDisciplina>
    {
        public AlunoDisciplinaRepositorio(Context context, INotificador notificador) : base(context, notificador)
        {

        }

        public async override Task<IQueryable<AlunoDisciplina>> GetAsync(Func<AlunoDisciplina, bool> query = null)
        {
            await Task.Yield();
            return query is null ?
              Context.AlunoDisciplina.Include(x => x.Aluno).Include(x => x.Disciplina).AsQueryable() :
              Context.AlunoDisciplina.Include(x => x.Aluno).Include(x => x.Disciplina).Where(query).AsQueryable();
        }
    }
}
