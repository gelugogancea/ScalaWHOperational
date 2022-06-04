namespace GoWHMgmAdmin
{
    partial class frmImportWareHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportWareHouse));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTotalUpdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTotalInsert = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTotalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdImport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTotalUpdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LblTotalInsert);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 60);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affected Records";
            // 
            // LblTotalUpdate
            // 
            this.LblTotalUpdate.AutoSize = true;
            this.LblTotalUpdate.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalUpdate.Location = new System.Drawing.Point(118, 37);
            this.LblTotalUpdate.Name = "LblTotalUpdate";
            this.LblTotalUpdate.Size = new System.Drawing.Size(13, 13);
            this.LblTotalUpdate.TabIndex = 22;
            this.LblTotalUpdate.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Total Update Records";
            // 
            // LblTotalInsert
            // 
            this.LblTotalInsert.AutoSize = true;
            this.LblTotalInsert.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalInsert.Location = new System.Drawing.Point(118, 15);
            this.LblTotalInsert.Name = "LblTotalInsert";
            this.LblTotalInsert.Size = new System.Drawing.Size(13, 13);
            this.LblTotalInsert.TabIndex = 20;
            this.LblTotalInsert.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Total Insert Records";
            // 
            // LblTotalRecords
            // 
            this.LblTotalRecords.AutoSize = true;
            this.LblTotalRecords.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalRecords.Location = new System.Drawing.Point(130, 412);
            this.LblTotalRecords.Name = "LblTotalRecords";
            this.LblTotalRecords.Size = new System.Drawing.Size(13, 13);
            this.LblTotalRecords.TabIndex = 26;
            this.LblTotalRecords.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Total Records";
            // 
            // MyListView
            // 
            this.MyListView.Location = new System.Drawing.Point(12, 12);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(716, 336);
            this.MyListView.TabIndex = 24;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(637, 385);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 23;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdImport
            // 
            this.CmdImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdImport.Location = new System.Drawing.Point(637, 354);
            this.CmdImport.Name = "CmdImport";
            this.CmdImport.Size = new System.Drawing.Size(91, 25);
            this.CmdImport.TabIndex = 22;
            this.CmdImport.Text = "&Import";
            this.CmdImport.UseVisualStyleBackColor = true;
            this.CmdImport.Click += new System.EventHandler(this.CmdImport_Click);
            // 
            // frmImportWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTotalRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmImportWareHouse";
            this.Text = "Import WareHouse";
            this.Load += new System.EventHandler(this.frmImportWareHouse_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportWareHouse_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblTotalUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTotalInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdImport;
    }
}