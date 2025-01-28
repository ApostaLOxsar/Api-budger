﻿// <auto-generated />
using System;
using Api_budger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_budger.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api_budger.Models.budgers.Budger", b =>
                {
                    b.Property<long>("BudgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("budger_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BudgerId"));

                    b.Property<double>("BudgerAmount")
                        .HasColumnType("double precision")
                        .HasColumnName("budger_amount");

                    b.Property<long>("BudgerCategoriyId")
                        .HasColumnType("bigint")
                        .HasColumnName("budger_category_id");

                    b.Property<string>("BudgerName")
                        .HasColumnType("text")
                        .HasColumnName("budger");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("BudgerId");

                    b.HasIndex("BudgerCategoriyId");

                    b.HasIndex("UserId");

                    b.ToTable("budger", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.DefaultBudgerCategory", b =>
                {
                    b.Property<long>("DefaultBudgerCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("default_budger_category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DefaultBudgerCategoryId"));

                    b.Property<string>("BudgerCategoryName")
                        .HasColumnType("text")
                        .HasColumnName("budger_category");

                    b.HasKey("DefaultBudgerCategoryId");

                    b.ToTable("default_budger_category", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.DefaultIncomeCategory", b =>
                {
                    b.Property<long>("DefaultIncomCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("default_incom_category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DefaultIncomCategoryId"));

                    b.Property<string>("IncomCategoryName")
                        .HasColumnType("text")
                        .HasColumnName("incom_category");

                    b.HasKey("DefaultIncomCategoryId");

                    b.ToTable("default_incom_category", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.Incom", b =>
                {
                    b.Property<long>("IncomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("incom_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IncomId"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("IncomName")
                        .HasColumnType("text")
                        .HasColumnName("incom");

                    b.Property<double>("IncomeAmount")
                        .HasColumnType("double precision")
                        .HasColumnName("income_amount");

                    b.Property<long>("IncomeCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("incom_category_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("IncomId");

                    b.HasIndex("IncomeCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("incoms", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.IncomCategory", b =>
                {
                    b.Property<long>("IncomCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("incom_category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IncomCategoryId"));

                    b.Property<string>("IncomCategoryName")
                        .HasColumnType("text")
                        .HasColumnName("incom_category");

                    b.HasKey("IncomCategoryId");

                    b.ToTable("incom_categories", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.IncomCategoryHasFamily", b =>
                {
                    b.Property<long>("IncomCategoryHasFamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("incom_category_has_family_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IncomCategoryHasFamilyId"));

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint")
                        .HasColumnName("family_id");

                    b.Property<long>("IncomCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("incom_category_id");

                    b.HasKey("IncomCategoryHasFamilyId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("IncomCategoryId");

                    b.ToTable("incom_category_has_family", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.budgers.BudgerCategory", b =>
                {
                    b.Property<long>("BudgerCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("budger_categoriy_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BudgerCategoryId"));

                    b.Property<string>("BudgerCategoryName")
                        .HasColumnType("text")
                        .HasColumnName("budger_categoriy");

                    b.HasKey("BudgerCategoryId");

                    b.ToTable("budger_categories", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.budgers.BudgerCategoryHasFamily", b =>
                {
                    b.Property<long>("BudgerCategoryHasFamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("budger_category_has_family_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BudgerCategoryHasFamilyId"));

                    b.Property<long>("BudgerCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("budger_category_id");

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint")
                        .HasColumnName("family_id");

                    b.HasKey("BudgerCategoryHasFamilyId");

                    b.HasIndex("BudgerCategoryId");

                    b.HasIndex("FamilyId");

                    b.ToTable("budger_category_has_family", "budgers");
                });

            modelBuilder.Entity("Api_budger.Models.clients.Family", b =>
                {
                    b.Property<long>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("family_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("FamilyId"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("famili");

                    b.HasKey("FamilyId");

                    b.ToTable("families", "clients");
                });

            modelBuilder.Entity("Api_budger.Models.clients.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("RoleRus")
                        .HasColumnType("text")
                        .HasColumnName("role_rus");

                    b.HasKey("RoleId");

                    b.ToTable("roles", "clients");
                });

            modelBuilder.Entity("Api_budger.Models.clients.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint")
                        .HasColumnName("family_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<string>("Soname")
                        .HasColumnType("text")
                        .HasColumnName("soname");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint")
                        .HasColumnName("telegram_id");

                    b.HasKey("UserId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("RoleId");

                    b.ToTable("users", "clients");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.Budger", b =>
                {
                    b.HasOne("Api_budger.Models.budgers.budgers.BudgerCategory", "BudgerCategory")
                        .WithMany("Budgers")
                        .HasForeignKey("BudgerCategoriyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_budger.Models.clients.User", "User")
                        .WithMany("Buders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgerCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.Incom", b =>
                {
                    b.HasOne("Api_budger.Models.budgers.IncomCategory", "IncomeCategory")
                        .WithMany("Incoms")
                        .HasForeignKey("IncomeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_budger.Models.clients.User", "User")
                        .WithMany("Incoms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IncomeCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.IncomCategoryHasFamily", b =>
                {
                    b.HasOne("Api_budger.Models.clients.Family", "Family")
                        .WithMany("IncomeCategoryHasFamilies")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_budger.Models.budgers.IncomCategory", "IncomCategory")
                        .WithMany("IncomCategoryHasFamilies")
                        .HasForeignKey("IncomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("IncomCategory");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.budgers.BudgerCategoryHasFamily", b =>
                {
                    b.HasOne("Api_budger.Models.budgers.budgers.BudgerCategory", "BudgerCategory")
                        .WithMany("BudgerCategoryHasFamilies")
                        .HasForeignKey("BudgerCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_budger.Models.clients.Family", "Family")
                        .WithMany("BudgerCategoryHasFamilies")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgerCategory");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Api_budger.Models.clients.User", b =>
                {
                    b.HasOne("Api_budger.Models.clients.Family", "Family")
                        .WithMany("Users")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_budger.Models.clients.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.IncomCategory", b =>
                {
                    b.Navigation("IncomCategoryHasFamilies");

                    b.Navigation("Incoms");
                });

            modelBuilder.Entity("Api_budger.Models.budgers.budgers.BudgerCategory", b =>
                {
                    b.Navigation("BudgerCategoryHasFamilies");

                    b.Navigation("Budgers");
                });

            modelBuilder.Entity("Api_budger.Models.clients.Family", b =>
                {
                    b.Navigation("BudgerCategoryHasFamilies");

                    b.Navigation("IncomeCategoryHasFamilies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Api_budger.Models.clients.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Api_budger.Models.clients.User", b =>
                {
                    b.Navigation("Buders");

                    b.Navigation("Incoms");
                });
#pragma warning restore 612, 618
        }
    }
}
