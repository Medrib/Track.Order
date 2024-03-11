namespace Track.Order.Api.Contracts.Order;

public class OrderResponse
{
    public int Id { get; set; }
    public string FechaDeCreacion { get; set; } = string.Empty;
    public string Estado { get; set; }
    public string NoMaterial { get; set; }
    public string Cliente { get; set; }
    public string Empleado { get; set; }
    public string Lote { get; set; }
    public string NoPedido { get; set; }
}
