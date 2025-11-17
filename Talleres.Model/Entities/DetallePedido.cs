namespace Talleres.Model.Entities
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? Observaciones { get; set; }
    }
}