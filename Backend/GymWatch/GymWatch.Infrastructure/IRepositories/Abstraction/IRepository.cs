using System.Linq.Expressions;
using GymWatch.Core.Domain.Abstraction;

namespace GymWatch.Infrastructure.IRepositories.Abstraction;

public interface IRepository<TEntity> where TEntity : class, IModel
{
    Task AddAsync(TEntity? entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<List<TEntity?>> GetAllAsync(bool tracked = true);
    Task UpdateAsync(TEntity entity);
    Task SaveChangesAsync();
}