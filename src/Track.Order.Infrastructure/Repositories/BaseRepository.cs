namespace Track.Order.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Track.Order.Application.Interfaces;

public class BaseRepository<TEntity, TEntityId> : IBaseRespository<TEntity, TEntityId>
    where TEntity : class
    where TEntityId : struct
{
    public BaseRepository(TrackOrderDbContext dbContext)
    => DbContext = dbContext;

    protected TrackOrderDbContext DbContext {  get; }

    public virtual async Task<TEntity?> GetByIdAsync(TEntityId id)
        => await DbContext.Set<TEntity>().FindAsync(id);

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync()
        => await DbContext.Set<TEntity>().ToListAsync();

    public virtual async Task<TEntity?> AddAsync(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        DbContext.ChangeTracker.Clear();
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }
}
