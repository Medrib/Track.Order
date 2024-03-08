namespace Track.Order.Infrastructure;

using Track.Order.Domain.Entities;
public static class MockOrder
{
    public static Order? GetByIdAsync(int id)
    {
        var orders = GetAllAsync();

        return orders.Find(o => o.Id == id);
    }

    public static List<Order> GetAllAsync()
        => new List<Order>()
        {
            new()
            {
                Id = 1,
                Name = "track-order-1",
            },
            new()
            {
                Id = 2,
                Name = "track-order-2",
            },
            new()
            {
                Id = 3,
                Name = "track-order-3",
            },
            new()
            {
                Id = 3,
                Name = "track-order-3",
            },
            new()
            {
                Id = 4,
                Name = "track-order-4",
            },
        };

}
