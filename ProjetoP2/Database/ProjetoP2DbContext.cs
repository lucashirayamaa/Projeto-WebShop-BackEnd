using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjetoP2.Endpoints;
using ProjetoP2.Models;

namespace ProjetoP2.database;

public partial class ProjetoP2DbContext : DbContext
{

    public DbSet<Cliente> clientes { get; set; }

    public DbSet<Administrador> administradores { get; set; }

    public ProjetoP2DbContext()
    {
    }

    public ProjetoP2DbContext(DbContextOptions<ProjetoP2DbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("Server=localhost;User id=root; Database=login", ServerVersion.Parse("10.4.21-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");


            modelBuilder.Entity<Cliente>().HasIndex(u => u.NomeCliente).IsUnique();

            modelBuilder.Entity<Cliente>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Administrador>().HasIndex(u => u.Email).IsUnique();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
