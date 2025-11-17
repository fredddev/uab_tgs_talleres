namespace Talleres.View
{
    partial class ReportePedidosEnProcesoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvReport = new System.Windows.Forms.DataGridView();
            btnRefrescar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();

            SuspendLayout();

            // dgvReport
            dgvReport.Location = new System.Drawing.Point(12, 12);
            dgvReport.Size = new System.Drawing.Size(960, 420);
            dgvReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnRefrescar
            btnRefrescar.Location = new System.Drawing.Point(12, 440);
            btnRefrescar.Size = new System.Drawing.Size(120, 30);
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;

            // btnCerrar
            btnCerrar.Location = new System.Drawing.Point(852, 440);
            btnCerrar.Size = new System.Drawing.Size(120, 30);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;

            // Form
            ClientSize = new System.Drawing.Size(984, 481);
            Controls.Add(dgvReport);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCerrar);
            Text = "Reporte - Pedidos en Proceso";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}