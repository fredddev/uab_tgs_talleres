using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Repositories
{
    public interface IPedidoRepository
    {
        Task<int> CreatePedidoAsync(Pedido pedido);
        Task CreateDetalleAsync(DetallePedido detalle);
        Task<List<PedidoReporteDto>> GetPedidosEnProcesoAsync();
        Task<List<PedidoEntregadoDto>> GetPedidosEntregadosAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}