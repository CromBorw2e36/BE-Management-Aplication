using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _26062024_create_catalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BHXH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codeCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    department_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_employee_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_work_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StatusEmployee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEmployee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEmployee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEmployee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeWork",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeWork", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "StatusEmployee");

            migrationBuilder.DropTable(
                name: "TypeEmployee");

            migrationBuilder.DropTable(
                name: "TypeWork");
        }
    }
}
