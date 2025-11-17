namespace Talleres.View
{
    partial class ReportePedidosEntregadosForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;

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
            dtpInicio = new System.Windows.Forms.DateTimePicker();
            dtpFin = new System.Windows.Forms.DateTimePicker();
            lblInicio = new System.Windows.Forms.Label();
            lblFin = new System.Windows.Forms.Label();

            SuspendLayout();

            // dtpInicio
            lblInicio.Location = new System.Drawing.Point(12, 12);
            lblInicio.Size = new System.Drawing.Size(80, 23);
            lblInicio.Text = "Fecha inicio:";

            dtpInicio.Location = new System.Drawing.Point(96, 12);
            dtpInicio.Size = new System.Drawing.Size(200, 23);

            // dtpFin
            lblFin.Location = new System.Drawing.Point(312, 12);
            lblFin.Size = new System.Drawing.Size(80, 23);
            lblFin.Text = "Fecha fin:";

            dtpFin.Location = new System.Drawing.Point(392, 12);
            dtpFin.Size = new System.Drawing.Size(200, 23);

            // dgvReport
            dgvReport.Location = new System.Drawing.Point(12, 48);
            dgvReport.Size = new System.Drawing.Size(960, 420);
            dgvReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnRefrescar
            btnRefrescar.Location = new System.Drawing.Point(600, 10);
            btnRefrescar.Size = new System.Drawing.Size(100, 26);
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;

            // btnCerrar
            btnCerrar.Location = new System.Drawing.Point(872, 480);
            btnCerrar.Size = new System.Drawing.Size(100, 28);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;

            // Form
            ClientSize = new System.Drawing.Size(984, 521);
            Controls.Add(lblInicio);
            Controls.Add(dtpInicio);
            Controls.Add(lblFin);
            Controls.Add(dtpFin);
            Controls.Add(btnRefrescar);
            Controls.Add(dgvReport);
            Controls.Add(btnCerrar);
            Text = "Reporte - Pedidos Entregados por Período";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}