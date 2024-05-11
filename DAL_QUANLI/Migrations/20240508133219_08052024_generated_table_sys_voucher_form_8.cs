using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _08052024_generated_table_sys_voucher_form_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysVoucherFormColumn",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    labelModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edit = table.Column<bool>(type: "bit", nullable: true),
                    labelControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    labelRequired = table.Column<bool>(type: "bit", nullable: true),
                    visible = table.Column<bool>(type: "bit", nullable: true),
                    disabled = table.Column<bool>(type: "bit", nullable: true),
                    readOnly = table.Column<bool>(type: "bit", nullable: true),
                    required = table.Column<bool>(type: "bit", nullable: true),
                    showClearButton = table.Column<bool>(type: "bit", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maskRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    groupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysVoucherFormColumn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SysVoucherFormGroup",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number_order = table.Column<int>(type: "int", nullable: true),
                    group_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysVoucherFormGroup", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysVoucherFormColumn");

            migrationBuilder.DropTable(
                name: "SysVoucherFormGroup");
        }
    }
}
