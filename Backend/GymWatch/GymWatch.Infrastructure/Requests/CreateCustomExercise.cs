namespace GymWatch.Infrastructure.Requests;

public class CreateCustomExercise
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
}