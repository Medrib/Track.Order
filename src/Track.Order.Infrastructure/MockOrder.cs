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
                FechaDeCreacion = "13/05",
                Estado = "facturado",
                NoMaterial= "4005478550-400",
                Cliente = "123",
                Empleado ="lalala",
                Lote = "123",
                NoPedido ="lalal"

            },
            new()
            {
                Id= 2,
                FechaDeCreacion = "12/05",
                Estado = "finalizado",
                NoMaterial= "4005478550-500",
                Cliente = "123",
                Empleado =" ",
                Lote = "123",
                 NoPedido ="lalal"
            },
            new()
            {   Id= 3,
                FechaDeCreacion = "12/06",
                Estado = "facturado",
                NoMaterial= "4005478550-600",
                Cliente = "123",
                Empleado ="  ",
                Lote = "123",
                NoPedido ="lalal"
            },
            new()
            {
                Id = 4,
                FechaDeCreacion = "12/07",
                Estado = "cancelado",
                NoMaterial= "4005478550-700",
                Cliente = "123",
                Empleado =" ",
                Lote = "123",
                NoPedido ="lalal"
            },
            new()
            {
                 Id = 5,
                FechaDeCreacion = "12/08",
                Estado = "pendiente",
                NoMaterial= "4005478550-800",
                Cliente = "123",
                Empleado =" ",
                Lote = "123",
                NoPedido ="lalal"
            },
        };

}

