using ApiRestSmartInnovation.Data.Map;
using Microsoft.EntityFrameworkCore;
using SmartTeste.Model;

namespace SmartTeste.Data;

public class SistemaCadastroDBcontext : DbContext
{
    public SistemaCadastroDBcontext(DbContextOptions<SistemaCadastroDBcontext> options)
        : base(options)
    {
    }
    public DbSet<Usuario>? Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        base.OnModelCreating(modelBuilder);
    }

}

