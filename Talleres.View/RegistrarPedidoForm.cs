using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Pedidos;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Entities;
using Talleres.Model.Repositories;

namespace Talleres.View
{
    public partial class RegistrarPedidoForm : Form
    {
        private readonly PedidoController _pedidoController;
        private readonly IClienteRepository _clienteRepository;

        private List<Cliente> _clientes = new();

        public RegistrarPedidoForm(PedidoController? pedidoController = null, IClienteRepository? clienteRepository = null)
        {
            InitializeComponent();

            // Asegurar que las columnas del DataGridView existan (evita la excepción en tiempo de ejecución)
            EnsureDetalleColumns();

            _pedidoController = pedidoController ?? new PedidoController();
            _clienteRepository = clienteRepository ?? new ClienteRepository();

            // wire events
            btnNuevoCliente.Click += BtnNuevoCliente_Click;
            btnAgregarProducto.Click += BtnAgregarProducto_Click;
            btnQuitarProducto.Click += BtnQuitarProducto_Click;
            btnGuardarPedido.Click += BtnGuardarPedido_Click;
            btnCancelar.Click += (_, __) => Close();

            Load += async (_, __) => await OnLoadAsync();
        }

        private void EnsureDetalleColumns()
        {
            // Si ya hay columnas definidas no hacer nada
            if (dgvDetalle.Columns.Count > 0) return;

            dgvDetalle.Columns.Clear();

            var colProducto = new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", Width = 320 };
            var colCantidad = new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 80 };
            var colPrecio = new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio Unitario", Width = 120 };
            var colPrecioTotal = new DataGridViewTextBoxColumn { Name = "PrecioTotal", HeaderText = "Precio Total", Width = 120, ReadOnly = true };
            var colObserv = new DataGridViewTextBoxColumn { Name = "Observaciones", HeaderText = "Observaciones", Width = 180 };

            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colProducto, colCantidad, colPrecio, colPrecioTotal, colObserv });
        }

        private async Task OnLoadAsync()
        {
            dtpFechaPedido.Value = DateTime.Now;
            dtpFechaEntrega.Value = DateTime.Now.AddDays(7);
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "EN PROCESO", "PENDIENTE", "LISTO PARA ENTREGA" });
            cmbEstado.SelectedIndex = 0;

            await CargarClientesAsync().ConfigureAwait(false);
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                _clientes = await _clienteRepository.GetAllAsync().ConfigureAwait(false);
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        cmbCliente.DataSource = null;
                        cmbCliente.DataSource = _clientes;
                        cmbCliente.DisplayMember = "Nombre";
                        cmbCliente.ValueMember = "IdCliente";
                    }));
                }
                else
                {
                    cmbCliente.DataSource = _clientes;
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "IdCliente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes: " + ex.Message);
            }
        }

        private void BtnNuevoCliente_Click(object? sender, EventArgs e)
        {
            // Simpleo stub: aquí deberías abrir un formulario real para crear cliente.
            using var form = new NuevoClienteForm(_clienteRepository);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // recargar la lista y seleccionar el nuevo
                _ = CargarClientesAsync();
            }
        }

        private void BtnAgregarProducto_Click(object? sender, EventArgs e)
        {
            // Asegurar columnas (por si el diseñador no las creó por alguna razón)
            EnsureDetalleColumns();

            var producto = txtProducto.Text?.Trim();
            if (string.IsNullOrWhiteSpace(producto))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                return;
            }

            var cantidad = (int)numCantidad.Value;
            var precio = numPrecioUnitario.Value;
            var observ = txtObservaciones.Text?.Trim();

            // calcular precio total por fila
            var precioTotal = cantidad * precio;

            // Agregar fila: Producto, Cantidad, PrecioUnitario, PrecioTotal, Observaciones
            dgvDetalle.Rows.Add(producto, cantidad.ToString(), precio.ToString("F2"), precioTotal.ToString("F2"), observ ?? "");

            RecalcularMontoTotal();
            // limpiar inputs
            txtProducto.Clear();
            numCantidad.Value = 1;
            numPrecioUnitario.Value = 0;
            txtObservaciones.Clear();
            txtProducto.Focus();
        }

        private void BtnQuitarProducto_Click(object? sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para quitar.");
                return;
            }

            dgvDetalle.Rows.RemoveAt(dgvDetalle.SelectedRows[0].Index);
            RecalcularMontoTotal();
        }

        private void RecalcularMontoTotal()
        {
            decimal total = 0m;

            // índices de columnas (seguro por nombre)
            int idxCantidad = dgvDetalle.Columns.Contains("Cantidad") ? dgvDetalle.Columns["Cantidad"].Index : -1;
            int idxPrecio = dgvDetalle.Columns.Contains("PrecioUnitario") ? dgvDetalle.Columns["PrecioUnitario"].Index : -1;
            int idxPrecioTotal = dgvDetalle.Columns.Contains("PrecioTotal") ? dgvDetalle.Columns["PrecioTotal"].Index : -1;

            foreach (System.Windows.Forms.DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                // Valores por defecto
                string qtyText = "0";
                string priceText = "0";

                if (idxCantidad >= 0 && row.Cells.Count > idxCantidad && row.Cells[idxCantidad].Value != null)
                    qtyText = row.Cells[idxCantidad].Value.ToString()!;
                else if (row.Cells.Count > 1 && row.Cells[1].Value != null) // fallback: columna 1
                    qtyText = row.Cells[1].Value.ToString()!;

                if (idxPrecio >= 0 && row.Cells.Count > idxPrecio && row.Cells[idxPrecio].Value != null)
                    priceText = row.Cells[idxPrecio].Value.ToString()!;
                else if (row.Cells.Count > 2 && row.Cells[2].Value != null) // fallback: columna 2
                    priceText = row.Cells[2].Value.ToString()!;

                if (int.TryParse(qtyText, out var qty) && decimal.TryParse(priceText, out var price))
                {
                    var filaTotal = qty * price;
                    total += filaTotal;

                    // Actualizar columna PrecioTotal si existe
                    if (idxPrecioTotal >= 0 && row.Cells.Count > idxPrecioTotal)
                    {
                        row.Cells[idxPrecioTotal].Value = filaTotal.ToString("F2");
                    }
                }
                else
                {
                    if (idxPrecioTotal >= 0 && row.Cells.Count > idxPrecioTotal)
                        row.Cells[idxPrecioTotal].Value = "0.00";
                }
            }

            var safeTotal = Math.Min(numMontoTotal.Maximum, total);
            if (InvokeRequired)
            {
                Invoke(new Action(() => numMontoTotal.Value = safeTotal));
            }
            else
            {
                numMontoTotal.Value = safeTotal;
            }
        }

        private async void BtnGuardarPedido_Click(object? sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cmbCliente.SelectedItem is not Cliente cliente)
                {
                    MessageBox.Show("Seleccione un cliente.");
                    return;
                }

                if (dtpFechaEntrega.Value <= dtpFechaPedido.Value)
                {
                    MessageBox.Show("La fecha de entrega debe ser posterior a la fecha de pedido.");
                    return;
                }

                if (dgvDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto al pedido.");
                    return;
                }

                var pedido = new Pedido
                {
                    IdCliente = cliente.IdCliente,
                    FechaPedido = dtpFechaPedido.Value,
                    FechaEntrega = dtpFechaEntrega.Value,
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "EN PROCESO",
                    MontoTotal = numMontoTotal.Value
                };

                var detalles = new List<DetallePedido>();
                foreach (System.Windows.Forms.DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.IsNewRow) continue;
                    var producto = row.Cells["Producto"].Value?.ToString() ?? string.Empty;
                    var cantidad = int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out var q) ? q : 1;
                    var precio = decimal.TryParse(row.Cells["PrecioUnitario"].Value?.ToString(), out var p) ? p : 0m;
                    var obs = row.Cells["Observaciones"].Value?.ToString();

                    detalles.Add(new DetallePedido
                    {
                        Producto = producto,
                        Cantidad = cantidad,
                        PrecioUnitario = precio,
                        Observaciones = obs
                    });
                }

                btnGuardarPedido.Enabled = false;
                var idPedido = await _pedidoController.GuardarPedidoAsync(pedido, detalles).ConfigureAwait(true);

                MessageBox.Show($"Pedido guardado exitosamente (ID: {idPedido}).");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar pedido: " + ex.Message);
            }
            finally
            {
                btnGuardarPedido.Enabled = true;
            }
        }
    }
}