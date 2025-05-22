using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaMobiles.Migrations
{
    /// <inheritdoc />
    public partial class editarColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "IdealQuantity",
                table: "Materials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Movements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdealQuantity",
                table: "Materials",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
