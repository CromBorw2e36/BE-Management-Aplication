using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class taoDBMau6bongsungtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "browser",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "browser_version",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "connectionSignalID",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "device",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ip_address",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_android",
                table: "Token",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_desktop",
                table: "Token",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_ios",
                table: "Token",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_mobile",
                table: "Token",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_tablet",
                table: "Token",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "latitude",
                table: "Token",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "Token",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orientation",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "os",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "os_version",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_device",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "browser",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "browser_version",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "connectionSignalID",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "device",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "ip_address",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "is_android",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "is_desktop",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "is_ios",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "is_mobile",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "is_tablet",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "orientation",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "os",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "os_version",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "type_device",
                table: "Token");
        }
    }
}
