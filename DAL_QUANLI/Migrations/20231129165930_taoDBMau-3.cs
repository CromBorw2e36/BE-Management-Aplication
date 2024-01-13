using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations
{
    /// <inheritdoc />
    public partial class taoDBMau3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    menuid = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    isParent = table.Column<bool>(type: "bit", nullable: false),
                    menuIDParent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    moduleApp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.menuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysMenu");
        }
    }
}
