using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMVCBasicCURD.Migrations
{
    public partial class ColumnnamechangeinTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FulllNmae",
                table: "Employees",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employees",
                newName: "FulllNmae");
        }
    }
}
