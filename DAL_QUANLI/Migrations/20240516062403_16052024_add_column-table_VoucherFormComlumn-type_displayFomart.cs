using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _16052024_add_columntable_VoucherFormComlumntype_displayFomart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "displayFormat",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "displayFormat",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "type",
                table: "SysVoucherFormColumn");
        }
    }
}
