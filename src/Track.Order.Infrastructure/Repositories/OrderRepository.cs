namespace Track.Order.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Track.Order.Api.Contracts.Order;
using Track.Order.Application.Interfaces;
using Track.Order.Domain.Entities;

public class OrderRepository : BaseRepository<Orders, int>, IOrderRepository
{
    private readonly TrackOrderDbContext _dbContext;
    public OrderRepository(TrackOrderDbContext context)
        : base(context)
    { }

    public async Task<IReadOnlyList<Orders>> GetAllAsync()
    {
        return await DbContext.Orders.ToListAsync();
    }


}
