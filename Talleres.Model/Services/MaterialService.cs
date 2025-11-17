using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Contracts.Services;
using Talleres.Model.Entities;
using Talleres.Model.Repositories;

namespace Talleres.Model.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repo;

        public MaterialService(IMaterialRepository? repo = null)
        {
            _repo = repo ?? new MaterialRepository();
        }

        public async Task<List<MaterialStockDto>> ObtenerMaterialesStockAsync(bool soloBajoMinimo = true)
        {
            return await _repo.GetMaterialesStockAsync(soloBajoMinimo).ConfigureAwait(false);
        }
    }
}