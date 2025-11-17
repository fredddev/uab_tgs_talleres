using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Talleres.Controller.Auth;

namespace Talleres.View
{
    public partial class LoginForm : Form
    {
        private readonly AuthController _authController;

        public LoginForm()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await OnLoginClickedAsync();
        }

        private async Task OnLoginClickedAsync()
        {
            lblStatus.Text = string.Empty;
            btnLogin.Enabled = false;
            try
            {
                var user = await _authController.LoginAsync(txtUsername.Text, txtPassword.Text).ConfigureAwait(true);
                if (user is null)
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Usuario o contraseña incorrectos.";
                    return;
                }

                // Login exitoso
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = $"Bienvenido {user.NombreUsuario} (Rol: {user.Rol})";

                // Abrir panel principal (ejemplo)
                var main = new MainDashboardForm();
                main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error al intentar iniciar sesión: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
