using Labs.Domain.OrdensServico.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labs.Infra.EntityTypeConfigurations
{
  public class OrdemServicoExameConfiguration : IEntityTypeConfiguration<OrdemServicoExame>
  {
    public void Configure(EntityTypeBuilder<OrdemServicoExame> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Version).IsRowVersion();
      builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
      builder.Property(x => x.ModifiedAt).HasColumnType("timestamp");

      builder.HasOne(x => x.OrdemServico).WithMany().HasForeignKey(x => x.OrdemServicoId);
      builder.HasOne(x => x.Exame).WithMany().HasForeignKey(x => x.ExameId);
      builder.Property(x => x.Preco).IsRequired().HasDefaultValue(0);

      builder.Ignore(x => x.ValidationResult);
      builder.Ignore(x => x.IsValid);
    }
  }
}