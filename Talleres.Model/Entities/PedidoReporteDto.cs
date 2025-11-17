using System;

namespace Talleres.Model.Entities
{
    public class PedidoReporteDto
    {
        public int IdPedido { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int DiasRestantes { get; set; }
        public string EstadoPedido { get; set; } = string.Empty;
        public string? EstadoProduccion { get; set; }
        public string? ResponsableProduccion { get; set; }
    }
}