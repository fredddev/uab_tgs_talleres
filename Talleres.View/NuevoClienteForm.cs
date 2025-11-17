using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Model.Contracts.Repositories;
using Talleres.Model.Entities;
using Talleres.Model.Repositories;

namespace Talleres.View
{
    // Formulario mínimo para crear cliente desde RegistrarPedidoForm.
    public class NuevoClienteForm : Form
    {
        private readonly IClienteRepository _clienteRepository;

        private TextBox txtNombre;
        private TextBox txtContacto;
        private TextBox txtTelefono;
        private Button btnGuardar;
        private Button btnCancelar;

        public NuevoClienteForm(IClienteRepository? clienteRepository = null)
        {
            _clienteRepository = clienteRepository ?? new ClienteRepository();
            Initialize();
        }

        private void Initialize()
        {
            Text = "Nuevo Cliente";
            ClientSize = new System.Drawing.Size(400, 200);

            txtNombre = new TextBox { Location = new System.Drawing.Point(12, 12), Width = 360, PlaceholderText = "Nombre" };
            txtContacto = new TextBox { Location = new System.Drawing.Point(12, 50), Width = 360, PlaceholderText = "Contacto (opcional)" };
            txtTelefono = new TextBox { Location = new System.Drawing.Point(12, 88), Width = 360, PlaceholderText = "Teléfono (opcional)" };
            btnGuardar = new Button { Text = "Guardar", Location = new System.Drawing.Point(200, 130), Width = 80 };
            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(292, 130), Width = 80 };

            btnGuardar.Click += async (_, __) => await GuardarAsync();
            btnCancelar.Click += (_, __) => DialogResult = DialogResult.Cancel;

            Controls.Add(txtNombre);
            Controls.Add(txtContacto);
            Controls.Add(txtTelefono);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        private async Task GuardarAsync()
        {
            var nombre = txtNombre.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre del cliente.");
                return;
            }

            var cliente = new Cliente
            {
                Nombre = nombre,
                Contacto = txtContacto.Text?.Trim(),
                Telefono = txtTelefono.Text?.Trim()
            };

            try
            {
                var id = await _clienteRepository.CreateAsync(cliente).ConfigureAwait(true);
                cliente.IdCliente = id;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando cliente: " + ex.Message);
            }
        }
    }
}