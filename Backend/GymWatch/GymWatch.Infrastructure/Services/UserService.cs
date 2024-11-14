using FluentValidation;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.IServices.Enryption;
using GymWatch.Infrastructure.Mappers;
using GymWatch.Infrastructure.Validators;

namespace GymWatch.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncrypter _encrypter;
    private readonly UserValidator _userValidator;

    public UserService(IUserRepository userRepository, IEncrypter encrypter, UserValidator userValidator)
    {
        _userRepository = userRepository;
        _encrypter = encrypter;
        _userValidator = userValidator;
    }
    
    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        var result = user?.ToDto();
        return result;
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        var result = user?.ToDto();
        return result;
    }

    public async Task<UserDto> RegisterAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is not null) throw new Exception($@"User with email {email} already exist.");

        var (hash, salt) = _encrypter.GetHashAndSalt(password);

        user = new User(email, hash, salt);

        await _userValidator.ValidateAndThrowAsync(user);
        
        await _userRepository.AddAsync(user);

        return user.ToDto();
    }

    public async Task<UserDto> UpdateUserAsync(int id, string email, string password)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user is null) throw new Exception($@"User with id {id} does not exist.");

        var (hash, _) = _encrypter.GetHashAndSalt(password);
        
        user.Update(email, hash);
        
        await _userValidator.ValidateAndThrowAsync(user);
        
        await _userRepository.SaveChangesAsync();
        
        return user.ToDto();
    }

    public async Task LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null) throw new Exception("Invalid credentials.");

        var hash = _encrypter.GetHash(password, user.PasswordSalt);
        
        if (user.Password == hash) return;
        throw new Exception("Invalid credentials");
    }

    public async Task<int?> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        user?.Delete();
        
        await _userRepository.SaveChangesAsync();

        return user?.Id;
    }
}