namespace InventtManage
{
    partial class LoginTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginTo));
            this.ALB = new System.Windows.Forms.Button();
            this.ULB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ACAB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ALB
            // 
            this.ALB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ALB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ALB.Location = new System.Drawing.Point(238, 366);
            this.ALB.Name = "ALB";
            this.ALB.Size = new System.Drawing.Size(308, 34);
            this.ALB.TabIndex = 8;
            this.ALB.Text = "Login to Admin";
            this.ALB.UseVisualStyleBackColor = false;
            this.ALB.Click += new System.EventHandler(this.ACAB_Click);
            // 
            // ULB
            // 
            this.ULB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ULB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ULB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ULB.Location = new System.Drawing.Point(238, 406);
            this.ULB.Name = "ULB";
            this.ULB.Size = new System.Drawing.Size(308, 34);
            this.ULB.TabIndex = 8;
            this.ULB.Text = "Login to Cashier";
            this.ULB.UseVisualStyleBackColor = false;
            this.ULB.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Inventory Management System";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Unispace", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(201, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(387, 44);
            this.label7.TabIndex = 21;
            this.label7.Text = "Login To Account";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(253, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ACAB
            // 
            this.ACAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ACAB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACAB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ACAB.Location = new System.Drawing.Point(238, 326);
            this.ACAB.Name = "ACAB";
            this.ACAB.Size = new System.Drawing.Size(308, 34);
            this.ACAB.TabIndex = 8;
            this.ACAB.Text = "Create Admin";
            this.ACAB.UseVisualStyleBackColor = false;
            this.ACAB.Click += new System.EventHandler(this.ACAB_Click_1);
            // 
            // LoginTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ULB);
            this.Controls.Add(this.ACAB);
            this.Controls.Add(this.ALB);
            this.Name = "LoginTo";
            this.Text = "LoginTo";
            this.Load += new System.EventHandler(this.LoginTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ALB;
        private System.Windows.Forms.Button ULB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ACAB;
    }
}