using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _23022024_DocumentManagerment_remove_primarykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentManagement",
                table: "DocumentManagement");

            migrationBuilder.AlterColumn<bool>(
                name: "isClose",
                table: "DocumentManagement",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "DocumentManagement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isClose",
                table: "DocumentManagement",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "DocumentManagement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentManagement",
                table: "DocumentManagement",
                column: "code");
        }
    }
}
