using System;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class RegisterForm : Form
    {
        private readonly Authentication authentication;

        public RegisterForm(Authentication authentication)
        {
            InitializeComponent();
            this.authentication = authentication;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxNewLogin.Text.Trim();

            string password = textBoxNewPass.Text.Trim();

            string confirmPassword = textBoxRepeatNewPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (authentication.RegisterUser(username, password))
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Возможно, пользователь с таким именем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}