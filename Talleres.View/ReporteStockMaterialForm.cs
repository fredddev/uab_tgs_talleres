using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Material;
using Talleres.Model.Entities;

namespace Talleres.View
{
    public partial class ReporteStockMaterialForm : Form
    {
        private readonly MaterialController _materialController;

        public ReporteStockMaterialForm(MaterialController? materialController = null)
        {
            InitializeComponent();
            _materialController = materialController ?? new MaterialController();

            btnRefrescar.Click += async (_, __) => await CargarReporteAsync();
            btnCerrar.Click += (_, __) => Close();
            chkSoloBajoMinimo.CheckedChanged += async (_, __) => await CargarReporteAsync();

            Load += async (_, __) => await CargarReporteAsync();
        }

        private async Task CargarReporteAsync()
        {
            try
            {
                btnRefrescar.Enabled = false;
                var soloBajo = chkSoloBajoMinimo.Checked;
                var lista = await _materialController.ObtenerMaterialesStockAsync(soloBajo).ConfigureAwait(true);

                dgvReport.AutoGenerateColumns = true;
                dgvReport.DataSource = lista;

                if (dgvReport.Columns["Material"] != null) dgvReport.Columns["Material"].HeaderText = "Material";
                if (dgvReport.Columns["Unidad"] != null) dgvReport.Columns["Unidad"].HeaderText = "Unidad";
                if (dgvReport.Columns["StockActual"] != null) dgvReport.Columns["StockActual"].HeaderText = "Stock actual";
                if (dgvReport.Columns["StockMinimo"] != null) dgvReport.Columns["StockMinimo"].HeaderText = "Stock mínimo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando reporte: " + ex.Message);
            }
            finally
            {
                btnRefrescar.Enabled = true;
            }
        }
    }
}