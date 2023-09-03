using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations
{
    public partial class AddStudentGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_StudentTeacherId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentTeacherId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentTeacherId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "StudentTeacherId",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentTeacherId",
                table: "Grades",
                column: "StudentTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_StudentTeacherId",
                table: "Grades",
                column: "StudentTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }
    }
}
