namespace GoWHMgmAdmin
{
    partial class frmViewInventorySetParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewInventorySetParam));
            this.label1 = new System.Windows.Forms.Label();
            this.txtValidFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtInventoryNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmdView = new System.Windows.Forms.Button();
            this.CmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data Inventar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtValidFrom
            // 
            this.txtValidFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFrom.Location = new System.Drawing.Point(100, 49);
            this.txtValidFrom.Mask = "00/00/0000";
            this.txtValidFrom.Name = "txtValidFrom";
            this.txtValidFrom.Size = new System.Drawing.Size(72, 20);
            this.txtValidFrom.TabIndex = 8;
            this.txtValidFrom.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtValidFrom_MaskInputRejected);
            // 
            // txtInventoryNo
            // 
            this.txtInventoryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventoryNo.Location = new System.Drawing.Point(100, 12);
            this.txtInventoryNo.Name = "txtInventoryNo";
            this.txtInventoryNo.Size = new System.Drawing.Size(72, 20);
            this.txtInventoryNo.TabIndex = 16;
            this.txtInventoryNo.TextChanged += new System.EventHandler(this.txtInitPass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numar Inventar";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CmdView
            // 
            this.CmdView.Location = new System.Drawing.Point(247, 12);
            this.CmdView.Name = "CmdView";
            this.CmdView.Size = new System.Drawing.Size(132, 23);
            this.CmdView.TabIndex = 18;
            this.CmdView.Text = "Vizualizare";
            this.CmdView.UseVisualStyleBackColor = true;
            this.CmdView.Click += new System.EventHandler(this.CmdView_Click);
            // 
            // CmdExit
            // 
            this.CmdExit.Location = new System.Drawing.Point(247, 51);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(132, 23);
            this.CmdExit.TabIndex = 17;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // frmViewInventorySetParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 83);
            this.Controls.Add(this.CmdView);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.txtInventoryNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValidFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewInventorySetParam";
            this.Text = "Vizualizare Inventar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewInventorySetParam_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtValidFrom;
        private System.Windows.Forms.TextBox txtInventoryNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CmdView;
        private System.Windows.Forms.Button CmdExit;

    }
}