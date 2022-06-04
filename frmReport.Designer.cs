namespace GoWHMgmAdmin
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.label1 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPanaLa = new System.Windows.Forms.MaskedTextBox();
            this.txtDeLa = new System.Windows.Forms.MaskedTextBox();
            this.CmbArticol = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocSymbol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "De La ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(251, 89);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(107, 23);
            this.CmdExit.TabIndex = 91;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Pana La ";
            // 
            // CmdPrint
            // 
            this.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPrint.Location = new System.Drawing.Point(251, 47);
            this.CmdPrint.Name = "CmdPrint";
            this.CmdPrint.Size = new System.Drawing.Size(107, 23);
            this.CmdPrint.TabIndex = 96;
            this.CmdPrint.Text = "Print";
            this.CmdPrint.UseVisualStyleBackColor = true;
            this.CmdPrint.Click += new System.EventHandler(this.CmdPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Format Data : YYYY-LL-ZZ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtPanaLa
            // 
            this.txtPanaLa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPanaLa.Location = new System.Drawing.Point(251, 10);
            this.txtPanaLa.Mask = "0000-00-00";
            this.txtPanaLa.Name = "txtPanaLa";
            this.txtPanaLa.Size = new System.Drawing.Size(72, 20);
            this.txtPanaLa.TabIndex = 99;
            // 
            // txtDeLa
            // 
            this.txtDeLa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeLa.Location = new System.Drawing.Point(71, 10);
            this.txtDeLa.Mask = "0000-00-00";
            this.txtDeLa.Name = "txtDeLa";
            this.txtDeLa.Size = new System.Drawing.Size(72, 20);
            this.txtDeLa.TabIndex = 98;
            // 
            // CmbArticol
            // 
            this.CmbArticol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArticol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbArticol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbArticol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbArticol.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbArticol.FormattingEnabled = true;
            this.CmbArticol.Location = new System.Drawing.Point(71, 49);
            this.CmbArticol.Name = "CmbArticol";
            this.CmbArticol.Size = new System.Drawing.Size(174, 21);
            this.CmbArticol.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Articol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "Locatie";
            // 
            // txtLocSymbol
            // 
            this.txtLocSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocSymbol.Location = new System.Drawing.Point(70, 79);
            this.txtLocSymbol.Name = "txtLocSymbol";
            this.txtLocSymbol.Size = new System.Drawing.Size(72, 20);
            this.txtLocSymbol.TabIndex = 103;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 118);
            this.Controls.Add(this.txtLocSymbol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbArticol);
            this.Controls.Add(this.txtPanaLa);
            this.Controls.Add(this.txtDeLa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReport";
            this.Text = "Show Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReport_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CmdPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPanaLa;
        private System.Windows.Forms.MaskedTextBox txtDeLa;
        private MultiColumnComboBox CmbArticol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocSymbol;
    }
}