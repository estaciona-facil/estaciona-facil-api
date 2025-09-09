using Estacionamento.Domain.Entidades.Estacionamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Context.Configurations
{
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<EstacionamentoBasico>
    {
        public void Configure(EntityTypeBuilder<EstacionamentoBasico> builder)
        {
            builder.ToTable("Estacionamento");

            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Id");

            builder.Property(x => x.DataAcesso)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DataAcesso");

            builder.Property(x => x.DataHoraEntrada)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DataHoraEntrada");

            builder.Property(x => x.DataHoraSaida)
                .HasColumnType("DATETIME")
                .HasColumnName("DataHoraSaida");
        }
    }
}