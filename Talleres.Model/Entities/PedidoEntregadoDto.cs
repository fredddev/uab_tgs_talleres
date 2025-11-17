using System;

namespace Talleres.Model.Entities
{
    public class PedidoEntregadoDto
    {
        public int IdPedido { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal MontoTotal { get; set; }
        public int NumeroItems { get; set; }
        public string? UsuarioResponsable { get; set; }
    }
}