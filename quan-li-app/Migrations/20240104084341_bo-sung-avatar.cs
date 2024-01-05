using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class bosungavatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar16",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar32",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar64",
                table: "UserInfomation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "avatar16",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "avatar32",
                table: "UserInfomation");

            migrationBuilder.DropColumn(
                name: "avatar64",
                table: "UserInfomation");
        }
    }
}
