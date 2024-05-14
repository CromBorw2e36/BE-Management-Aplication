using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _14052024_update_table_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "SysVoucherFormGroup",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "SysVoucherFormColumn",
                newName: "update_by");

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description1",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description2",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description3",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name1",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name2",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name3",
                table: "SysVoucherFormGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description1",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description2",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description3",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "labelControlCN",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "labelControlVN",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "number_order",
                table: "SysVoucherFormColumn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "update_by",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_by",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "description1",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "description2",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "description3",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "name1",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "name2",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "name3",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "description1",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "description2",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "description3",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "labelControlCN",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "labelControlVN",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "number_order",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "SysGenRowTable");

            migrationBuilder.DropColumn(
                name: "update_by",
                table: "SysGenRowTable");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "SysVoucherFormGroup",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "SysVoucherFormColumn",
                newName: "createBy");
        }
    }
}
