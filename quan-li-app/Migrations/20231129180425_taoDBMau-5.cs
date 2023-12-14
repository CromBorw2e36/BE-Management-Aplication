using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class taoDBMau5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentJobPosition",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modyfiBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentOrTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    positionAndLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currentProjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    goalsAndDevelopment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentJobPosition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermissions",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAndBenefits",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modyfiBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wagesAndPerks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compensationPackageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    compensationPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compensationPackageAmount1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    compensationPackage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compensationPackageAmount2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    compensationPackage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compensationPackageAmount3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    compensationPackage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insuranceCoverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowancesAndAidsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    allowancesAndAids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowancesAndAidsAmount1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    allowancesAndAids1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowancesAndAidsAmount2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    allowancesAndAids2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowancesAndAidsAmount3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    allowancesAndAids3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAndBenefits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfomation",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BHXH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfomation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modyfiBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyAndPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workHistoryStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workHistoryEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    timeWorked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobdeScription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    achievementSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reasonForChange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentJobPosition");

            migrationBuilder.DropTable(
                name: "MenuPermissions");

            migrationBuilder.DropTable(
                name: "SalaryAndBenefits");

            migrationBuilder.DropTable(
                name: "UserInfomation");

            migrationBuilder.DropTable(
                name: "WorkHistory");
        }
    }
}
