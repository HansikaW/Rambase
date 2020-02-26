using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BDay",
                table: "EmployeeDetails",
                type: "Nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BDay",
                table: "EmployeeDetails",
                type: "Nvarchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(10)");
        }
    }
}
