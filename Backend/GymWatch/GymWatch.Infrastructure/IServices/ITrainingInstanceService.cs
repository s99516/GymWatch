﻿using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.IServices;

public interface ITrainingInstanceService
{
    Task<TrainingInstanceDto?> GetByIdAsync(int id);
    Task<IEnumerable<TrainingInstanceDto>> GetByUserAsync(int userId);
    Task<TrainingInstanceDto> CreateTrainingInstanceAsync(CreateTrainingInstanceRequest request);
    Task<int?> FinishTrainingInstanceAsync(int id);
}