using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _27022024_create_module_action : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysAction",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nameVn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDisable = table.Column<bool>(type: "bit", nullable: true),
                    isClocked = table.Column<bool>(type: "bit", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url_4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysAction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SysDropDownAction",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codeAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SysGroupAction",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codeAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysAction");

            migrationBuilder.DropTable(
                name: "SysDropDownAction");

            migrationBuilder.DropTable(
                name: "SysGroupAction");
        }
    }
}
