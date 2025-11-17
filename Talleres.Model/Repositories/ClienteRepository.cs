using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Entities;

namespace Talleres.Model.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository()
        {
            _connectionString = Database.GetConnectionString();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            const string sql = @"SELECT idCliente, nombre, contacto, telefono FROM Cliente ORDER BY nombre;";
            var list = new List<Cliente>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(new Cliente
                {
                    IdCliente = reader.GetInt32("idCliente"),
                    Nombre = reader.GetString("nombre"),
                    Contacto = reader.IsDBNull(reader.GetOrdinal("contacto")) ? null : reader.GetString("contacto"),
                    Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString("telefono")
                });
            }

            return list;
        }

        public async Task<int> CreateAsync(Cliente cliente)
        {
            const string sql = @"INSERT INTO Cliente (nombre, contacto, telefono)
                                 VALUES (@nombre, @contacto, @telefono);
                                 SELECT LAST_INSERT_ID();";

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@contacto", (object?)cliente.Contacto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono", (object?)cliente.Telefono ?? DBNull.Value);

            var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
            return Convert.ToInt32(result);
        }

        public async Task<Cliente?> GetByIdAsync(int idCliente)
        {
            const string sql = @"SELECT idCliente, nombre, contacto, telefono FROM Cliente WHERE idCliente = @idCliente LIMIT 1;";
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            if (await reader.ReadAsync().ConfigureAwait(false))
            {
                return new Cliente
                {
                    IdCliente = reader.GetInt32("idCliente"),
                    Nombre = reader.GetString("nombre"),
                    Contacto = reader.IsDBNull(reader.GetOrdinal("contacto")) ? null : reader.GetString("contacto"),
                    Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString("telefono")
                };
            }
            return null;
        }
    }
}