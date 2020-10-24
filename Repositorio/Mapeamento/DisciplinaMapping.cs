using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("DISCIPLINA");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.CargaHoraria).HasColumnName("CARGAHORARIA").HasColumnType("numeric(10,2)").IsRequired();
            builder.Property(x => x.NotaMinimaAprovacao).HasColumnName("NOTAMINIMAAPROCACAO").HasColumnType("numeric(5,2)").IsRequired();
            builder.HasOne(disciplina => disciplina.Curso).WithMany(curso => curso.Diciplinas).HasForeignKey(disciplina => disciplina.IdCurso);
            builder.HasMany(disciplina => disciplina.AlunoDisciplina).WithOne(alunoDisciplina => alunoDisciplina.Disciplina).HasForeignKey(x => x.IdDisciplina).IsRequired();
        }
    }
}
