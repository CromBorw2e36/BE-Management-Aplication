using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _14052024_update_description_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "description",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "description",
                table: "SysGenRowTable");
        }
    }
}
