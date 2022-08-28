namespace InventtManage
{
    partial class Customers
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
            this.customButtons1 = new InventtManage.CustomButtons();
            ((System.ComponentModel.ISupportInitialize)(this.customButtons1)).BeginInit();
            this.SuspendLayout();
            // 
            // customButtons1
            // 
            this.customButtons1.ImageHover = null;
            this.customButtons1.ImageNormal = null;
            this.customButtons1.Location = new System.Drawing.Point(399, 72);
            this.customButtons1.Name = "customButtons1";
            this.customButtons1.Size = new System.Drawing.Size(158, 135);
            this.customButtons1.TabIndex = 0;
            this.customButtons1.TabStop = false;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customButtons1);
            this.Name = "Customers";
            this.Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)(this.customButtons1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButtons customButtons1;
    }
}