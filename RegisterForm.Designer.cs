namespace AccessDBViewer
{
    partial class RegisterForm
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
            this.labelNewLogin = new System.Windows.Forms.Label();
            this.labelNewPass = new System.Windows.Forms.Label();
            this.textBoxNewLogin = new System.Windows.Forms.TextBox();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.textBoxRepeatNewPass = new System.Windows.Forms.TextBox();
            this.labelRepeatNewPass = new System.Windows.Forms.Label();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNewLogin
            // 
            this.labelNewLogin.AutoSize = true;
            this.labelNewLogin.Location = new System.Drawing.Point(231, 83);
            this.labelNewLogin.Name = "labelNewLogin";
            this.labelNewLogin.Size = new System.Drawing.Size(49, 16);
            this.labelNewLogin.TabIndex = 0;
            this.labelNewLogin.Text = "Логин:";
            // 
            // labelNewPass
            // 
            this.labelNewPass.AutoSize = true;
            this.labelNewPass.Location = new System.Drawing.Point(221, 121);
            this.labelNewPass.Name = "labelNewPass";
            this.labelNewPass.Size = new System.Drawing.Size(59, 16);
            this.labelNewPass.TabIndex = 1;
            this.labelNewPass.Text = "Пароль:";
            // 
            // textBoxNewLogin
            // 
            this.textBoxNewLogin.Location = new System.Drawing.Point(288, 80);
            this.textBoxNewLogin.Name = "textBoxNewLogin";
            this.textBoxNewLogin.Size = new System.Drawing.Size(216, 22);
            this.textBoxNewLogin.TabIndex = 2;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(288, 118);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.Size = new System.Drawing.Size(216, 22);
            this.textBoxNewPass.TabIndex = 3;
            // 
            // textBoxRepeatNewPass
            // 
            this.textBoxRepeatNewPass.Location = new System.Drawing.Point(288, 158);
            this.textBoxRepeatNewPass.Name = "textBoxRepeatNewPass";
            this.textBoxRepeatNewPass.Size = new System.Drawing.Size(216, 22);
            this.textBoxRepeatNewPass.TabIndex = 4;
            // 
            // labelRepeatNewPass
            // 
            this.labelRepeatNewPass.AutoSize = true;
            this.labelRepeatNewPass.Location = new System.Drawing.Point(148, 161);
            this.labelRepeatNewPass.Name = "labelRepeatNewPass";
            this.labelRepeatNewPass.Size = new System.Drawing.Size(132, 16);
            this.labelRepeatNewPass.TabIndex = 5;
            this.labelRepeatNewPass.Text = "Повторите пароль:";
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Location = new System.Drawing.Point(265, 213);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(188, 71);
            this.ButtonRegister.TabIndex = 6;
            this.ButtonRegister.Text = "Регистрация";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(265, 300);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(188, 71);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 451);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.labelRepeatNewPass);
            this.Controls.Add(this.textBoxRepeatNewPass);
            this.Controls.Add(this.textBoxNewPass);
            this.Controls.Add(this.textBoxNewLogin);
            this.Controls.Add(this.labelNewPass);
            this.Controls.Add(this.labelNewLogin);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewLogin;
        private System.Windows.Forms.Label labelNewPass;
        private System.Windows.Forms.TextBox textBoxNewLogin;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.TextBox textBoxRepeatNewPass;
        private System.Windows.Forms.Label labelRepeatNewPass;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.Button ButtonCancel;
    }
}