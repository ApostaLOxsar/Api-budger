using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class nameSonameInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "clients",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "soname",
                schema: "clients",
                table: "users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                schema: "clients",
                table: "users");

            migrationBuilder.DropColumn(
                name: "soname",
                schema: "clients",
                table: "users");
        }
    }
}
