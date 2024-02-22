using GymWatch.Core.Domain.Abstraction;

namespace GymWatch.Infrastructure.IRepositories.Abstraction;

public interface IRepository<TEntity> where TEntity : IModel<int>
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<int> AddAsync(TEntity entity);
}