using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _23022024_DocumentManagerment_addtional_len_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lenCode",
                table: "DocumentManagement",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lenCode",
                table: "DocumentManagement");
        }
    }
}
