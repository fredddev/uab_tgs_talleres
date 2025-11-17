using System;

namespace Talleres.Model.Entities
{
    public class MaterialStockDto
    {
        public string Material { get; set; } = string.Empty;
        public string Unidad { get; set; } = string.Empty;
        public decimal StockActual { get; set; }
        public decimal StockMinimo { get; set; }
    }
}