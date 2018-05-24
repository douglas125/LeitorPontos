namespace LeitorPontos
{
    partial class frmPontos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPontos));
            this.gridPtos = new System.Windows.Forms.DataGridView();
            this.lblEq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPtos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPtos
            // 
            this.gridPtos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPtos.Location = new System.Drawing.Point(12, 25);
            this.gridPtos.Name = "gridPtos";
            this.gridPtos.Size = new System.Drawing.Size(260, 234);
            this.gridPtos.TabIndex = 0;
            // 
            // lblEq
            // 
            this.lblEq.AutoSize = true;
            this.lblEq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEq.Location = new System.Drawing.Point(12, 7);
            this.lblEq.Name = "lblEq";
            this.lblEq.Size = new System.Drawing.Size(2, 15);
            this.lblEq.TabIndex = 2;
            // 
            // frmPontos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.lblEq);
            this.Controls.Add(this.gridPtos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPontos";
            this.Text = "Pontos adquiridos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPontos_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPontos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridPtos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView gridPtos;
        public System.Windows.Forms.Label lblEq;
    }
}