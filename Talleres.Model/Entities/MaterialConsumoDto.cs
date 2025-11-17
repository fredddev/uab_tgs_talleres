using System;

namespace Talleres.Model.Entities
{
    public class MaterialConsumoDto
    {
        public int IdPedido { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string TipoMovimiento { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; } = string.Empty;
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}