using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
    {
       public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            builder.ToTable("Estacionamento");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.MtrValorHora).IsRequired();
            builder.Property(s => s.MinutosTolerancia);
            builder.Property(s => s.MinutosTolerancia);

            builder.HasOne(x => x.Endereco)
               .WithMany()
               .HasForeignKey(x => x.EnderecoId);
        }
    }
}


