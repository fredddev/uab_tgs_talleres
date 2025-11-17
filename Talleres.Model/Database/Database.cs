using MySqlConnector;

namespace Talleres.Model
{
    public static class Database
    {
        private const string Host = "localhost";
        private const uint Port = 3307;
        private const string DatabaseName = "talleres";
        private const string User = "root";
        private const string Password = "kidboy2";

        public static string GetConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = Host,
                Port = Port,
                Database = DatabaseName,
                UserID = User,
                Password = Password,
                SslMode = MySqlSslMode.None,
                AllowUserVariables = true,
                // Ajustes opcionales
                // ConnectionTimeout = 30
            };
            return builder.ConnectionString;
        }
    }
}