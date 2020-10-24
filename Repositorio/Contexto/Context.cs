using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplina { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}