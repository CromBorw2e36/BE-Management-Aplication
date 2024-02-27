using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _23022024_DocumentManagerment_create_new_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentManagement",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    module = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCompanyCode = table.Column<bool>(type: "bit", nullable: true),
                    isClose = table.Column<bool>(type: "bit", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codeLogTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentManagement", x => x.code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentManagement");
        }
    }
}
