using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class update_table_hrm_employee_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "department_name",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position_name",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status_employee_id",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status_employee_name",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_employee_name",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_work_name",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "department_name",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "position_name",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "status_employee_id",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "status_employee_name",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "type_employee_name",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "type_work_name",
                table: "UserInfomation");
        }
    }
}
