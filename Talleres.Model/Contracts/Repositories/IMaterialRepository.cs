using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Entities;

namespace Talleres.Model.Contracts.Repositories
{
    public interface IMaterialRepository
    {
        /// <summary>
        /// Devuelve el stock de materiales. Si soloBajoMinimo = true devuelve únicamente
        /// los materiales cuyo stockActual <= stockMinimo.
        /// </summary>
        Task<List<MaterialStockDto>> GetMaterialesStockAsync(bool soloBajoMinimo = true);
    }
}