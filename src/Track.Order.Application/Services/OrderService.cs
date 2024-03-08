using Track.Order.Application.Interfaces;
using Track.Order.Common.Models;

namespace Track.Order.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IturriResult> GetOrderByIdAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return IturriResult.Fail(new Common.Errors.IturriError(null, "order_not_found", System.Net.HttpStatusCode.NotFound));

        return IturriResult.Success(order);
    }
}
