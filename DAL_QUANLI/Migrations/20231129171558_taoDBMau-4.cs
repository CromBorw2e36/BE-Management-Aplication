using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations
{
    /// <inheritdoc />
    public partial class taoDBMau4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    account = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    createdate = table.Column<DateTime>(name: "create_date", type: "datetime2", nullable: true),
                    lockdate = table.Column<DateTime>(name: "lock_date", type: "datetime2", nullable: true),
                    lastenter = table.Column<DateTime>(name: "last_enter", type: "datetime2", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeaccount = table.Column<string>(name: "type_account", type: "nvarchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
