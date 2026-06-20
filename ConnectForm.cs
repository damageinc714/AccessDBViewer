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

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Access Database (*.accdb)|*.accdb";
            openFileDialog.Title = "Выберите базу данных Access";
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDatabasePath.Text = openFileDialog.FileName;
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDatabasePath.Text))
                {
                    MessageBox.Show("Выберите файл базы данных.");
                    return;
                }

                bool providerInstalled = new OleDbEnumerator()
                    .GetElements().AsEnumerable()
                    .Any(x => x.Field<string>("SOURCES_NAME") == "Microsoft.ACE.OLEDB.12.0");

                if (!providerInstalled)
                {
                    MessageBox.Show("Не установлен драйвер Microsoft Access Database Engine.");
                    return;
                }

                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtDatabasePath.Text;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                }

                DB.connectString = connectionString;

                MessageBox.Show("Подключение выполнено успешно.");

                Authentication authentication = new Authentication(connectionString);
                AuthForm authForm = new AuthForm(authentication);

                Hide();

                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    MainForm mainForm = new MainForm();

                    mainForm.ShowDialog();

                    Close();
                }
                else
                {
                    Show();
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
