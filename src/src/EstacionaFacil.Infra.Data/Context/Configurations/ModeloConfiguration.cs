using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
       public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Descricao).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.MarcaId);
        }
    }
}


