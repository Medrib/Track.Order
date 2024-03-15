namespace Track.Order.Api.Contracts.Order.SearchOrders
{
    public class Filters
    {
        public int? IdOrder { get; set; }
        public int? NroMaterialClie { get; set; }
        public int? NroMaterialIturri { get; set; }
        public string? Descripcion { get; set; }
        public string? NroAlbaran { get; set; }
        public int? CtdPedida { get; set; }
        public int? CtdEntrega { get; set; }
        public int? CtdPendiente { get; set; }
        public string? Unidad { get; set; }
        public int? IdEstado { get; set; }
        public int? IdUsuario { get; set; }
        public int? NroExpedicion { get; set; }
        public string? DestinoMercancia { get; set; }
        public string? NroFactura { get; set; }
    }
}

