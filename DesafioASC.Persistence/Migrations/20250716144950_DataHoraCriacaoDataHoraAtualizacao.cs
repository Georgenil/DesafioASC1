using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioASC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataHoraCriacaoDataHoraAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataHoraInicio",
                table: "reserva",
                newName: "dataHoraCriacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataHoraAtualizacao",
                table: "sala",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataHoraCriacao",
                table: "sala",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataHoraAtualizacao",
                table: "reserva",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataHoraAtualizacao",
                table: "sala");

            migrationBuilder.DropColumn(
                name: "dataHoraCriacao",
                table: "sala");

            migrationBuilder.DropColumn(
                name: "dataHoraAtualizacao",
                table: "reserva");

            migrationBuilder.RenameColumn(
                name: "dataHoraCriacao",
                table: "reserva",
                newName: "dataHoraInicio");
        }
    }
}
