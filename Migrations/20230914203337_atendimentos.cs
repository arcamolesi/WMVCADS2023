using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMVCADS2023.Migrations
{
    /// <inheritdoc />
    public partial class atendimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    salaID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Salas_salaID",
                        column: x => x.salaID,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_alunoID",
                table: "Atendimentos",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_salaID",
                table: "Atendimentos",
                column: "salaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");
        }
    }
}
