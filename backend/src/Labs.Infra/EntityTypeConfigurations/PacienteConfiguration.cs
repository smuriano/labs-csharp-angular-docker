using Labs.Domain.Pacientes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labs.Infra.EntityTypeConfigurations
{
  public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
  {
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Version).IsRowVersion();
      builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
      builder.Property(x => x.ModifiedAt).HasColumnType("timestamp");

      builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
      builder.Property(x => x.CPF).IsRequired().HasMaxLength(20);
      builder.Property(x => x.RG).IsRequired().HasMaxLength(20);
      builder.Property(x => x.DataNascimento).HasColumnType("timestamp");
      builder.Property(x => x.Sexo).IsRequired().HasMaxLength(1);

      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Cep).HasColumnName("Cep").HasMaxLength(10);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Logradouro).HasColumnName("Logradouro").HasMaxLength(100);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Numero).HasColumnName("Numero").HasMaxLength(10);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Complemento).HasColumnName("Complemento").HasMaxLength(30);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Bairro).HasColumnName("Bairro").HasMaxLength(50);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Cidade).HasColumnName("Cidade").HasMaxLength(100);
      builder.OwnsOne(x => x.Endereco)
        .Property(o => o.Estado).HasColumnName("Estado").HasMaxLength(2);

      builder.Property(x => x.Celular).IsRequired().HasMaxLength(20);

      //builder.HasOne(x => x.Corporate).WithMany().HasForeignKey(x => x.CorporateId);

      // builder.OwnsOne(x => x.Endereco).Ignore(o => o.ValidationResult);
      builder.OwnsOne(x => x.Endereco).Ignore(o => o.IsValid);

      builder.Ignore(x => x.IsValid);
    }
  }
}