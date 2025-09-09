using Estacionamento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Context.Configurations
{
    public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietario");

            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(150)")
                .HasColumnName("Nome");

            builder.Property(x => x.NumeroCarteiraNacionalDeHabilitacao)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasColumnName("Cnh");

            builder.Property(x => x.Telefone)
               .IsRequired()
               .HasColumnType("CHAR(13)")
               .HasColumnName("Telefone");

            builder.Property(x => x.Celular)
               .IsRequired()
               .HasColumnType("CHAR(13)")
               .HasColumnName("Celular");

            builder.Property(x => x.Endereco)
               .IsRequired()
               .HasColumnType("VARCHAR(200)")
               .HasColumnName("Endereco");
        }
    }
}