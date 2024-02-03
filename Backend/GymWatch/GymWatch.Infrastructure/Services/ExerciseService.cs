using System.Data;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.Services;

public class ExerciseService : IExerciseService
{
    private readonly IUserRepository _userRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IUserRepository userRepository, IExerciseRepository exerciseRepository)
    {
        _userRepository = userRepository;
        _exerciseRepository = exerciseRepository;
    }
    
    public async Task<int> AddCustomExercise(CreateCustomExerciseRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null) throw new Exception($"Cannot find user with id {request.UserId} to add custom exercise");

        var exercise = new Exercise(request.Name, request.Description, true, user);

        return await _exerciseRepository.AddAsync(exercise);
    }

    public async Task<int> EditCustomExercise(EditCustomExerciseRequest request)
    {
        var id = await _exerciseRepository.EditAsync(request);
        return id;
    }

    public async Task DeleteCustomExerciseAsync(int id)
    {
        await _exerciseRepository.DeleteAsync(id);
    }
}