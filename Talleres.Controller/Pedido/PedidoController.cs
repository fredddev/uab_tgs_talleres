using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Contracts.Services;
using Talleres.Model.Entities;

namespace Talleres.Controller.Pedidos
{
    public class PedidoController
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService? pedidoService = null)
        {
            _pedidoService = pedidoService ?? new Talleres.Model.Services.PedidoService();
        }

        public async Task<int> GuardarPedidoAsync(Pedido pedido, IEnumerable<DetallePedido> detalles)
        {
            return await _pedidoService.CrearPedidoConDetalleAsync(pedido, detalles).ConfigureAwait(false);
        }

        public async Task<List<PedidoReporteDto>> ObtenerPedidosEnProcesoAsync()
        {
            return await _pedidoService.ObtenerPedidosEnProcesoAsync().ConfigureAwait(false);
        }

        public async Task<List<PedidoEntregadoDto>> ObtenerPedidosEntregadosAsync(DateTime inicio, DateTime fin)
        {
            return await _pedidoService.ObtenerPedidosEntregadosAsync(inicio, fin).ConfigureAwait(false);
        }

        public async Task<List<MaterialConsumoDto>> ObtenerConsumoMaterialAsync(int? idPedido = null, DateTime? inicio = null, DateTime? fin = null)
        {
            return await _pedidoService.ObtenerConsumoMaterialAsync(idPedido, inicio, fin).ConfigureAwait(false);
        }
    }
}