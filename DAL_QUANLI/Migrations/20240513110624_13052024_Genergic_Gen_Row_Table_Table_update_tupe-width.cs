using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _13052024_Genergic_Gen_Row_Table_Table_update_tupewidth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "width",
                table: "SysGenRowTable",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "width",
                table: "SysGenRowTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
