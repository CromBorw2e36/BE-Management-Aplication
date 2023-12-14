using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class taoDBMau6SysMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "SysMenu");
        }
    }
}
