using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Services
{
    public interface IPedidoService
    {
        Task<int> CrearPedidoConDetalleAsync(Pedido pedido, IEnumerable<DetallePedido> detalles);
        Task<List<PedidoReporteDto>> ObtenerPedidosEnProcesoAsync();
        Task<List<PedidoEntregadoDto>> ObtenerPedidosEntregadosAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}