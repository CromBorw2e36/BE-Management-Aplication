using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class update_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "UserInfomation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_at",
                table: "UserInfomation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delete_by",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "department_id",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "UserInfomation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position_id",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_employee_id",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_work_id",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "UserInfomation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "update_by",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_at",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "delete_at",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "delete_by",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "department_id",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "email",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "position_id",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "type_employee_id",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "type_work_id",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "update_by",
                table: "UserInfomation");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BHXH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codeCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    department_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_employee_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_work_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });
        }
    }
}
