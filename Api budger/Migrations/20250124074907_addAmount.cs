using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class addAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "income_amount",
                schema: "budgers",
                table: "incoms",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "budger_amount",
                schema: "budgers",
                table: "budger",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income_amount",
                schema: "budgers",
                table: "incoms");

            migrationBuilder.DropColumn(
                name: "budger_amount",
                schema: "budgers",
                table: "budger");
        }
    }
}
