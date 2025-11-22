using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class RegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
       public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.ToTable("Registro");
            builder.HasKey(x => new { x.EstacionamentoId, x.VeiculoId, x.DataEntrada });
            builder.Property(s => s.DataEntrada).IsRequired();
            builder.Property(s => s.DataSaida);

            builder.HasOne(x => x.Veiculo)
                .WithMany()
                .HasForeignKey(x => x.VeiculoId)
                .IsRequired();

            builder.HasOne(x => x.Estacionamento)
                .WithMany()
                .HasForeignKey(x => x.EstacionamentoId)
                .IsRequired();
        }
    }
}


