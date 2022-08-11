using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_CRUD_API.Migrations
{
    public partial class ConnectDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    EmployeeName = table.Column<string>(type: "text", nullable: true),
                    EmployeeAddress = table.Column<string>(type: "text", nullable: true),
                    EmployeeTelp = table.Column<string>(type: "text", nullable: true),
                    EmployeeSalary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EmployeeImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
