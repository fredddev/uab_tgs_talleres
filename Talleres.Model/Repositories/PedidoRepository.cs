using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<MaterialConsumoDto>> GetConsumoMaterialAsync(int? idPedido = null, DateTime? inicio = null, DateTime? fin = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"SELECT
                                p.idPedido,
                                c.nombre AS Cliente,
                                m.nombre AS Material,
                                im.tipo AS TipoMovimiento,
                                im.cantidad AS Cantidad,
                                m.unidad AS Unidad,
                                m.costoUnitario AS CostoUnitario,
                                im.fecha AS FechaMovimiento
                            FROM InventarioMovimiento im
                            INNER JOIN Material m ON im.idMaterial = m.idMaterial
                            INNER JOIN Pedido p ON im.idPedido = p.idPedido
                            INNER JOIN Cliente c ON p.idCliente = c.idCliente
                            WHERE 1 = 1");

            if (idPedido.HasValue) sb.AppendLine(" AND im.idPedido = @idPedido");
            if (inicio.HasValue) sb.AppendLine(" AND im.fecha >= @inicio");
            if (fin.HasValue) sb.AppendLine(" AND im.fecha <= @fin");

            sb.AppendLine(" ORDER BY p.idPedido, im.fecha ASC;");

            var list = new List<MaterialConsumoDto>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sb.ToString(), conn);

            if (idPedido.HasValue) cmd.Parameters.AddWithValue("@idPedido", idPedido.Value);
            if (inicio.HasValue) cmd.Parameters.AddWithValue("@inicio", inicio.Value);
            if (fin.HasValue) cmd.Parameters.AddWithValue("@fin", fin.Value);

            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                var cantidad = reader.GetDecimal("Cantidad");
                var costoUnitario = reader.GetDecimal("CostoUnitario");
                list.Add(new MaterialConsumoDto
                {
                    IdPedido = reader.GetInt32("idPedido"),
                    Cliente = reader.GetString("Cliente"),
                    Material = reader.GetString("Material"),
                    TipoMovimiento = reader.GetString("TipoMovimiento"),
                    Cantidad = cantidad,
                    Unidad = reader.IsDBNull(reader.GetOrdinal("Unidad")) ? string.Empty : reader.GetString("Unidad"),
                    CostoUnitario = costoUnitario,
                    CostoTotal = cantidad * costoUnitario,
                    FechaMovimiento = reader.GetDateTime("FechaMovimiento")
                });
            }

            return list;
        }
    }
}