using GymWatch.Core.Domain.Enums;

namespace GymWatch.Infrastructure.DTOs;

public class TrainingInstanceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public double? BodyWeight { get; set; }
    public TrainingState State { get; set; }
}