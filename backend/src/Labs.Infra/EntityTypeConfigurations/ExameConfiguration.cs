using Labs.Domain.Exames.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labs.Infra.EntityTypeConfigurations
{
  public class ExameConfiguration : IEntityTypeConfiguration<Exame>
  {
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Version).IsRowVersion();
      builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
      builder.Property(x => x.ModifiedAt).HasColumnType("timestamp");

      builder.Property(x => x.Descricao).IsRequired().HasMaxLength(60);
      builder.Property(x => x.Preco).IsRequired().HasDefaultValue(0);

      //builder.HasOne(x => x.Corporate).WithMany().HasForeignKey(x => x.CorporateId);

      builder.Ignore(x => x.IsValid);
    }
  }
}