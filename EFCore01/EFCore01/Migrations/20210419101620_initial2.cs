using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore01.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployrrId",
                table: "Employees",
                newName: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployrrId");
        }
    }
}
