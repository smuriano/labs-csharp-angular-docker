using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Infra.Migrations
{
  public partial class InitialVersion : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Exames",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Version = table.Column<byte[]>(rowVersion: true, nullable: true),
            CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            Descricao = table.Column<string>(maxLength: 60, nullable: false),
            Preco = table.Column<double>(nullable: false, defaultValue: 0.0)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Exames", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Medicos",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Version = table.Column<byte[]>(rowVersion: true, nullable: true),
            CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            Nome = table.Column<string>(maxLength: 60, nullable: false),
            CRM = table.Column<string>(maxLength: 10, nullable: false),
            Especialidade = table.Column<string>(maxLength: 30, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Medicos", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Pacientes",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Version = table.Column<byte[]>(rowVersion: true, nullable: true),
            CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            Nome = table.Column<string>(maxLength: 60, nullable: false),
            CPF = table.Column<string>(maxLength: 20, nullable: false),
            RG = table.Column<string>(maxLength: 20, nullable: false),
            DataNascimento = table.Column<DateTime>(type: "timestamp", nullable: false),
            Sexo = table.Column<string>(maxLength: 1, nullable: false),
            Cep = table.Column<string>(maxLength: 10, nullable: true),
            Logradouro = table.Column<string>(maxLength: 100, nullable: true),
            Numero = table.Column<string>(maxLength: 10, nullable: true),
            Complemento = table.Column<string>(maxLength: 30, nullable: true),
            Bairro = table.Column<string>(maxLength: 50, nullable: true),
            Cidade = table.Column<string>(maxLength: 100, nullable: true),
            Estado = table.Column<string>(maxLength: 2, nullable: true),
            Celular = table.Column<string>(maxLength: 20, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Pacientes", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "PostosColeta",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Version = table.Column<byte[]>(rowVersion: true, nullable: true),
            CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
            LabId = table.Column<Guid>(maxLength: 32, nullable: false),
            Descricao = table.Column<string>(maxLength: 60, nullable: false),
            Cep = table.Column<string>(maxLength: 10, nullable: true),
            Logradouro = table.Column<string>(maxLength: 100, nullable: true),
            Numero = table.Column<string>(maxLength: 10, nullable: true),
            Complemento = table.Column<string>(maxLength: 30, nullable: true),
            Bairro = table.Column<string>(maxLength: 50, nullable: true),
            Cidade = table.Column<string>(maxLength: 100, nullable: true),
            Estado = table.Column<string>(maxLength: 2, nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PostosColeta", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Exames");

      migrationBuilder.DropTable(
          name: "Medicos");

      migrationBuilder.DropTable(
          name: "Pacientes");

      migrationBuilder.DropTable(
          name: "PostosColeta");
    }
  }
}
