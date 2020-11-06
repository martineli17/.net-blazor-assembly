using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60).IsUnicode(false);
            builder.Property(x => x.Cpf).HasColumnName("CPF").HasColumnType("varchar(11)").IsRequired().HasMaxLength(11).IsUnicode(false);
            builder.Property(x => x.DataNascimento).HasColumnName("DATANASCIMENTO").HasColumnType("datetime").IsRequired();
            builder.HasOne(cliente => cliente.Conta).WithOne(conta => conta.Cliente).HasForeignKey<Conta>(x => x.IdCliente).IsRequired();
        }
    }
}
