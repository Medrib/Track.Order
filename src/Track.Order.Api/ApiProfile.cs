namespace Track.Order.Api;

using Track.Order.Api.Contracts.Order;
using Track.Order.Domain.Entities;
using AutoMapper;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Order, OrderResponse>();

    }
}
