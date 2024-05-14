using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _13052024_update_type_sys_group_action : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "orderNo",
                table: "SysGroupAction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "orderNo",
                table: "SysGroupAction",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
