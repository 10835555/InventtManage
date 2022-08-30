namespace InventtManage
{
    partial class UserSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSignIn));
            this.label7 = new System.Windows.Forms.Label();
            this.UShowPassword = new System.Windows.Forms.CheckBox();
            this.ULoginButton = new System.Windows.Forms.Button();
            this.txtUserUN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Unispace", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(311, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 44);
            this.label7.TabIndex = 29;
            this.label7.Text = "CASHIER";
            // 
            // UShowPassword
            // 
            this.UShowPassword.AutoSize = true;
            this.UShowPassword.Checked = true;
            this.UShowPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UShowPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UShowPassword.Location = new System.Drawing.Point(450, 390);
            this.UShowPassword.Name = "UShowPassword";
            this.UShowPassword.Size = new System.Drawing.Size(128, 23);
            this.UShowPassword.TabIndex = 28;
            this.UShowPassword.Text = "Show password";
            this.UShowPassword.UseVisualStyleBackColor = true;
            this.UShowPassword.CheckedChanged += new System.EventHandler(this.UShowPassword_CheckedChanged);
            // 
            // ULoginButton
            // 
            this.ULoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ULoginButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ULoginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ULoginButton.Location = new System.Drawing.Point(319, 418);
            this.ULoginButton.Name = "ULoginButton";
            this.ULoginButton.Size = new System.Drawing.Size(116, 34);
            this.ULoginButton.TabIndex = 27;
            this.ULoginButton.Text = "Login";
            this.ULoginButton.UseVisualStyleBackColor = false;
            this.ULoginButton.Click += new System.EventHandler(this.ULoginButton_Click);
            // 
            // txtUserUN
            // 
            this.txtUserUN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserUN.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserUN.Location = new System.Drawing.Point(307, 321);
            this.txtUserUN.Name = "txtUserUN";
            this.txtUserUN.Size = new System.Drawing.Size(211, 26);
            this.txtUserUN.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Username";
            // 
            // txtUPassword
            // 
            this.txtUPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUPassword.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPassword.Location = new System.Drawing.Point(307, 363);
            this.txtUPassword.Name = "txtUPassword";
            this.txtUPassword.Size = new System.Drawing.Size(211, 26);
            this.txtUPassword.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Inventory Management System";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::InventtManage.Properties.Resources.go_back_30px;
            this.pictureBox3.Location = new System.Drawing.Point(12, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(235, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // UserSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 469);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UShowPassword);
            this.Controls.Add(this.ULoginButton);
            this.Controls.Add(this.txtUserUN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "UserSignIn";
            this.Text = "UserSignIn";
            this.Load += new System.EventHandler(this.UserSignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox UShowPassword;
        private System.Windows.Forms.Button ULoginButton;
        private System.Windows.Forms.TextBox txtUserUN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}