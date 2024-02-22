using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories.Abstraction;

namespace GymWatch.Infrastructure.IRepositories;

public interface IUserRepository : IRepository<User> { }