using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class AddDataForm : Form
    {
        private readonly string tableName;

        public AddDataForm(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
        }

        private void AddDataForm_Load(object sender, EventArgs e)
        {
            Text = "Добавление записи: " + tableName;
            CreateControls();
        }

        private void CreateControls()
        {
            DataTable schema = DB.MyConnect.GetSchema("Columns", new string[] {null, null, tableName, null});

            int top = 20;

            foreach (DataRow row in schema.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();

                if (columnName.StartsWith("Код"))
                {
                    continue;
                }

                Label label = new Label
                {
                    Text = columnName,
                    Left = 20,
                    Top = top + 5,
                    Width = 180
                };

                Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Name = "txt" + columnName,
                    Left = 220,
                    Top = top,
                    Width = 200
                };

                Controls.Add(textBox);

                top += 40;
            }

            Button buttonSave = new Button
            {
                Text = "Добавить",
                Left = 220,
                Top = top,
                Width = 90,
                Height = 25
            };

            buttonSave.Click += ButtonSave_Click;

            Controls.Add(buttonSave);

            Button buttonCancel = new Button
            {
                Text = "Отмена",
                Left = 320,
                Top = top,
                Width = 90,
                Height = 25
            };
            buttonCancel.Click += ButtonCancel_Click;

            Controls.Add(buttonCancel);

            Height = top + 100;
            Width = 500;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
                {
                    Close();
                }   

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateRelations();

                DataTable schema = DB.MyConnect.GetSchema("Columns", new string[] {null,null,tableName,null});

                string fields = "";
                string values = "";

                OleDbCommand command = new OleDbCommand();

                command.Connection = DB.MyConnect;

                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();

                    if (columnName.StartsWith("Код"))
                    {
                        continue;
                    }

                    fields += "[" + columnName + "],";

                    values += " ? ,";

                    TextBox textBox = (TextBox)Controls["txt" + columnName];

                    command.Parameters.AddWithValue("@p",textBox.Text);
                }

                fields = fields.TrimEnd(',');

                values = values.TrimEnd(',');

                command.CommandText = $"INSERT INTO [{tableName}] ({fields}) VALUES ({values})";

                command.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена.");

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateRelations()
        {
            if (tableName == "Ресурс")
            {
                TextBox txtOrg = (TextBox)Controls["txtОрганизация"];

                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Организация WHERE КодОрганизации=?", DB.MyConnect);

                cmd.Parameters.AddWithValue("@p1",txtOrg.Text);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("Организация с таким кодом не существует.");
                }

                TextBox txtPrice = (TextBox)Controls["txtСтоимостьЕдиницы"];

                if (!decimal.TryParse(txtPrice.Text, out decimal _))
                {
                    throw new Exception("Стоимость единицы должна быть числом.");
                }
            }

            if (tableName == "Потребление")
            {
                TextBox txtClient = (TextBox)Controls["txtКлиент"];

                TextBox txtResource = (TextBox)Controls["txtРесурс"];

                OleDbCommand cmdClient = new OleDbCommand("SELECT COUNT(*) FROM Клиент WHERE КодКлиента=?", DB.MyConnect);

                cmdClient.Parameters.AddWithValue("@p1", txtClient.Text);

                if (Convert.ToInt32(cmdClient.ExecuteScalar()) == 0)
                {
                    throw new Exception("Клиент не найден.");
                }

                OleDbCommand cmdResource = new OleDbCommand("SELECT COUNT(*) FROM Ресурс WHERE КодРесурса=?", DB.MyConnect);

                cmdResource.Parameters.AddWithValue("@p1", txtResource.Text);

                if (Convert.ToInt32(cmdResource.ExecuteScalar()) == 0)
                {
                    throw new Exception("Ресурс не найден.");
                }

                TextBox txtConsumed = (TextBox)Controls["txtПотреблено"];

                if (!decimal.TryParse(txtConsumed.Text, out decimal _))
                {
                    throw new Exception("Потреблено должно быть числом.");
                }

                TextBox txtDateStart = (TextBox)Controls["txtДатаНачалаПотребления"];
                TextBox txtDateEnd = (TextBox)Controls["txtДатаОкончанияПотребления"];

                DateTime dt;

                if (!DateTime.TryParse(txtDateStart.Text, out dt))
                {
                    throw new Exception("Неверная дата начала потребления.");
                }

                if (!DateTime.TryParse(txtDateEnd.Text, out dt))
                {
                    throw new Exception("Неверная дата окончания потребления.");
                }
            }
        }
    }
}