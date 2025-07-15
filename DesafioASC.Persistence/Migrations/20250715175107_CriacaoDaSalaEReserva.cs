using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioASC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaSalaEReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sala",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    capacidadeMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sala", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataHoraFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_reserva_sala_salaId",
                        column: x => x.salaId,
                        principalTable: "sala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reserva_salaId",
                table: "reserva",
                column: "salaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reserva");

            migrationBuilder.DropTable(
                name: "sala");
        }
    }
}
