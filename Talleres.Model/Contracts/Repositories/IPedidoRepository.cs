using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Repositories
{
    public interface IPedidoRepository
    {
        Task<int> CreatePedidoAsync(Pedido pedido);
        Task CreateDetalleAsync(DetallePedido detalle);

        // Nuevo: obtener pedidos en proceso/pendientes con info de producción (LEFT JOIN)
        Task<List<PedidoReporteDto>> GetPedidosEnProcesoAsync();
    }
}