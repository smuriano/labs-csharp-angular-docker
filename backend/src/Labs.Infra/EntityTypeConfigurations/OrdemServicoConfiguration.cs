using Labs.Domain.OrdensServico.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labs.Infra.EntityTypeConfigurations
{
  public class OrdemServicoConfiguration : IEntityTypeConfiguration<OrdemServico>
  {
    public void Configure(EntityTypeBuilder<OrdemServico> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Version).IsRowVersion();
      builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
      builder.Property(x => x.ModifiedAt).HasColumnType("timestamp");

      builder.HasOne(x => x.PostoColeta).WithMany().HasForeignKey(x => x.PostoColetaId);
      builder.Property(x => x.DataExame).IsRequired().HasColumnType("timestamp");
      builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.PacienteId);
      builder.Property(x => x.Convenio).IsRequired().HasMaxLength(30);
      builder.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoId);

      builder.HasMany(x => x.Exames);

      builder.Ignore(x => x.ValidationResult);
      builder.Ignore(x => x.IsValid);
    }
  }
}