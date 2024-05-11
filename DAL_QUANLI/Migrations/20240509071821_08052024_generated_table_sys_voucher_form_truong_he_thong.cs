using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _08052024_generated_table_sys_voucher_form_truong_he_thong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "update_date",
                table: "SysVoucherFormGroup",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "companyCode",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeControl",
                table: "SysVoucherFormColumn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_date",
                table: "SysVoucherFormColumn",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "update_date",
                table: "SysVoucherFormGroup");

            migrationBuilder.DropColumn(
                name: "companyCode",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "typeControl",
                table: "SysVoucherFormColumn");

            migrationBuilder.DropColumn(
                name: "update_date",
                table: "SysVoucherFormColumn");
        }
    }
}
