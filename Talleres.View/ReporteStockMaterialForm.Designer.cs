namespace Talleres.View
{
    partial class ReporteStockMaterialForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox chkSoloBajoMinimo;

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
            chkSoloBajoMinimo = new System.Windows.Forms.CheckBox();

            SuspendLayout();

            // chkSoloBajoMinimo
            chkSoloBajoMinimo.Location = new System.Drawing.Point(12, 12);
            chkSoloBajoMinimo.Size = new System.Drawing.Size(200, 24);
            chkSoloBajoMinimo.Text = "Mostrar solo bajo mínimo";
            chkSoloBajoMinimo.Checked = true;

            // dgvReport
            dgvReport.Location = new System.Drawing.Point(12, 40);
            dgvReport.Size = new System.Drawing.Size(760, 380);
            dgvReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnRefrescar
            btnRefrescar.Location = new System.Drawing.Point(220, 8);
            btnRefrescar.Size = new System.Drawing.Size(100, 28);
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;

            // btnCerrar
            btnCerrar.Location = new System.Drawing.Point(672, 430);
            btnCerrar.Size = new System.Drawing.Size(100, 28);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;

            // Form
            ClientSize = new System.Drawing.Size(784, 471);
            Controls.Add(chkSoloBajoMinimo);
            Controls.Add(btnRefrescar);
            Controls.Add(dgvReport);
            Controls.Add(btnCerrar);
            Text = "Reporte - Stock actual y materiales bajo mínimo";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}