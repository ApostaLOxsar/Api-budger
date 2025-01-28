﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_budger.Migrations
{
    /// <inheritdoc />
    public partial class addTGnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "telegram_id",
                schema: "clients",
                table: "users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "telegram_id",
                schema: "clients",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
