using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.Mappers;

public static class ExerciseMapper
{
    private static readonly Func<Exercise, ExerciseDto> Map = (exercise) => new ExerciseDto
    {
        Id = exercise.Id,
        Name = exercise.Name,
        Description = exercise.Description ?? "",
        BodyPart = exercise.BodyPart,
        DateCreated = exercise.DateCreated,
        IsCustom = exercise.IsCustom,
        UserId = exercise.UserId
    };

    public static ExerciseDto ToDto(this Exercise model) => Map(model);

    public static List<ExerciseDto> ToDtoList(this IEnumerable<Exercise> models) => models.Select(Map).ToList();
}