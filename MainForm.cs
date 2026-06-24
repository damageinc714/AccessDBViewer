using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessDBViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            dataGridViewTables.CellValidating += DataGridViewTables_CellValidating;
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            FormClosing += MainForm_FormClosing;
        }
        //проверки ячеек в DataGridView
        private void DataGridViewTables_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //по умолчания object, так что переводим
            string table = comboBoxTables.SelectedItem.ToString();

            string columnName = dataGridViewTables.Columns[e.ColumnIndex].Name;

            string value = e.FormattedValue.ToString();

            int number;

            if (table == "Ресурс")
            {
                if (columnName == "СтоимостьЕдиницы")
                {
                    if (!decimal.TryParse(value, out decimal _))
                    {
                        MessageBox.Show("Стоимость должна быть числом.");
                        e.Cancel = true;
                    }
                }

                if (columnName == "Организация")
                {
                    if (!int.TryParse(value, out number))
                    {
                        MessageBox.Show("Введите код организации.");
                        e.Cancel = true;
                        return;
                    }

                    OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Организация WHERE КодОрганизации=?", DB.MyConnect);

                    cmd.Parameters.AddWithValue("@p1", number);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("Организация не найдена.");
                        e.Cancel = true;
                    }
                }
            }

            if (table == "Потребление")
            {
                if (columnName == "Потреблено")
                {
                    if (!int.TryParse(value, out int _))
                    {
                        MessageBox.Show("Потреблено должно быть числом.");
                        e.Cancel = true;
                    }
                }

                if (columnName == "ДатаНачалаПотребления" || columnName == "ДатаОкончанияПотребления")
                {
                    if (!DateTime.TryParse(value, out _))
                    {
                        MessageBox.Show("Дата должна быть в формате дд.мм.гггг.");
                        e.Cancel = true;
                    }
                }

                if (columnName == "Клиент")
                {
                    if (!int.TryParse(value, out number))
                    {
                        MessageBox.Show("Необходимо ввести числовой код.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Клиент WHERE КодКлиента=?", DB.MyConnect);

                    cmd.Parameters.AddWithValue("@p1", number);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("Клиент не найден.");
                        e.Cancel = true;
                    }
                }

                if (columnName == "Ресурс")
                {
                    if (!int.TryParse(value, out number))
                    {
                        MessageBox.Show("Необходимо ввести числовой код.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Ресурс WHERE КодРесурса=?", DB.MyConnect);

                    cmd.Parameters.AddWithValue("@p1", number);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("Ресурс не найден.");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void MainForm_Load(object sender,EventArgs e)
        {
                try
            {
                DB.OpenConnect();

                comboBoxTables.Items.Clear();

                comboBoxTables.Items.Add("Клиент");
                comboBoxTables.Items.Add("Организация");
                comboBoxTables.Items.Add("Ресурс");
                comboBoxTables.Items.Add("Потребление");

                ShowTableControls();

                dataGridViewTables.AllowUserToAddRows = false;
                dataGridViewTables.MultiSelect = false;
                dataGridViewTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       //кнопка открытия таблицы
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу.");
                return;
            }

            string table = comboBoxTables.SelectedItem.ToString();
             
            DB.OpenTable(table);
            //сортировка по кодам
            DB.dt.DefaultView.Sort = DB.dt.Columns[0].ColumnName + " ASC";

            dataGridViewTables.DataSource = DB.dt.DefaultView;

            dataGridViewTables.Columns[0].ReadOnly = true;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem == null)
            {
                return;
            }

            string table = comboBoxTables.SelectedItem.ToString();

            AddDataForm form = new AddDataForm(table);

            if (form.ShowDialog() == DialogResult.OK)
            {
                DB.OpenTable(table);
                dataGridViewTables.DataSource = DB.dt;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.CurrentRow == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранную запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewTables.SelectedRows)
                {
                    dataGridViewTables.Rows.Remove(row);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (DB.ds == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Сохранить изменения в базе данных?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DB.SaveData();
                    MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Завершить работу программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DB.CloseConnect();
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DB.MyConnect != null)
            {
                DB.CloseConnect();
            }
            Application.Exit();
        }

        private void ShowTableControls()
        {
            labelPickTable.Visible = true;
            comboBoxTables.Visible = true;
            ButtonOpen.Visible = true;
            ButtonAdd.Visible = true;
            ButtonDelete.Visible = true;
            ButtonSave.Visible = true;
            dataGridViewTables.Visible = true;
            ButtonExact.Visible = false;
            ButtonInexact.Visible = false;
            ButtonGroup.Visible = false;
            ButtonCount.Visible = false;
            dataGridViewQuery.Visible = false;
            textBoxSql.Visible = false;
            ButtonCreateQuery.Visible = false;
            ButtonReport.Visible = false;
        }

        private void HideTableControls()
        {
            labelPickTable.Visible = false;
            comboBoxTables.Visible = false;
            ButtonOpen.Visible = false;
            ButtonAdd.Visible = false;
            ButtonDelete.Visible = false;
            ButtonSave.Visible = false;
            dataGridViewTables.Visible = false;
            ButtonExact.Visible = true;
            ButtonInexact.Visible = true;
            ButtonGroup.Visible = true;
            ButtonCount.Visible = true;
            dataGridViewQuery.Visible = true;
            textBoxSql.Visible = true;
            ButtonCreateQuery.Visible = true;
            ButtonReport.Visible = true;
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageQuery)
            {
                HideTableControls();
            }

            if (tabControlMain.SelectedTab == tabPageTables)
            {
                ShowTableControls();
            }
        }

        private void ButtonExact_Click(object sender, EventArgs e)
        {
            string resourceName = Microsoft.VisualBasic.Interaction.InputBox("Введите название ресурса:", "Точное попадание");

            string sql =
            "SELECT Клиент.[ФИОКлиента], Ресурс.[НаименованиеРесурса], Потребление.[ДатаНачалаПотребления], Потребление.[ДатаОкончанияПотребления], Потребление.Потреблено " +
            "FROM (Потребление INNER JOIN Ресурс ON Потребление.Ресурс = Ресурс.[КодРесурса]) " +
            "INNER JOIN Клиент ON Потребление.Клиент = Клиент.[КодКлиента] " +
            "WHERE Ресурс.[НаименованиеРесурса] = '" + resourceName + "'";

            DB.CreateQuery(sql);
            dataGridViewQuery.DataSource = DB.ds.Tables[0];
        }

        private void ButtonInexact_Click(object sender, EventArgs e)
        {
            string monthText = Microsoft.VisualBasic.Interaction.InputBox("Введите номер месяца (1-12):", "Неточное попадание");

            if (!int.TryParse(monthText, out int month))
            {
                return;
            }

            string sql =
            "SELECT Клиент.[ФИОКлиента], Потребление.[ДатаНачалаПотребления], Потребление.Потреблено " +
            "FROM Потребление " +
            "INNER JOIN Клиент ON Потребление.Клиент = Клиент.[КодКлиента] " +
            "WHERE Month([ДатаНачалаПотребления]) = " + month;

            DB.CreateQuery(sql);
            dataGridViewQuery.DataSource = DB.ds.Tables[0];
        }

        private void ButtonGroup_Click(object sender, EventArgs e)
        {
            string sql =
            "SELECT Ресурс.[НаименованиеРесурса] AS Ресурс, SUM(Потребление.Потреблено) AS [ВсегоПотреблено] " +
            "FROM Потребление " +
            "INNER JOIN Ресурс ON Потребление.Ресурс = Ресурс.[КодРесурса] " +
            "GROUP BY Ресурс.[НаименованиеРесурса]";

            DB.CreateQuery(sql);
            dataGridViewQuery.DataSource = DB.ds.Tables[0];
        }

        private void ButtonCount_Click(object sender, EventArgs e)
        {
            string sql =
                "SELECT Клиент.[ФИОКлиента] AS Клиент, Потребление.Потреблено, Ресурс.[НаименованиеРесурса] AS Ресурс, Ресурс.[СтоимостьЕдиницы] AS [СтоимостьЕдиницы], " +
                "Потребление.[ДатаНачалаПотребления], Потребление.[ДатаОкончанияПотребления], DateDiff('d', Потребление.ДатаНачалаПотребления, Потребление.ДатаОкончанияПотребления) AS [КолВоДней], " +
                "Потребление.Потреблено * Ресурс.[СтоимостьЕдиницы] AS Сумма " +
                "FROM (Потребление INNER JOIN Ресурс ON Ресурс.[КодРесурса] = Потребление.Ресурс) " +
                "INNER JOIN Клиент ON Клиент.[КодКлиента] = Потребление.Клиент";

            DB.CreateQuery(sql);
            dataGridViewQuery.DataSource = DB.ds.Tables[0];
        }

        private void ButtonCreateQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = textBoxSql.Text.Trim();

                if (string.IsNullOrWhiteSpace(sql))
                {
                    MessageBox.Show("Введите SQL запрос.");
                    return;
                }

                DB.CreateQuery(sql);
                dataGridViewQuery.DataSource = DB.ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuery.DataSource == null)
            {
                MessageBox.Show("Сначала выполните запрос.");
                return;
            }
            DB.WriteReport(DB.ds.Tables[0]);
        }
    }
}