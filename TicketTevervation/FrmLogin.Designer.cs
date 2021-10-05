
namespace TicketTevervation
{
    partial class FrmLogin
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
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MskTc = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LlblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.LlblSingup = new System.Windows.Forms.LinkLabel();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(182, 195);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(216, 30);
            this.TxtPassword.TabIndex = 0;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "T.C. Kimlik No:";
            // 
            // MskTc
            // 
            this.MskTc.Location = new System.Drawing.Point(182, 159);
            this.MskTc.Mask = "00000000000";
            this.MskTc.Name = "MskTc";
            this.MskTc.Size = new System.Drawing.Size(216, 30);
            this.MskTc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre:";
            // 
            // LlblForgotPassword
            // 
            this.LlblForgotPassword.AutoSize = true;
            this.LlblForgotPassword.LinkColor = System.Drawing.Color.White;
            this.LlblForgotPassword.Location = new System.Drawing.Point(248, 238);
            this.LlblForgotPassword.Name = "LlblForgotPassword";
            this.LlblForgotPassword.Size = new System.Drawing.Size(150, 25);
            this.LlblForgotPassword.TabIndex = 4;
            this.LlblForgotPassword.TabStop = true;
            this.LlblForgotPassword.Text = "Şifremi Unuttum";
            // 
            // LlblSingup
            // 
            this.LlblSingup.AutoSize = true;
            this.LlblSingup.LinkColor = System.Drawing.Color.White;
            this.LlblSingup.Location = new System.Drawing.Point(442, 9);
            this.LlblSingup.Name = "LlblSingup";
            this.LlblSingup.Size = new System.Drawing.Size(72, 25);
            this.LlblSingup.TabIndex = 5;
            this.LlblSingup.TabStop = true;
            this.LlblSingup.Text = "Üye Ol";
            this.LlblSingup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblSingup_LinkClicked);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(106)))));
            this.BtnLogin.Location = new System.Drawing.Point(206, 282);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(164, 44);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "Giriş Yap";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(526, 456);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.LlblSingup);
            this.Controls.Add(this.LlblForgotPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MskTc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPassword);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MskTc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel LlblForgotPassword;
        private System.Windows.Forms.LinkLabel LlblSingup;
        private System.Windows.Forms.Button BtnLogin;
    }
}

