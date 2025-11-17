using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Pedidos;
using Talleres.Model.Entities;

namespace Talleres.View
{
    public partial class ReportePedidosEnProcesoForm : Form
    {
        private readonly PedidoController _pedidoController;

        public ReportePedidosEnProcesoForm(PedidoController? pedidoController = null)
        {
            InitializeComponent();
            _pedidoController = pedidoController ?? new PedidoController();

            btnRefrescar.Click += async (_, __) => await CargarReporteAsync();
            btnCerrar.Click += (_, __) => Close();

            Load += async (_, __) => await CargarReporteAsync();
        }

        private async Task CargarReporteAsync()
        {
            try
            {
                btnRefrescar.Enabled = false;
                var lista = await _pedidoController.ObtenerPedidosEnProcesoAsync().ConfigureAwait(true);

                // Bind con columnas automáticas (propiedades del DTO)
                dgvReport.AutoGenerateColumns = true;
                dgvReport.DataSource = lista;

                // Mejorar encabezados (opcional): renombrar columnas si quieres
                if (dgvReport.Columns["IdPedido"] != null) dgvReport.Columns["IdPedido"].HeaderText = "N° Pedido";
                if (dgvReport.Columns["Cliente"] != null) dgvReport.Columns["Cliente"].HeaderText = "Cliente";
                if (dgvReport.Columns["FechaPedido"] != null) dgvReport.Columns["FechaPedido"].HeaderText = "Fecha pedido";
                if (dgvReport.Columns["FechaEntrega"] != null) dgvReport.Columns["FechaEntrega"].HeaderText = "Fecha entrega";
                if (dgvReport.Columns["DiasRestantes"] != null) dgvReport.Columns["DiasRestantes"].HeaderText = "Días restantes";
                if (dgvReport.Columns["EstadoPedido"] != null) dgvReport.Columns["EstadoPedido"].HeaderText = "Estado pedido";
                if (dgvReport.Columns["EstadoProduccion"] != null) dgvReport.Columns["EstadoProduccion"].HeaderText = "Estado producción";
                if (dgvReport.Columns["ResponsableProduccion"] != null) dgvReport.Columns["ResponsableProduccion"].HeaderText = "Responsable producción";
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