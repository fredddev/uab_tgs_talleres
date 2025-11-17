using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talleres.View
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new RegistrarPedidoForm().Show();
        }

        private void reporteDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReportePedidosEnProcesoForm().Show();
        }

        private void reporteDeMaterialesConsumidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReportePedidosEntregadosForm().Show();
        }

        private void consumoDeMaterialesPorPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReporteConsumoMaterialForm().Show();
        }

        private void stockDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReporteStockMaterialForm().Show();
        }
    }
}
