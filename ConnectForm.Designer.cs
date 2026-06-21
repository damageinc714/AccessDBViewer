namespace AccessDBViewer
{
    partial class ConnectForm
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
            this.DatabasePath = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatabasePath
            // 
            this.DatabasePath.Location = new System.Drawing.Point(94, 64);
            this.DatabasePath.Name = "DatabasePath";
            this.DatabasePath.Size = new System.Drawing.Size(417, 22);
            this.DatabasePath.TabIndex = 0;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(210, 106);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(162, 61);
            this.ButtonBrowse.TabIndex = 1;
            this.ButtonBrowse.Text = "Обзор";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(210, 184);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(162, 61);
            this.ButtonConnect.TabIndex = 2;
            this.ButtonConnect.Text = "Подключиться";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(210, 328);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(162, 61);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Выход";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 423);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.DatabasePath);
            this.Name = "ConnectForm";
            this.Text = "ConnectForm";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DatabasePath;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonExit;
    }
}