
using System.ComponentModel.DataAnnotations;

namespace Track.Order.Domain.Entities
{
    public class Orders
    {

        [Key]
        public int idOrder { get; set; }
        public int nroMaterialClie { get; set; }
        public int nroMaterialIturri { get; set; }
        public string descripcion { get; set; }
        public string nroAlbaran { get; set; }
        public int ctdPedida { get; set; }
        public int ctdEntrega { get; set; }
        public int ctdPendiente { get; set; }
        public string unidad { get; set; }
        public int idEstado { get; set; }
        public int idUsuario { get; set; }
        public int nroExpedicion { get; set; }
        public string destinoMercancia { get; set; }
        public string nroFactura { get; set; }


    }
}
