using Track.Order.Common.Models;

namespace Track.Order.Application.Interfaces;

public interface IOrderService
{
    Task<IturriResult> GetOrderByIdAsync(int orderId);
}
