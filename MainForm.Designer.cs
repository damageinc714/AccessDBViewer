namespace AccessDBViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.tabPageQuery = new System.Windows.Forms.TabPage();
            this.dataGridViewQuery = new System.Windows.Forms.DataGridView();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.labelPickTable = new System.Windows.Forms.Label();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonCount = new System.Windows.Forms.Button();
            this.ButtonGroup = new System.Windows.Forms.Button();
            this.ButtonInexact = new System.Windows.Forms.Button();
            this.ButtonExact = new System.Windows.Forms.Button();
            this.ButtonCreateQuery = new System.Windows.Forms.Button();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.ButtonReport = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            this.tabPageQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageTables);
            this.tabControlMain.Controls.Add(this.tabPageQuery);
            this.tabControlMain.Location = new System.Drawing.Point(13, 13);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(822, 370);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.dataGridViewTables);
            this.tabPageTables.Location = new System.Drawing.Point(4, 25);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(814, 341);
            this.tabPageTables.TabIndex = 0;
            this.tabPageTables.Text = "Таблицы";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTables
            // 
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTables.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersWidth = 51;
            this.dataGridViewTables.RowTemplate.Height = 24;
            this.dataGridViewTables.Size = new System.Drawing.Size(808, 335);
            this.dataGridViewTables.TabIndex = 0;
            // 
            // tabPageQuery
            // 
            this.tabPageQuery.Controls.Add(this.dataGridViewQuery);
            this.tabPageQuery.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuery.Name = "tabPageQuery";
            this.tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuery.Size = new System.Drawing.Size(814, 341);
            this.tabPageQuery.TabIndex = 1;
            this.tabPageQuery.Text = "Запросы";
            this.tabPageQuery.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQuery
            // 
            this.dataGridViewQuery.AllowUserToAddRows = false;
            this.dataGridViewQuery.AllowUserToDeleteRows = false;
            this.dataGridViewQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQuery.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewQuery.Name = "dataGridViewQuery";
            this.dataGridViewQuery.ReadOnly = true;
            this.dataGridViewQuery.RowHeadersWidth = 51;
            this.dataGridViewQuery.RowTemplate.Height = 24;
            this.dataGridViewQuery.Size = new System.Drawing.Size(808, 335);
            this.dataGridViewQuery.TabIndex = 1;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(155, 405);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(155, 24);
            this.comboBoxTables.TabIndex = 1;
            // 
            // labelPickTable
            // 
            this.labelPickTable.AutoSize = true;
            this.labelPickTable.Location = new System.Drawing.Point(16, 408);
            this.labelPickTable.Name = "labelPickTable";
            this.labelPickTable.Size = new System.Drawing.Size(133, 16);
            this.labelPickTable.TabIndex = 2;
            this.labelPickTable.Text = "Выберите таблицу:";
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(536, 405);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(122, 46);
            this.ButtonOpen.TabIndex = 3;
            this.ButtonOpen.Text = "Открыть";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(688, 405);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(122, 46);
            this.ButtonDelete.TabIndex = 4;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(688, 472);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(122, 46);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(536, 472);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(122, 46);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(20, 472);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(122, 46);
            this.ButtonExit.TabIndex = 7;
            this.ButtonExit.Text = "Выход";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonCount
            // 
            this.ButtonCount.Location = new System.Drawing.Point(713, 472);
            this.ButtonCount.Name = "ButtonCount";
            this.ButtonCount.Size = new System.Drawing.Size(122, 46);
            this.ButtonCount.TabIndex = 11;
            this.ButtonCount.Text = "Вычисляемое поле";
            this.ButtonCount.UseVisualStyleBackColor = true;
            this.ButtonCount.Click += new System.EventHandler(this.ButtonCount_Click);
            // 
            // ButtonGroup
            // 
            this.ButtonGroup.Location = new System.Drawing.Point(713, 405);
            this.ButtonGroup.Name = "ButtonGroup";
            this.ButtonGroup.Size = new System.Drawing.Size(122, 46);
            this.ButtonGroup.TabIndex = 10;
            this.ButtonGroup.Text = "Группировка";
            this.ButtonGroup.UseVisualStyleBackColor = true;
            this.ButtonGroup.Click += new System.EventHandler(this.ButtonGroup_Click);
            // 
            // ButtonInexact
            // 
            this.ButtonInexact.Location = new System.Drawing.Point(560, 472);
            this.ButtonInexact.Name = "ButtonInexact";
            this.ButtonInexact.Size = new System.Drawing.Size(122, 46);
            this.ButtonInexact.TabIndex = 9;
            this.ButtonInexact.Text = "Неточное попадание";
            this.ButtonInexact.UseVisualStyleBackColor = true;
            this.ButtonInexact.Click += new System.EventHandler(this.ButtonInexact_Click);
            // 
            // ButtonExact
            // 
            this.ButtonExact.Location = new System.Drawing.Point(560, 405);
            this.ButtonExact.Name = "ButtonExact";
            this.ButtonExact.Size = new System.Drawing.Size(122, 46);
            this.ButtonExact.TabIndex = 8;
            this.ButtonExact.Text = "Точное попадание";
            this.ButtonExact.UseVisualStyleBackColor = true;
            this.ButtonExact.Click += new System.EventHandler(this.ButtonExact_Click);
            // 
            // ButtonCreateQuery
            // 
            this.ButtonCreateQuery.Location = new System.Drawing.Point(20, 405);
            this.ButtonCreateQuery.Name = "ButtonCreateQuery";
            this.ButtonCreateQuery.Size = new System.Drawing.Size(122, 46);
            this.ButtonCreateQuery.TabIndex = 12;
            this.ButtonCreateQuery.Text = "Создать запрос";
            this.ButtonCreateQuery.UseVisualStyleBackColor = true;
            this.ButtonCreateQuery.Click += new System.EventHandler(this.ButtonCreateQuery_Click);
            // 
            // textBoxSql
            // 
            this.textBoxSql.AcceptsReturn = true;
            this.textBoxSql.AcceptsTab = true;
            this.textBoxSql.Location = new System.Drawing.Point(165, 405);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSql.Size = new System.Drawing.Size(244, 113);
            this.textBoxSql.TabIndex = 13;
            this.textBoxSql.WordWrap = false;
            // 
            // ButtonReport
            // 
            this.ButtonReport.Location = new System.Drawing.Point(432, 405);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(107, 113);
            this.ButtonReport.TabIndex = 14;
            this.ButtonReport.Text = " Напечатать отчет";
            this.ButtonReport.UseVisualStyleBackColor = true;
            this.ButtonReport.Click += new System.EventHandler(this.ButtonReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 545);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonReport);
            this.Controls.Add(this.textBoxSql);
            this.Controls.Add(this.ButtonCreateQuery);
            this.Controls.Add(this.ButtonCount);
            this.Controls.Add(this.ButtonGroup);
            this.Controls.Add(this.ButtonInexact);
            this.Controls.Add(this.ButtonExact);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.labelPickTable);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            this.tabPageQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageQuery;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label labelPickTable;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.DataGridView dataGridViewQuery;
        private System.Windows.Forms.Button ButtonCount;
        private System.Windows.Forms.Button ButtonGroup;
        private System.Windows.Forms.Button ButtonInexact;
        private System.Windows.Forms.Button ButtonExact;
        private System.Windows.Forms.Button ButtonCreateQuery;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.Button ButtonReport;
    }
}