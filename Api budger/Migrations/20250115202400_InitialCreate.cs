using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "budgers");

            migrationBuilder.EnsureSchema(
                name: "clients");

            migrationBuilder.CreateTable(
                name: "budger_categories",
                schema: "budgers",
                columns: table => new
                {
                    budger_categoriy_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    budger_categoriy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budger_categories", x => x.budger_categoriy_id);
                });

            migrationBuilder.CreateTable(
                name: "default_budger_category",
                schema: "budgers",
                columns: table => new
                {
                    default_budger_category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    budger_category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_default_budger_category", x => x.default_budger_category_id);
                });

            migrationBuilder.CreateTable(
                name: "default_incom_category",
                schema: "budgers",
                columns: table => new
                {
                    default_incom_category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incom_category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_default_incom_category", x => x.default_incom_category_id);
                });

            migrationBuilder.CreateTable(
                name: "families",
                schema: "clients",
                columns: table => new
                {
                    family_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    famili = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_families", x => x.family_id);
                });

            migrationBuilder.CreateTable(
                name: "incom_categories",
                schema: "budgers",
                columns: table => new
                {
                    incom_category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incom_category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incom_categories", x => x.incom_category_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "clients",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<string>(type: "text", nullable: true),
                    role_rus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "budger_category_has_family",
                schema: "budgers",
                columns: table => new
                {
                    budger_category_has_family_id = table.Column<long>(type: "bigint", nullable: false),
                    family_id = table.Column<long>(type: "bigint", nullable: false),
                    budger_category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budger_category_has_family", x => x.budger_category_has_family_id);
                    table.ForeignKey(
                        name: "FK_budger_category_has_family_budger_categories_budger_categor~",
                        column: x => x.budger_category_id,
                        principalSchema: "budgers",
                        principalTable: "budger_categories",
                        principalColumn: "budger_categoriy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_budger_category_has_family_families_budger_category_has_fam~",
                        column: x => x.budger_category_has_family_id,
                        principalSchema: "clients",
                        principalTable: "families",
                        principalColumn: "family_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incom_category_has_family",
                schema: "budgers",
                columns: table => new
                {
                    incom_category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    family_id = table.Column<long>(type: "bigint", nullable: false),
                    IncomCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incom_category_has_family", x => x.incom_category_id);
                    table.ForeignKey(
                        name: "FK_incom_category_has_family_families_family_id",
                        column: x => x.family_id,
                        principalSchema: "clients",
                        principalTable: "families",
                        principalColumn: "family_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incom_category_has_family_incom_categories_IncomCategoryId",
                        column: x => x.IncomCategoryId,
                        principalSchema: "budgers",
                        principalTable: "incom_categories",
                        principalColumn: "incom_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "clients",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telegram_id = table.Column<long>(type: "bigint", nullable: false),
                    family_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_users_families_family_id",
                        column: x => x.family_id,
                        principalSchema: "clients",
                        principalTable: "families",
                        principalColumn: "family_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "clients",
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "budger",
                schema: "budgers",
                columns: table => new
                {
                    BudgerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    budger_category_id = table.Column<long>(type: "bigint", nullable: false),
                    budger = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budger", x => x.BudgerId);
                    table.ForeignKey(
                        name: "FK_budger_budger_categories_budger_category_id",
                        column: x => x.budger_category_id,
                        principalSchema: "budgers",
                        principalTable: "budger_categories",
                        principalColumn: "budger_categoriy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_budger_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "clients",
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incoms",
                schema: "budgers",
                columns: table => new
                {
                    IncomId = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    incom_category_id = table.Column<long>(type: "bigint", nullable: false),
                    incom = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incoms", x => x.IncomId);
                    table.ForeignKey(
                        name: "FK_incoms_incom_categories_IncomId",
                        column: x => x.IncomId,
                        principalSchema: "budgers",
                        principalTable: "incom_categories",
                        principalColumn: "incom_category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incoms_users_IncomId",
                        column: x => x.IncomId,
                        principalSchema: "clients",
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_budger_budger_category_id",
                schema: "budgers",
                table: "budger",
                column: "budger_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_budger_user_id",
                schema: "budgers",
                table: "budger",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_budger_category_has_family_budger_category_id",
                schema: "budgers",
                table: "budger_category_has_family",
                column: "budger_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_incom_category_has_family_family_id",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "family_id");

            migrationBuilder.CreateIndex(
                name: "IX_incom_category_has_family_IncomCategoryId",
                schema: "budgers",
                table: "incom_category_has_family",
                column: "IncomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_users_family_id",
                schema: "clients",
                table: "users",
                column: "family_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "clients",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budger",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "budger_category_has_family",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "default_budger_category",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "default_incom_category",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "incom_category_has_family",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "incoms",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "budger_categories",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "incom_categories",
                schema: "budgers");

            migrationBuilder.DropTable(
                name: "users",
                schema: "clients");

            migrationBuilder.DropTable(
                name: "families",
                schema: "clients");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "clients");
        }
    }
}
