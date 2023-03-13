using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTeste.Model;

namespace SmartTeste.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(2);
            builder.Property(x => x.DataCadastro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nascimento).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11|10);
        }
    }
}
