using Labs.Domain.Medicos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labs.Infra.EntityTypeConfigurations
{
  public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
  {
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Version).IsRowVersion();
      builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
      builder.Property(x => x.ModifiedAt).HasColumnType("timestamp");

      builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
      builder.Property(x => x.CRM).IsRequired().HasMaxLength(10);
      builder.Property(x => x.Especialidade).IsRequired().HasMaxLength(30);

      //builder.HasOne(x => x.Corporate).WithMany().HasForeignKey(x => x.CorporateId);

      builder.Ignore(x => x.IsValid);
    }
  }
}