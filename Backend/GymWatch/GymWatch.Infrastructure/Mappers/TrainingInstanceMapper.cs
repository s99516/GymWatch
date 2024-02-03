using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.Mappers;

public static class TrainingInstanceMapper
{
    private readonly static Func<TrainingInstance, TrainingInstanceDto> Map = (trainingInstance) => new TrainingInstanceDto()
    {
        Id = trainingInstance.Id,
        Name = trainingInstance.Name,
        Date = trainingInstance.Date,
        BodyWeight = trainingInstance.BodyWeight,
        State = trainingInstance.State
    };

    public static TrainingInstanceDto ToDto(this TrainingInstance model) => Map(model);

    public static List<TrainingInstanceDto> ToDtoList(this IEnumerable<TrainingInstance> models) =>
        models.Select(Map).ToList();
}