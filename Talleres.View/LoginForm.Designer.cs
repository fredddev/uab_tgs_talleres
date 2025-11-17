namespace Talleres.View
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblStatus;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblStatus = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(71, 143);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Usuario";
            txtUsername.Size = new Size(220, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(71, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(66, 83, 175);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(71, 284);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(220, 44);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(71, 263);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 69);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 4;
            label1.Text = "Inicio de sesion";
            label1.Click += label1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(360, 454);
            Controls.Add(label1);
            Controls.Add(lblStatus);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}
