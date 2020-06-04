using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Infra.Migrations
{
    public partial class OrdemServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "PostosColeta",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PostosColeta",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Pacientes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pacientes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Medicos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Medicos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Exames",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Exames",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

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
                    Preco = table.Column<double>(nullable: false, defaultValue: 0.0),
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
                name: "OrdensServico");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "PostosColeta",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PostosColeta",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Pacientes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pacientes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Medicos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Medicos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Exames",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Exames",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }
    }
}
