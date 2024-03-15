using System.Linq.Expressions;
using Track.Order.Api.Contracts.Order.SearchOrders;
using Track.Order.Application.Interfaces;
using Track.Order.Common.Models;
using Track.Order.Domain.Entities;

namespace Track.Order.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<IturriResult> GetAllOrderAsync()
    {
        var order = await _orderRepository.GetAllAsync();

        if (order is null)
            return IturriResult.Fail(new Common.Errors.IturriError(null, "order_not_found", System.Net.HttpStatusCode.NotFound));

        return IturriResult.Success(order);
    }

    public async Task<IturriResult> SearchOrdersAsync(Filters filters)
    {
        Expression<Func<Orders, bool>> filter = BuildFilter(filters);
        var ordersFiltered = await _orderRepository.SearchAsync(filter);

        return IturriResult.Success(ordersFiltered);
    }

    public static Expression<Func<Orders, bool>> BuildFilter(Filters filters)
    {
        Expression<Func<Orders, bool>> filter = x => true;

        if (filters.IdOrder != null)
            filter = CombineFilter(filter, x => x.idOrder == filters.IdOrder);
        if (filters.NroMaterialClie != null)
            filter = CombineFilter(filter, x => x.nroMaterialClie == filters.NroMaterialClie);
        if (filters.NroMaterialIturri != null)
            filter = CombineFilter(filter, x => x.nroMaterialIturri == filters.NroMaterialIturri);
        if (filters.Descripcion != null)
            filter = CombineFilter(filter, x => x.descripcion == filters.Descripcion);
        if (filters.NroAlbaran != null)
            filter = CombineFilter(filter, x => x.nroAlbaran == filters.NroAlbaran);
        if (filters.CtdPedida != null)
            filter = CombineFilter(filter, x => x.ctdPedida == filters.CtdPedida);
        if (filters.CtdEntrega != null)
            filter = CombineFilter(filter, x => x.ctdEntrega == filters.CtdEntrega);
        if (filters.CtdPendiente != null)
            filter = CombineFilter(filter, x => x.ctdPendiente == filters.CtdPendiente);
        if (filters.Unidad != null)
            filter = CombineFilter(filter, x => x.unidad == filters.Unidad);
        if (filters.IdEstado != null)
            filter = CombineFilter(filter, x => x.idEstado == filters.IdEstado);
        if (filters.IdUsuario != null)
            filter = CombineFilter(filter, x => x.idUsuario == filters.IdUsuario);
        if (filters.NroExpedicion != null)
            filter = CombineFilter(filter, x => x.nroExpedicion == filters.NroExpedicion);
        if (filters.DestinoMercancia != null)
            filter = CombineFilter(filter, x => x.destinoMercancia == filters.DestinoMercancia);
        if (filters.NroFactura != null)
            filter = CombineFilter(filter, x => x.nroFactura == filters.NroFactura);

        return filter;
    }

    private static Expression<Func<Orders, bool>> CombineFilter(
         Expression<Func<Orders, bool>> existingFilter, Expression<Func<Orders, bool>> newFilter)
    {
        var parameter = Expression.Parameter(typeof(Orders));

        var body = Expression.AndAlso(
            Expression.Invoke(existingFilter, parameter),
            Expression.Invoke(newFilter, parameter));

        return Expression.Lambda<Func<Orders, bool>>(body, parameter);
    }
}
