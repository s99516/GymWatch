using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWatch.Infrastructure.Migrations
{
    public partial class AddDefaultExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         migrationBuilder.Sql(@"
                                 INSERT INTO [dbo].[Exercises]
                                 (
                                  [Name], [Description], [DateCreated], [IsCustom], [UserId], [BodyPart]
                                 )
                                 VALUES
                                 (
                                  'Martwy ciąg', '-', GETDATE(), 0, NULL, 7
                                 ),
                                 (
                                  'Wyciskanie sztangi na ławce płaskiej', '-', GETDATE(), 0, NULL, 1
                                 ),
                                 (
                                  'Wiosłowanie sztangą w opadzie', '-', GETDATE(), 0, NULL, 7
                                 ),
                                 (
                                  'Podciąganie na drążku', '-', GETDATE(), 0, NULL, 7
                                 ),
                                 (
                                  'Wyciskanie hantli na ławce skośnej', '-', GETDATE(), 0, NULL, 1
                                 ),
                                 (
                                  'Uginanie ramion z hantlami', '-', GETDATE(), 0, NULL, 3
                                 ),
                                 (
                                  'Prostowanie ramion na wyciągu', '-', GETDATE(), 0, NULL, 4
                                 ),
                                 (
                                  'Przysiad ze sztangą', '-', GETDATE(), 0, NULL, 6
                                 ),
                                 (
                                  'Rozpiętki z hantlami', '-', GETDATE(), 0, NULL, 1
                                 ),
                                 (
                                  'Wznosy hatli bokiem', '-', GETDATE(), 0, NULL, 2
                                 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
