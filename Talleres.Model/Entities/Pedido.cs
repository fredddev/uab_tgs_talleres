using System;

namespace Talleres.Model.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; } = "EN PROCESO";
        public decimal MontoTotal { get; set; }
    }
}