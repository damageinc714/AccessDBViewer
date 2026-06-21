using System;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class AuthForm : Form
    {
        private readonly Authentication authentication;

        private bool loginSuccess = false;

        public AuthForm(Authentication authentication)
        {
            InitializeComponent();
            FormClosing += AuthForm_FormClosing;
            this.authentication = authentication;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
             TextBoxLogin.Focus();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxLogin.Text.Trim();
            string password = TextBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            bool success = authentication.AuthenticateUser(username, password);

            if (success)
            {
                loginSuccess = true;
                DialogResult = DialogResult.OK;
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(authentication);
            registerForm.ShowDialog();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (DB.MyConnect != null)
            {
                DB.CloseConnect();
            }
            Application.Exit();
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginSuccess)
            {
                if (DB.MyConnect != null)
                {
                    DB.CloseConnect();
                }

                Application.Exit();
            }
        }
    }
}