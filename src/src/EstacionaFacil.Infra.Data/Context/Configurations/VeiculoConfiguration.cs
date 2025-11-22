using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
       public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Placa).IsRequired().HasMaxLength(8);

            builder.HasOne(x => x.Proprietario)
                .WithMany()
                .HasForeignKey(x => x.ProprietarioId);

            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(x => x.ModeloId);
        }
    }
}


