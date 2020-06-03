using System;
using System.Linq;
using System.Threading.Tasks;
using Labs.Domain.Exames.Entities;
using Labs.Domain.Medicos.Entities;
using Labs.Domain.Pacientes.Entities;
using Labs.Domain.PostosColeta.Entities;
using Labs.Infra.EntityTypeConfigurations;
using Labs.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Contexts
{
  public class LabsContext : DbContext
  {
    public LabsContext(DbContextOptions<LabsContext> options) : base(options)
    {
      try
      {
        Database.Migrate();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public DbSet<Exame> Exames { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<PostoColeta> PostosColeta { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new ExameConfiguration());
      builder.ApplyConfiguration(new MedicoConfiguration());
      builder.ApplyConfiguration(new PacienteConfiguration());
      builder.ApplyConfiguration(new PostoColetaConfiguration());

      base.OnModelCreating(builder);
    }

    public async Task<int> SaveChangesAsync()
    {
      AddAuditInfo();
      return await base.SaveChangesAsync();
    }

    private void AddAuditInfo()
    {
      var entries = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));
      foreach (var entry in entries)
      {
        if (entry.State == EntityState.Added)
          ((Entity)entry.Entity).SetCreated();

        ((Entity)entry.Entity).SetModified();
      }
    }
  }
}