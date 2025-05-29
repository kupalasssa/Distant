namespace WindowsFormsApp1
{
    partial class CartForm
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
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 113);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.Size = new System.Drawing.Size(375, 150);
            this.dataGridViewCart.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 266);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "label1";
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewCart);
            this.Name = "CartForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Label lblTotal;
    }
}