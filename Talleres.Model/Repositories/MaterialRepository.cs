using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Entities;

namespace Talleres.Model.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly string _connectionString;

        public MaterialRepository()
        {
            _connectionString = Database.GetConnectionString();
        }

        public async Task<List<MaterialStockDto>> GetMaterialesStockAsync(bool soloBajoMinimo = true)
        {
            var sql = @"
                SELECT nombre, unidad, stockActual, stockMinimo
                FROM Material
            ";

            if (soloBajoMinimo)
                sql += " WHERE stockActual <= stockMinimo ";

            sql += " ORDER BY nombre;";

            var list = new List<MaterialStockDto>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(new MaterialStockDto
                {
                    Material = reader.GetString("nombre"),
                    Unidad = reader.IsDBNull(reader.GetOrdinal("unidad")) ? string.Empty : reader.GetString("unidad"),
                    StockActual = reader.GetDecimal("stockActual"),
                    StockMinimo = reader.GetDecimal("stockMinimo")
                });
            }

            return list;
        }
    }
}