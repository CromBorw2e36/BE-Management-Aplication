using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quan_li_app.Migrations.System
{
    /// <inheritdoc />
    public partial class _09052024_Genergic_Gen_Row_Table_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysGenRowTable",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    table_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caption_VN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    minWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowEditing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowFiltering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowFixing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowGrouping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowHeaderFiltering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowHiding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowSearch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowSorting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autoExpandGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    companyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysGenRowTableid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysGenRowTable", x => x.id);
                    table.ForeignKey(
                        name: "FK_SysGenRowTable_SysGenRowTable_SysGenRowTableid",
                        column: x => x.SysGenRowTableid,
                        principalTable: "SysGenRowTable",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysGenRowTable_SysGenRowTableid",
                table: "SysGenRowTable",
                column: "SysGenRowTableid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysGenRowTable");
        }
    }
}
