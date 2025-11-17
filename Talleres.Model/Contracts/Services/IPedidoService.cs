using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Services
{
    public interface IPedidoService
    {
        Task<int> CrearPedidoConDetalleAsync(Pedido pedido, IEnumerable<DetallePedido> detalles);

        // Nuevo: obtener reporte de pedidos en proceso
        Task<List<PedidoReporteDto>> ObtenerPedidosEnProcesoAsync();
    }
}