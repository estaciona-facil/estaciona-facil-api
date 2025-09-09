using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Context.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Id");

            builder.Property(x => x.Placa)
                .IsRequired()
                .HasColumnType("CHAR(8)")
                .HasColumnName("Placa");

            builder.Property(x => x.Modelo)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Modelo");

            builder.Property(x => x.Marca)
               .IsRequired()
               .HasColumnType("VARCHAR(25)")
               .HasColumnName("Marca");
        }
    }
}