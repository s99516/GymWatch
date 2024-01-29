namespace GymWatch.Infrastructure.DTOs;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsCustom { get; set; }
    public int? UserId { get; set; }
}