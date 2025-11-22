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
        }
    }
}


