﻿using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories.Abstraction;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.IRepositories;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<IEnumerable<Exercise>> GetDefaultExercisesAsync();
    Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId);
    Task<int> AddAsync(Exercise exercise);
    Task<int> EditAsync(EditCustomExerciseRequest request);
    Task DeleteAsync(int id);
}