using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWatch.Infrastructure.Migrations
{
    public partial class AddBodyPartEnumToExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyPart",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyPart",
                table: "Exercises");
        }
    }
}
