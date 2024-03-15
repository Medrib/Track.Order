using Track.Order.Api.Contracts.Order.SearchOrders;
using Track.Order.Common.Models;
using Track.Order.Domain.Entities;

namespace Track.Order.Application.Interfaces;

public interface IOrderService
{
    Task<IturriResult> GetAllOrderAsync();
    Task<IturriResult> SearchOrdersAsync(Filters filters);

}
