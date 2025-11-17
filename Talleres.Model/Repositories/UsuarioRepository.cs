using System;
using System.Threading.Tasks;
using MySqlConnector;
using Talleres.Model.Entities;
using Talleres.Model.Contracts.Repositories;

namespace Talleres.Model.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository()
        {
            _connectionString = Database.GetConnectionString();
        }

        public async Task<Usuario?> GetByNombreUsuarioAsync(string nombreUsuario)
        {
            const string sql = @"SELECT idUsuario, nombreUsuario, contrasena, rol
                                 FROM Usuario
                                 WHERE nombreUsuario = @nombreUsuario
                                 LIMIT 1;";

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

            await using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            if (await reader.ReadAsync().ConfigureAwait(false))
            {
                return new Usuario
                {
                    IdUsuario = reader.GetInt32("idUsuario"),
                    NombreUsuario = reader.GetString("nombreUsuario"),
                    Contrasena = reader.GetString("contrasena"),
                    Rol = reader.GetString("rol")
                };
            }

            return null;
        }

        public async Task<int> CreateAsync(Usuario usuario)
        {
            const string sql = @"INSERT INTO Usuario (nombreUsuario, contrasena, rol)
                                 VALUES (@nombreUsuario, @contrasena, @rol);
                                 SELECT LAST_INSERT_ID();";

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);

            var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
            return Convert.ToInt32(result);
        }
    }
}