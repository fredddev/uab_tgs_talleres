using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<int> CreateAsync(Cliente cliente);
        Task<Cliente?> GetByIdAsync(int idCliente);
    }
}