using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
    {
       public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietario");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(150);
        }
    }
}


