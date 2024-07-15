using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class update_table_hrm_employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyName",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "create_by_fullname",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delete_by_fullname",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employee_code",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "update_by_fullname",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyName",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "create_by_fullname",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "delete_by_fullname",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "employee_code",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "update_by_fullname",
                table: "UserInfomation");
        }
    }
}
