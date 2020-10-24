using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapeamento
{
    public class AlunoDisciplinaMapping : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.ToTable("ALUNO_DISCIPLINA");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IdAluno);
            builder.HasIndex(x => x.IdDisciplina);
            builder.Property(x => x.Nota).HasColumnName("NOTA").HasColumnType("number(5,2)").IsRequired();
            builder.Property(x => x.IdAluno).HasColumnName("IDALUNO").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdDisciplina).HasColumnName("IDDISCIPLINA").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.HasOne(aluno => aluno.Aluno).WithMany(aluno => aluno.AlunoDisciplina).HasForeignKey(x => x.IdAluno).IsRequired();
            builder.HasOne(disciplina => disciplina.Disciplina).WithMany(disciplina => disciplina.AlunoDisciplina).HasForeignKey(x => x.IdDisciplina).IsRequired();
        }
            
    }
}
