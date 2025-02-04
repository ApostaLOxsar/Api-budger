using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class delCascadeDel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                schema: "clients",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                schema: "clients",
                table: "users",
                column: "role_id",
                principalSchema: "clients",
                principalTable: "roles",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                schema: "clients",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                schema: "clients",
                table: "users",
                column: "role_id",
                principalSchema: "clients",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
