using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Services
{
    public interface IMaterialService
    {
        Task<List<MaterialStockDto>> ObtenerMaterialesStockAsync(bool soloBajoMinimo = true);
    }
}