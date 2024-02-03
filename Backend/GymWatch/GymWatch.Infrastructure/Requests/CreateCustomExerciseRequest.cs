namespace GymWatch.Infrastructure.Requests;

public record CreateCustomExerciseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
}