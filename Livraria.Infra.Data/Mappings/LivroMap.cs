using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Livraria.Domain.Models;

namespace Livraria.Infra.Data.Mappings
{    
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Titulo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Autor)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.AnoPublicacao)
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .IsRequired();
        }
    }
}