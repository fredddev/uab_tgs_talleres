using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Pedidos;
using Talleres.Model.Entities;

namespace Talleres.View
{
    public partial class ReportePedidosEntregadosForm : Form
    {
        private readonly PedidoController _pedidoController;

        public ReportePedidosEntregadosForm(PedidoController? pedidoController = null)
        {
            InitializeComponent();
            _pedidoController = pedidoController ?? new PedidoController();

            btnRefrescar.Click += async (_, __) => await CargarReporteAsync();
            btnCerrar.Click += (_, __) => Close();

            // defaults: último mes
            dtpFin.Value = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            dtpInicio.Value = DateTime.Now.Date.AddMonths(-1);

            Load += async (_, __) => await CargarReporteAsync();
        }

        private async Task CargarReporteAsync()
        {
            try
            {
                btnRefrescar.Enabled = false;
                var inicio = dtpInicio.Value.Date;
                var fin = dtpFin.Value.Date.AddDays(1).AddTicks(-1);

                var lista = await _pedidoController.ObtenerPedidosEntregadosAsync(inicio, fin).ConfigureAwait(true);

                dgvReport.AutoGenerateColumns = true;
                dgvReport.DataSource = lista;

                if (dgvReport.Columns["IdPedido"] != null) dgvReport.Columns["IdPedido"].HeaderText = "N° Pedido";
                if (dgvReport.Columns["Cliente"] != null) dgvReport.Columns["Cliente"].HeaderText = "Cliente";
                if (dgvReport.Columns["FechaPedido"] != null) dgvReport.Columns["FechaPedido"].HeaderText = "Fecha pedido";
                if (dgvReport.Columns["FechaEntrega"] != null) dgvReport.Columns["FechaEntrega"].HeaderText = "Fecha entrega";
                if (dgvReport.Columns["MontoTotal"] != null) dgvReport.Columns["MontoTotal"].HeaderText = "Monto total";
                if (dgvReport.Columns["NumeroItems"] != null) dgvReport.Columns["NumeroItems"].HeaderText = "N° ítems";
                if (dgvReport.Columns["UsuarioResponsable"] != null) dgvReport.Columns["UsuarioResponsable"].HeaderText = "Usuario";

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