using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class ConnectForm : Form
    {
        private OpenFileDialog openFileDialog;
        private string connectionString;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "Access Database (*.accdb)|*.accdb",
                Title = "Выберите базу данных Access"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DatabasePath.Text = openFileDialog.FileName;
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {   
                if (!DatabasePath.Text.EndsWith(".accdb"))
                {
                    MessageBox.Show("Выберите файл базы данных.", "Не выбран файл", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DatabasePath.Text.EndsWith("Ресурсы_Таблицы.accdb"))
                {
                    MessageBox.Show("Невозможно произвести работу с этим файлом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //проверка на установку драйвера
                bool providerInstalled = new OleDbEnumerator()
                    .GetElements().AsEnumerable()
                    .Any(x => x.Field<string>("SOURCES_NAME") == "Microsoft.ACE.OLEDB.12.0");

                if (!providerInstalled)
                {
                    MessageBox.Show("Не установлен драйвер Microsoft Access Database Engine.");
                    return;
                }
                //проверка подключения и передача строки подключения в класс DB
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DatabasePath.Text;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                }

                DB.connectString = connectionString;

                MessageBox.Show("Подключение выполнено успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //открытие форм по цепочке
                Authentication authentication = new Authentication(connectionString);
                AuthForm authForm = new AuthForm(authentication);

                Hide();

                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
