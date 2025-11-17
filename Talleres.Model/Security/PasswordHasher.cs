using System;
using System.Security.Cryptography;
using System.Text;

namespace Talleres.Model.Security
{
    public static class PasswordHasher
    {
        // PBKDF2 settings
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        // Format: {iterations}.{saltBase64}.{hashBase64}
        public static string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var key = pbkdf2.GetBytes(KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
        }

        public static bool Verify(string password, string hashed)
        {
            try
            {
                var parts = hashed.Split('.', 3);
                if (parts.Length != 3) return false;

                var iterations = int.Parse(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var key = Convert.FromBase64String(parts[2]);

                using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
                var attempted = pbkdf2.GetBytes(key.Length);

                return CryptographicOperations.FixedTimeEquals(attempted, key);
            }
            catch
            {
                return false;
            }
        }
    }
}