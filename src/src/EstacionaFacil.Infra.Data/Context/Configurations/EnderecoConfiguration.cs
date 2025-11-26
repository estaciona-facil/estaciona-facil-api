using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Infra.Data.Context.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
       public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Cep).IsRequired();
            builder.Property(s => s.Cidade).IsRequired();
            builder.Property(s => s.Bairro).IsRequired();
            builder.Property(s => s.Logradouro).IsRequired();
            builder.Property(s => s.Numero).IsRequired();
            builder.Property(s => s.Complemento);
        }
    }
}


