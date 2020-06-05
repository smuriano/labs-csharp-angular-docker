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
                    Preco = table.Column<decimal>(nullable: false, defaultValue: 0m)
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

            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    PostoColetaId = table.Column<Guid>(nullable: false),
                    DataExame = table.Column<DateTime>(type: "timestamp", nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    Convenio = table.Column<string>(maxLength: 30, nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    DataRetirada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdensServico_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdensServico_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdensServico_PostosColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostosColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServicoExames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    OrdemServicoId = table.Column<Guid>(nullable: false),
                    ExameId = table.Column<Guid>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    OrdemServicoId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoExames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServicoExames_Exames_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServicoExames_OrdensServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdensServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServicoExames_OrdensServico_OrdemServicoId1",
                        column: x => x.OrdemServicoId1,
                        principalTable: "OrdensServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoExames_ExameId",
                table: "OrdemServicoExames",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoExames_OrdemServicoId",
                table: "OrdemServicoExames",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoExames_OrdemServicoId1",
                table: "OrdemServicoExames",
                column: "OrdemServicoId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_MedicoId",
                table: "OrdensServico",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_PacienteId",
                table: "OrdensServico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_PostoColetaId",
                table: "OrdensServico",
                column: "PostoColetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServicoExames");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "OrdensServico");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "PostosColeta");
        }
    }
}
