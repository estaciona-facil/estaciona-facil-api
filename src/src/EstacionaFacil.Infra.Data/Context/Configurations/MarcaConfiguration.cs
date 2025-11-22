using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
       public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marca");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}


