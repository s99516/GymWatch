using GymWatch.Core.Domain.Enums;

namespace GymWatch.Infrastructure.DTOs;

public record CreateOrUpdateExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public BodyPart BodyPart { get; set; }
    public int UserId { get; set; }
};