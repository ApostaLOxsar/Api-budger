using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class delCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_budger_budger_categories_budger_category_id",
                schema: "budgers",
                table: "budger");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_users_user_id",
                schema: "budgers",
                table: "budger");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_category_has_family_budger_categories_budger_categor~",
                schema: "budgers",
                table: "budger_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_category_has_family_families_family_id",
                schema: "budgers",
                table: "budger_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incom_category_has_family_families_family_id",
                schema: "budgers",
                table: "incom_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incom_category_has_family_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incom_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incoms_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incoms");

            migrationBuilder.DropForeignKey(
                name: "FK_incoms_users_user_id",
                schema: "budgers",
                table: "incoms");

            migrationBuilder.AddForeignKey(
                name: "FK_budger_budger_categories_budger_category_id",
                schema: "budgers",
                table: "budger",
                column: "budger_category_id",
                principalSchema: "budgers",
                principalTable: "budger_categories",
                principalColumn: "budger_categoriy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_budger_users_user_id",
                schema: "budgers",
                table: "budger",
                column: "user_id",
                principalSchema: "clients",
                principalTable: "users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_budger_category_has_family_budger_categories_budger_categor~",
                schema: "budgers",
                table: "budger_category_has_family",
                column: "budger_category_id",
                principalSchema: "budgers",
                principalTable: "budger_categories",
                principalColumn: "budger_categoriy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_budger_category_has_family_families_family_id",
                schema: "budgers",
                table: "budger_category_has_family",
                column: "family_id",
                principalSchema: "clients",
                principalTable: "families",
                principalColumn: "family_id");

            migrationBuilder.AddForeignKey(
                name: "FK_incom_category_has_family_families_family_id",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "family_id",
                principalSchema: "clients",
                principalTable: "families",
                principalColumn: "family_id");

            migrationBuilder.AddForeignKey(
                name: "FK_incom_category_has_family_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "incom_category_id",
                principalSchema: "budgers",
                principalTable: "incom_categories",
                principalColumn: "incom_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_incoms_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incoms",
                column: "incom_category_id",
                principalSchema: "budgers",
                principalTable: "incom_categories",
                principalColumn: "incom_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_incoms_users_user_id",
                schema: "budgers",
                table: "incoms",
                column: "user_id",
                principalSchema: "clients",
                principalTable: "users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_budger_budger_categories_budger_category_id",
                schema: "budgers",
                table: "budger");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_users_user_id",
                schema: "budgers",
                table: "budger");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_category_has_family_budger_categories_budger_categor~",
                schema: "budgers",
                table: "budger_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_budger_category_has_family_families_family_id",
                schema: "budgers",
                table: "budger_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incom_category_has_family_families_family_id",
                schema: "budgers",
                table: "incom_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incom_category_has_family_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incom_category_has_family");

            migrationBuilder.DropForeignKey(
                name: "FK_incoms_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incoms");

            migrationBuilder.DropForeignKey(
                name: "FK_incoms_users_user_id",
                schema: "budgers",
                table: "incoms");

            migrationBuilder.AddForeignKey(
                name: "FK_budger_budger_categories_budger_category_id",
                schema: "budgers",
                table: "budger",
                column: "budger_category_id",
                principalSchema: "budgers",
                principalTable: "budger_categories",
                principalColumn: "budger_categoriy_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_budger_users_user_id",
                schema: "budgers",
                table: "budger",
                column: "user_id",
                principalSchema: "clients",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_budger_category_has_family_budger_categories_budger_categor~",
                schema: "budgers",
                table: "budger_category_has_family",
                column: "budger_category_id",
                principalSchema: "budgers",
                principalTable: "budger_categories",
                principalColumn: "budger_categoriy_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_budger_category_has_family_families_family_id",
                schema: "budgers",
                table: "budger_category_has_family",
                column: "family_id",
                principalSchema: "clients",
                principalTable: "families",
                principalColumn: "family_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incom_category_has_family_families_family_id",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "family_id",
                principalSchema: "clients",
                principalTable: "families",
                principalColumn: "family_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incom_category_has_family_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "incom_category_id",
                principalSchema: "budgers",
                principalTable: "incom_categories",
                principalColumn: "incom_category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incoms_incom_categories_incom_category_id",
                schema: "budgers",
                table: "incoms",
                column: "incom_category_id",
                principalSchema: "budgers",
                principalTable: "incom_categories",
                principalColumn: "incom_category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incoms_users_user_id",
                schema: "budgers",
                table: "incoms",
                column: "user_id",
                principalSchema: "clients",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
