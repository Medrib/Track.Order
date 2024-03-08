namespace Track.Order.Application.Interfaces;

public interface IBaseRespository<TEntity, TEntityId>
    where TEntity : class
    where TEntityId : struct
{
    Task<TEntity?> GetByIdAsync(TEntityId id);

    Task<IReadOnlyList<TEntity>> GetAllAsync();

    Task<TEntity?> AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
