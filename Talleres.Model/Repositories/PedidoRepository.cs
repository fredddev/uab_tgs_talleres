using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Entities;

namespace Talleres.Model.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository()
        {
            _connectionString = Database.GetConnectionString();
        }

        public async Task<int> CreatePedidoAsync(Pedido pedido)
        {
            const string sql = @"INSERT INTO Pedido (idCliente, fechaPedido, fechaEntrega, estado, montoTotal)
                                 VALUES (@idCliente, @fechaPedido, @fechaEntrega, @estado, @montoTotal);
                                 SELECT LAST_INSERT_ID();";

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
            cmd.Parameters.AddWithValue("@fechaPedido", pedido.FechaPedido);
            cmd.Parameters.AddWithValue("@fechaEntrega", pedido.FechaEntrega);
            cmd.Parameters.AddWithValue("@estado", pedido.Estado);
            cmd.Parameters.AddWithValue("@montoTotal", pedido.MontoTotal);

            var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
            return Convert.ToInt32(result);
        }

        public async Task CreateDetalleAsync(DetallePedido detalle)
        {
            const string sql = @"INSERT INTO DetallePedido (idPedido, producto, cantidad, precioUnitario, observaciones)
                                 VALUES (@idPedido, @producto, @cantidad, @precioUnitario, @observaciones);";

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idPedido", detalle.IdPedido);
            cmd.Parameters.AddWithValue("@producto", detalle.Producto);
            cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
            cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
            cmd.Parameters.AddWithValue("@observaciones", (object?)detalle.Observaciones ?? DBNull.Value);

            await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        public async Task<List<PedidoReporteDto>> GetPedidosEnProcesoAsync()
        {
            const string sql = @"
                SELECT
                    p.idPedido,
                    c.nombre AS Cliente,
                    p.fechaPedido,
                    p.fechaEntrega,
                    p.estado AS EstadoPedido,
                    pr.estado AS EstadoProduccion,
                    pr.responsable AS ResponsableProduccion
                FROM Pedido p
                INNER JOIN Cliente c ON p.idCliente = c.idCliente
                LEFT JOIN Produccion pr ON p.idPedido = pr.idPedido
                WHERE p.estado IN ('EN PROCESO', 'PENDIENTE')
                ORDER BY p.fechaEntrega ASC;";

            var list = new List<PedidoReporteDto>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                var fechaEntrega = reader.GetDateTime("fechaEntrega");
                var dias = (fechaEntrega - DateTime.Now).Days;

                list.Add(new PedidoReporteDto
                {
                    IdPedido = reader.GetInt32("idPedido"),
                    Cliente = reader.GetString("Cliente"),
                    FechaPedido = reader.GetDateTime("fechaPedido"),
                    FechaEntrega = fechaEntrega,
                    DiasRestantes = dias,
                    EstadoPedido = reader.GetString("EstadoPedido"),
                    EstadoProduccion = reader.IsDBNull(reader.GetOrdinal("EstadoProduccion")) ? null : reader.GetString("EstadoProduccion"),
                    ResponsableProduccion = reader.IsDBNull(reader.GetOrdinal("ResponsableProduccion")) ? null : reader.GetString("ResponsableProduccion")
                });
            }

            return list;
        }

        public async Task<List<PedidoEntregadoDto>> GetPedidosEntregadosAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            const string sql = @"
                SELECT
                    p.idPedido,
                    c.nombre AS Cliente,
                    p.fechaPedido,
                    p.fechaEntrega,
                    p.montoTotal,
                    COUNT(d.idDetalle) AS NumeroItems
                FROM Pedido p
                INNER JOIN Cliente c ON p.idCliente = c.idCliente
                LEFT JOIN DetallePedido d ON p.idPedido = d.idPedido
                WHERE p.estado = 'ENTREGADO' AND p.fechaEntrega BETWEEN @inicio AND @fin
                GROUP BY p.idPedido, c.nombre, p.fechaPedido, p.fechaEntrega, p.montoTotal
                ORDER BY p.fechaEntrega ASC;";

            var list = new List<PedidoEntregadoDto>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@inicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fin", fechaFin);

            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(new PedidoEntregadoDto
                {
                    IdPedido = reader.GetInt32("idPedido"),
                    Cliente = reader.GetString("Cliente"),
                    FechaPedido = reader.GetDateTime("fechaPedido"),
                    FechaEntrega = reader.GetDateTime("fechaEntrega"),
                    MontoTotal = reader.GetDecimal("montoTotal"),
                    NumeroItems = reader.GetInt32("NumeroItems"),
                    UsuarioResponsable = null
                });
            }

            return list;
        }
    }
}