using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Id).HasColumnName("IDCLIENTE").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60).IsUnicode(false);
            builder.Property(x => x.NumeroConta).HasColumnName("NUMERO_CONTA").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(x => x.Saldo).HasColumnName("SALDO").HasColumnType("numeric(19,4").IsRequired().HasDefaultValue(0);
            builder.HasOne(conta => conta.Cliente).WithOne(cliente => cliente.Conta).HasForeignKey<Conta>(x => x.IdCliente).IsRequired();
        }
    }
}
