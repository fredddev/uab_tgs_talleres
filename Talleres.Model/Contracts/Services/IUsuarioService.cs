using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<Usuario?> AuthenticateAsync(string nombreUsuario, string contrasena);
    }
}