namespace Talleres.View
{
    partial class RegistrarPedidoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Button btnNuevoCliente;

        private System.Windows.Forms.GroupBox grpPedido;
        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.NumericUpDown numMontoTotal;

        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.NumericUpDown numPrecioUnitario;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnQuitarProducto;
        private System.Windows.Forms.DataGridView dgvDetalle;

        private System.Windows.Forms.Button btnGuardarPedido;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpCliente = new GroupBox();
            cmbCliente = new ComboBox();
            btnNuevoCliente = new Button();
            grpPedido = new GroupBox();
            dtpFechaPedido = new DateTimePicker();
            dtpFechaEntrega = new DateTimePicker();
            cmbEstado = new ComboBox();
            numMontoTotal = new NumericUpDown();
            grpProductos = new GroupBox();
            txtProducto = new TextBox();
            numCantidad = new NumericUpDown();
            numPrecioUnitario = new NumericUpDown();
            txtObservaciones = new TextBox();
            btnAgregarProducto = new Button();
            btnQuitarProducto = new Button();
            dgvDetalle = new DataGridView();
            btnGuardarPedido = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            grpCliente.SuspendLayout();
            grpPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMontoTotal).BeginInit();
            grpProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(cmbCliente);
            grpCliente.Controls.Add(btnNuevoCliente);
            grpCliente.Location = new Point(12, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(760, 60);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Información del Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.Location = new Point(12, 22);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(600, 23);
            cmbCliente.TabIndex = 0;
            // 
            // btnNuevoCliente
            // 
            btnNuevoCliente.Location = new Point(620, 20);
            btnNuevoCliente.Name = "btnNuevoCliente";
            btnNuevoCliente.Size = new Size(120, 26);
            btnNuevoCliente.TabIndex = 1;
            btnNuevoCliente.Text = "Nuevo Cliente";
            btnNuevoCliente.UseVisualStyleBackColor = true;
            // 
            // grpPedido
            // 
            grpPedido.Controls.Add(label2);
            grpPedido.Controls.Add(label4);
            grpPedido.Controls.Add(label3);
            grpPedido.Controls.Add(label1);
            grpPedido.Controls.Add(dtpFechaPedido);
            grpPedido.Controls.Add(dtpFechaEntrega);
            grpPedido.Controls.Add(cmbEstado);
            grpPedido.Controls.Add(numMontoTotal);
            grpPedido.Location = new Point(12, 80);
            grpPedido.Name = "grpPedido";
            grpPedido.Size = new Size(760, 120);
            grpPedido.TabIndex = 1;
            grpPedido.TabStop = false;
            grpPedido.Text = "Detalles del Pedido";
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(14, 42);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(200, 23);
            dtpFechaPedido.TabIndex = 0;
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.Location = new Point(222, 42);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(200, 23);
            dtpFechaEntrega.TabIndex = 1;
            // 
            // cmbEstado
            // 
            cmbEstado.Location = new Point(14, 91);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 2;
            // 
            // numMontoTotal
            // 
            numMontoTotal.DecimalPlaces = 2;
            numMontoTotal.Location = new Point(222, 91);
            numMontoTotal.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numMontoTotal.Name = "numMontoTotal";
            numMontoTotal.Size = new Size(120, 23);
            numMontoTotal.TabIndex = 3;
            // 
            // grpProductos
            // 
            grpProductos.Controls.Add(label6);
            grpProductos.Controls.Add(label5);
            grpProductos.Controls.Add(txtProducto);
            grpProductos.Controls.Add(numCantidad);
            grpProductos.Controls.Add(numPrecioUnitario);
            grpProductos.Controls.Add(txtObservaciones);
            grpProductos.Controls.Add(btnAgregarProducto);
            grpProductos.Controls.Add(btnQuitarProducto);
            grpProductos.Controls.Add(dgvDetalle);
            grpProductos.Location = new Point(12, 210);
            grpProductos.Name = "grpProductos";
            grpProductos.Size = new Size(760, 300);
            grpProductos.TabIndex = 2;
            grpProductos.TabStop = false;
            grpProductos.Text = "Productos solicitados";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(12, 27);
            txtProducto.Name = "txtProducto";
            txtProducto.PlaceholderText = "Producto";
            txtProducto.Size = new Size(300, 23);
            txtProducto.TabIndex = 0;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(320, 27);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 23);
            numCantidad.TabIndex = 1;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPrecioUnitario
            // 
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Location = new Point(410, 27);
            numPrecioUnitario.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecioUnitario.Name = "numPrecioUnitario";
            numPrecioUnitario.Size = new Size(110, 23);
            numPrecioUnitario.TabIndex = 2;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(526, 27);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Observaciones";
            txtObservaciones.Size = new Size(206, 23);
            txtObservaciones.TabIndex = 3;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(12, 54);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(100, 26);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Location = new Point(120, 54);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(100, 26);
            btnQuitarProducto.TabIndex = 5;
            btnQuitarProducto.Text = "Quitar";
            btnQuitarProducto.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 84);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(720, 200);
            dgvDetalle.TabIndex = 6;
            // 
            // btnGuardarPedido
            // 
            btnGuardarPedido.BackColor = Color.FromArgb(66, 83, 175);
            btnGuardarPedido.FlatStyle = FlatStyle.Flat;
            btnGuardarPedido.ForeColor = Color.White;
            btnGuardarPedido.Location = new Point(516, 520);
            btnGuardarPedido.Name = "btnGuardarPedido";
            btnGuardarPedido.Size = new Size(120, 30);
            btnGuardarPedido.TabIndex = 3;
            btnGuardarPedido.Text = "Guardar Pedido";
            btnGuardarPedido.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(642, 520);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 24);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Fecha pedido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 24);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 4;
            label2.Text = "Fecha de entrega:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 75);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 75);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 4;
            label4.Text = "Monto total (Bs.):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(317, 9);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 7;
            label5.Text = "Cantidad:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(406, 9);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 7;
            label6.Text = "Precio Unitario (Bs.):";
            // 
            // RegistrarPedidoForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(784, 561);
            Controls.Add(grpCliente);
            Controls.Add(grpPedido);
            Controls.Add(grpProductos);
            Controls.Add(btnGuardarPedido);
            Controls.Add(btnCancelar);
            Name = "RegistrarPedidoForm";
            Text = "Registrar Nuevo Pedido";
            grpCliente.ResumeLayout(false);
            grpPedido.ResumeLayout(false);
            grpPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMontoTotal).EndInit();
            grpProductos.ResumeLayout(false);
            grpProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colObserv;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label6;
        private Label label5;
    }
}