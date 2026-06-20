using System;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class AuthForm : Form
    {
        private readonly Authentication authentication;

        private string loggedInUser;

        public AuthForm(Authentication authentication)
        {
            InitializeComponent();

            this.authentication = authentication;
        }

        public string GetLoggedInUser()
        {
            return loggedInUser;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            TextBoxLogin.Focus();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxLogin.Text;
            string password = TextBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            bool success = authentication.AuthenticateUser(username, password);

            if (success)
            {
                loggedInUser = username;
                DialogResult = DialogResult.OK;
                Close();
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
    }
}