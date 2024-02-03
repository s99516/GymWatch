using GymWatch.Core.Domain.Enums;

namespace GymWatch.Infrastructure.Requests;

public record CreateTrainingInstanceRequest
{
    public string Name { get; set; }
    public double? BodyWeight { get; set; }
    public TrainingState State { get; set; }
    public int UserId { get; set; }
}