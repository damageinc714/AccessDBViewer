namespace AccessDBViewer
{
    partial class AuthForm
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
            this.LabelLogin = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelLogin
            // 
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Location = new System.Drawing.Point(185, 83);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(49, 16);
            this.LabelLogin.TabIndex = 0;
            this.LabelLogin.Text = "Логин:";
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(178, 118);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(59, 16);
            this.LabelPassword.TabIndex = 1;
            this.LabelPassword.Text = "Пароль:";
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.Location = new System.Drawing.Point(264, 80);
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(192, 22);
            this.TextBoxLogin.TabIndex = 2;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(264, 115);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(192, 22);
            this.TextBoxPassword.TabIndex = 3;
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Location = new System.Drawing.Point(244, 169);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(153, 56);
            this.ButtonLogin.TabIndex = 4;
            this.ButtonLogin.Text = "Логин";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Location = new System.Drawing.Point(244, 243);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(153, 56);
            this.ButtonRegister.TabIndex = 5;
            this.ButtonRegister.Text = "Регистрация";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(244, 371);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(153, 56);
            this.ButtonExit.TabIndex = 6;
            this.ButtonExit.Text = "Выход";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 453);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxLogin);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelLogin);
            this.Name = "AuthForm";
            this.Text = "AuthForm";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.Button ButtonExit;
    }
}