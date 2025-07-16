using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioASC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuantidadePessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidadePessoa",
                table: "reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidadePessoa",
                table: "reserva");
        }
    }
}
