using System.Threading.Tasks;
using Talleres.Model.Services;
using Talleres.Model.Entities;
using Talleres.Model.Contracts.Services;

namespace Talleres.Controller.Auth
{
    public class AuthController
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService? usuarioService = null)
        {
            _usuarioService = usuarioService ?? new UsuarioService();
        }

        /// <summary>
        /// Intenta autenticar y devuelve el usuario si es exitoso, null si falla.
        /// </summary>
        public async Task<Usuario?> LoginAsync(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
                return null;

            return await _usuarioService.AuthenticateAsync(nombreUsuario.Trim(), contrasena).ConfigureAwait(false);
        }
    }
}
