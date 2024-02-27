using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _27022024_create_module_action_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysAction",
                table: "SysAction");

            migrationBuilder.DropColumn(
                name: "id",
                table: "SysAction");

            migrationBuilder.DropColumn(
                name: "isClocked",
                table: "SysAction");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "SysMenu",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action1",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action2",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action3",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action4",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action5",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action6",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action7",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isClocked",
                table: "SysGroupAction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isClocked",
                table: "SysDropDownAction",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "isDisable",
                table: "SysAction",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "actionCode",
                table: "SysAction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysAction",
                table: "SysAction",
                column: "actionCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysAction",
                table: "SysAction");

            migrationBuilder.DropColumn(
                name: "action1",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action2",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action3",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action4",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action5",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action6",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "action7",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "isClocked",
                table: "SysGroupAction");

            migrationBuilder.DropColumn(
                name: "isClocked",
                table: "SysDropDownAction");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "SysMenu",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isDisable",
                table: "SysAction",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "actionCode",
                table: "SysAction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "SysAction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isClocked",
                table: "SysAction",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysAction",
                table: "SysAction",
                column: "id");
        }
    }
}
