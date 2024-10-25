using GymWatch.Core.Domain.Abstraction;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IModel
{
    private readonly GymWatchDbContext _context;
    private readonly DbSet<TEntity?> _dbSet;

    public Repository(GymWatchDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public async Task AddAsync(TEntity? entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity?>> GetAllAsync(bool tracked = true)
    {
        IQueryable<TEntity?> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }
        
        return await query.ToListAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}