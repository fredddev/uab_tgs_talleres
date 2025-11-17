using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByNombreUsuarioAsync(string nombreUsuario);
        Task<int> CreateAsync(Usuario usuario);
    }
}