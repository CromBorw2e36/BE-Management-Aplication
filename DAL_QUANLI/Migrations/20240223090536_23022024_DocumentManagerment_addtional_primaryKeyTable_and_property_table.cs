using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _23022024_DocumentManagerment_addtional_primaryKeyTable_and_property_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tableName",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "module",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "lenCode",
                table: "DocumentManagement",
                type: "int",
                nullable: true,
                defaultValue: 16,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isCompanyCode",
                table: "DocumentManagement",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "primaryKeyTable",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "primaryKeyTable",
                table: "DocumentManagement");

            migrationBuilder.AlterColumn<string>(
                name: "tableName",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "module",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "lenCode",
                table: "DocumentManagement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 16);

            migrationBuilder.AlterColumn<bool>(
                name: "isCompanyCode",
                table: "DocumentManagement",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);
        }
    }
}
