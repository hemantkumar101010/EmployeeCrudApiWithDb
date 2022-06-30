using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesData.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ClassRooms",
                newName: "ClassName");

            migrationBuilder.AddColumn<long>(
                name: "TeacherMobNumber",
                table: "Teachers",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherMobNumber",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "ClassRooms",
                newName: "Name");
        }
    }
}
