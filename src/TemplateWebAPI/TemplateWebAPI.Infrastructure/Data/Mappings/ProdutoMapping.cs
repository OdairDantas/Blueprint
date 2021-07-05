using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateWebAPI.Domain.Entites;

namespace $safeprojectname$.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(c => c.Valor).IsRequired();

            builder.ToTable("Produto");

        }
    }
}
