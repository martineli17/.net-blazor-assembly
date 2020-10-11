using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapeamento
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("ALUNO");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60).IsUnicode(false);
            builder.Property(x => x.Turno).HasColumnName("TURNO").HasColumnType("varchar(15)").IsRequired().HasMaxLength(15)
                .HasConversion(value => value.ToString(), dataBase => (EnumTurno)Enum.Parse(typeof(EnumTurno), dataBase));
            builder.HasMany(curso => curso.Alunos).WithOne(aluno => aluno.Curso).HasForeignKey(x => x.IdCurso);
            builder.HasMany(curso => curso.Diciplinas).WithOne(diciplina => diciplina.Curso).HasForeignKey(x => x.IdCurso);
        }
    }
}
