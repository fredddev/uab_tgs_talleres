using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Pedidos;
using Talleres.Model.Entities;

namespace Talleres.View
{
    public partial class ReporteConsumoMaterialForm : Form
    {
        private readonly PedidoController _pedidoController;

        public ReporteConsumoMaterialForm(PedidoController? pedidoController = null)
        {
            InitializeComponent();
            _pedidoController = pedidoController ?? new PedidoController();

            btnRefrescar.Click += async (_, __) => await CargarReporteAsync();
            btnCerrar.Click += (_, __) => Close();

            // defaults
            dtpFin.Value = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            dtpInicio.Value = DateTime.Now.Date.AddMonths(-1);

            Load += async (_, __) => await CargarReporteAsync();
        }

        private async Task CargarReporteAsync()
        {
            try
            {
                btnRefrescar.Enabled = false;

                int? idPedido = null;
                if (int.TryParse(txtIdPedido.Text?.Trim(), out var pid))
                    idPedido = pid;

                var inicio = dtpInicio.Value.Date;
                var fin = dtpFin.Value.Date.AddDays(1).AddTicks(-1);

                var lista = await _pedidoController.ObtenerConsumoMaterialAsync(idPedido, inicio, fin).ConfigureAwait(true);

                dgvReport.AutoGenerateColumns = true;
                dgvReport.DataSource = lista;

                // Mejorar encabezados
                if (dgvReport.Columns["IdPedido"] != null) dgvReport.Columns["IdPedido"].HeaderText = "N° Pedido";
                if (dgvReport.Columns["Cliente"] != null) dgvReport.Columns["Cliente"].HeaderText = "Cliente";
                if (dgvReport.Columns["Material"] != null) dgvReport.Columns["Material"].HeaderText = "Material";
                if (dgvReport.Columns["TipoMovimiento"] != null) dgvReport.Columns["TipoMovimiento"].HeaderText = "Tipo";
                if (dgvReport.Columns["Cantidad"] != null) dgvReport.Columns["Cantidad"].HeaderText = "Cantidad";
                if (dgvReport.Columns["Unidad"] != null) dgvReport.Columns["Unidad"].HeaderText = "Unidad";
                if (dgvReport.Columns["CostoUnitario"] != null) dgvReport.Columns["CostoUnitario"].HeaderText = "Costo unitario";
                if (dgvReport.Columns["CostoTotal"] != null) dgvReport.Columns["CostoTotal"].HeaderText = "Costo total";
                if (dgvReport.Columns["FechaMovimiento"] != null) dgvReport.Columns["FechaMovimiento"].HeaderText = "Fecha movimiento";
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