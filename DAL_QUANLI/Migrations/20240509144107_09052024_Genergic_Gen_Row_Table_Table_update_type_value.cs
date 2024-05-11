using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _09052024_Genergic_Gen_Row_Table_Table_update_type_value : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysGenRowTable_SysGenRowTable_SysGenRowTableid",
                table: "SysGenRowTable");

            migrationBuilder.DropIndex(
                name: "IX_SysGenRowTable_SysGenRowTableid",
                table: "SysGenRowTable");

            migrationBuilder.DropColumn(
                name: "SysGenRowTableid",
                table: "SysGenRowTable");

            migrationBuilder.AlterColumn<bool>(
                name: "visible",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "autoExpandGroup",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowSorting",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowSearch",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowHiding",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowHeaderFiltering",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowGrouping",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowFixing",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowFiltering",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "allowEditing",
                table: "SysGenRowTable",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "column_child",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "column_child",
                table: "SysGenRowTable");

            migrationBuilder.AlterColumn<string>(
                name: "visible",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "autoExpandGroup",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowSorting",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowSearch",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowHiding",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowHeaderFiltering",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowGrouping",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowFixing",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowFiltering",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "allowEditing",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SysGenRowTableid",
                table: "SysGenRowTable",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysGenRowTable_SysGenRowTableid",
                table: "SysGenRowTable",
                column: "SysGenRowTableid");

            migrationBuilder.AddForeignKey(
                name: "FK_SysGenRowTable_SysGenRowTable_SysGenRowTableid",
                table: "SysGenRowTable",
                column: "SysGenRowTableid",
                principalTable: "SysGenRowTable",
                principalColumn: "id");
        }
    }
}
