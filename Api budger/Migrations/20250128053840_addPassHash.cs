using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class addPassHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                schema: "clients",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                schema: "clients",
                table: "users");
        }
    }
}
