namespace Track.Order.Infrastructure.Repositories;

using Track.Order.Application.Interfaces;
using Track.Order.Domain.Entities;

public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
{
    public OrderRepository(TrackOrderDbContext context)
        : base(context)
    { }

    public override Task<Order?> GetByIdAsync(int id)
    {
        var order = MockOrder.GetByIdAsync(id);
        return Task.FromResult<Order?>(order);
    }

    public override Task<IReadOnlyList<Order>> GetAllAsync()
    {
        var orders = MockOrder.GetAllAsync();
        return Task.FromResult<IReadOnlyList<Order>>(orders);
    }
}
