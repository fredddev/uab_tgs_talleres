using System.Threading.Tasks;
using Talleres.Model.Entities;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Contracts.Services;
using Talleres.Model.Security;
using Talleres.Model.Repositories;

namespace Talleres.Model.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository? repo = null)
        {
            _repo = repo ?? new UsuarioRepository();
        }

        public async Task<Usuario?> AuthenticateAsync(string nombreUsuario, string contrasena)
        {
            var usuario = await _repo.GetByNombreUsuarioAsync(nombreUsuario).ConfigureAwait(false);
            if (usuario is null) return null;

            var valid = PasswordHasher.Verify(contrasena, usuario.Contrasena);
            return valid ? usuario : null;
        }
    }
}