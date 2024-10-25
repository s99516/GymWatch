namespace GymWatch.Infrastructure.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime DateCreated { get; set; }

    public List<TrainingInstanceDto> TrainingInstances { get; set; }
    public List<ExerciseDto> Exercises { get; set; }
}