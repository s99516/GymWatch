﻿using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.IServices;

public interface IExerciseService
{
    Task<int> AddCustomExercise(CreateCustomExercise request);
    Task<int> EditCustomExercise(EditCustomExerciseRequest request);
    Task DeleteCustomExerciseAsync(int id);
}