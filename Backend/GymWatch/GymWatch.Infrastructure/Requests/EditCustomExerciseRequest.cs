namespace GymWatch.Infrastructure.Requests;

public class EditCustomExerciseRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}