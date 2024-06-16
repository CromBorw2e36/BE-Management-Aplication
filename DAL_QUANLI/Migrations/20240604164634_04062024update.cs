using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _04062024update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Company",
                newName: "update_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "Company",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_at",
                table: "Company",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delete_by",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "Company",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "left_company",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "right_company",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "update_by",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_at",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "delete_at",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "delete_by",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "left_company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "right_company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "update_by",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "update_at",
                table: "Company",
                newName: "date");
        }
    }
}
