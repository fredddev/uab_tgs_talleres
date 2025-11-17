using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Contracts.Services;
using Talleres.Model.Entities;
using Talleres.Model.Repositories;

namespace Talleres.Model.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepo;

        public PedidoService(IPedidoRepository? pedidoRepo = null)
        {
            _pedidoRepo = pedidoRepo ?? new PedidoRepository();
        }

        public async Task<int> CrearPedidoConDetalleAsync(Pedido pedido, IEnumerable<DetallePedido> detalles)
        {
            var idPedido = await _pedidoRepo.CreatePedidoAsync(pedido).ConfigureAwait(false);
            foreach (var d in detalles)
            {
                d.IdPedido = idPedido;
                await _pedidoRepo.CreateDetalleAsync(d).ConfigureAwait(false);
            }
            return idPedido;
        }

        public async Task<List<PedidoReporteDto>> ObtenerPedidosEnProcesoAsync()
        {
            return await _pedidoRepo.GetPedidosEnProcesoAsync().ConfigureAwait(false);
        }

        public async Task<List<PedidoEntregadoDto>> ObtenerPedidosEntregadosAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _pedidoRepo.GetPedidosEntregadosAsync(fechaInicio, fechaFin).ConfigureAwait(false);
        }
    }
}