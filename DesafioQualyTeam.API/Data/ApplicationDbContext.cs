using DesafioQualyTeam.API.Data.Configurations;
using DesafioQualyTeam.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioQualyTeam.API.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Processo> Processos { get; set; }
    public DbSet<DetalhesArquivo> DetalhesArquivos { get; set; }
    public DbSet<Documento> Documentos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ProcessoEntityTypeConfiguration().Configure(modelBuilder.Entity<Processo>());
    }
}
