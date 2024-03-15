using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.IServices.Enryption;
using GymWatch.Infrastructure.Mappers;

namespace GymWatch.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncrypter _encrypter;

    public UserService(IUserRepository userRepository, IEncrypter encrypter)
    {
        _userRepository = userRepository;
        _encrypter = encrypter;
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

    public async Task<int> RegisterAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user != null) throw new Exception($@"User with email {email} already exist.");

        var salt = _encrypter.GetSalt(password);
        var hash = _encrypter.GetHash(password, salt);

        user = new User(email, hash, salt);

        await _userRepository.AddAsync(user);

        return user.Id;
    }

    public async Task LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null) throw new Exception("Invalid credentials.");

        var hash = _encrypter.GetHash(password, user.PasswordSalt);
        
        if (user.Password == hash) return;
        throw new Exception("Invalid credentials");
    }
}