using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.Mappers;

public static class UserMapper
{
    private readonly static Func<User, UserDto> Map = (user) => new UserDto()
    {
        Id = user.Id,
        Email = user.Email,
        DateCreated = user.DateCreated
    };

    public static UserDto ToDto(this User model) => Map(model);

    public static List<UserDto> ToDtoList(this IEnumerable<User> models) =>
        models.Select(Map).ToList();
}