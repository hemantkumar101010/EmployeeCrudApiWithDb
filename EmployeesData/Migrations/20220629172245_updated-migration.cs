using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesData.Migrations
{
    public partial class updatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Teachers_TeacherId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Teachers_TeacherId",
                table: "ClassRooms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Teachers_TeacherId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ClassRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Teachers_TeacherId",
                table: "ClassRooms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }
    }
}
