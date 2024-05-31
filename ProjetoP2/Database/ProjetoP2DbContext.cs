using Microsoft.EntityFrameworkCore;
using ProjetoP2.Models;

namespace ProjetoP2.database;

public partial class ProjetoP2DbContext : DbContext
{

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Chamado> Chamados {  get; set; }
    public DbSet<Mensagem> Mensagems { get; set; }

    public ProjetoP2DbContext()
    {
    }

    public ProjetoP2DbContext(DbContextOptions<ProjetoP2DbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
