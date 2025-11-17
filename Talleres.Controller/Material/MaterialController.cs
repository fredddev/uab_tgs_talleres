using System.Collections.Generic;
using System.Threading.Tasks;
using Talleres.Model.Contracts.Services;
using Talleres.Model.Entities;

namespace Talleres.Controller.Material
{
    public class MaterialController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService? materialService = null)
        {
            _materialService = materialService ?? new Talleres.Model.Services.MaterialService();
        }

        public async Task<List<MaterialStockDto>> ObtenerMaterialesStockAsync(bool soloBajoMinimo = true)
        {
            return await _materialService.ObtenerMaterialesStockAsync(soloBajoMinimo).ConfigureAwait(false);
        }
    }
}