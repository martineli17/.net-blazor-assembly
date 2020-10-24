using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("ALUNO");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60).IsUnicode(false);
            builder.Property(x => x.Cpf).HasColumnName("CPF").HasColumnType("varchar(11)").IsRequired().HasMaxLength(11).IsUnicode(false);
            builder.Property(x => x.DataNascimento).HasColumnName("DATANASCIMENTO").HasColumnType("datetime").IsRequired();
            builder.HasOne(aluno => aluno.Curso).WithMany(curso => curso.Alunos).HasForeignKey(x => x.IdCurso).IsRequired();
            builder.HasMany(aluno => aluno.AlunoDisciplina).WithOne(alunoDisciplina => alunoDisciplina.Aluno).HasForeignKey(x => x.IdAluno).IsRequired();
        }
    }
}
