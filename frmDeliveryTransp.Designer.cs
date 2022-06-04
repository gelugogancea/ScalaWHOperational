namespace GoWHMgmAdmin
{
    partial class frmDeliveryTransp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CkBoxSkip = new System.Windows.Forms.CheckBox();
            this.CmbZipCode = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CkOnlyTask = new System.Windows.Forms.CheckBox();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CkSrchOrder = new System.Windows.Forms.CheckBox();
            this.txtDataCmd = new System.Windows.Forms.MaskedTextBox();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValidTo = new System.Windows.Forms.MaskedTextBox();
            this.txtValidFrom = new System.Windows.Forms.MaskedTextBox();
            this.MyListView = new System.Windows.Forms.ListView();
            this.CmdExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CkBoxSkip);
            this.groupBox1.Controls.Add(this.CmbZipCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.CkOnlyTask);
            this.groupBox1.Controls.Add(this.CmdSave);
            this.groupBox1.Controls.Add(this.CkSrchOrder);
            this.groupBox1.Controls.Add(this.txtDataCmd);
            this.groupBox1.Controls.Add(this.CmdCauta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtValidTo);
            this.groupBox1.Controls.Add(this.txtValidFrom);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 100);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // CkBoxSkip
            // 
            this.CkBoxSkip.AutoSize = true;
            this.CkBoxSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkBoxSkip.Location = new System.Drawing.Point(681, 47);
            this.CkBoxSkip.Name = "CkBoxSkip";
            this.CkBoxSkip.Size = new System.Drawing.Size(93, 17);
            this.CkBoxSkip.TabIndex = 78;
            this.CkBoxSkip.Text = "Afisez comenzi";
            this.CkBoxSkip.UseVisualStyleBackColor = true;
            // 
            // CmbZipCode
            // 
            this.CmbZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbZipCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbZipCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbZipCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbZipCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbZipCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbZipCode.FormattingEnabled = true;
            this.CmbZipCode.Location = new System.Drawing.Point(117, 75);
            this.CmbZipCode.Name = "CmbZipCode";
            this.CmbZipCode.Size = new System.Drawing.Size(218, 21);
            this.CmbZipCode.TabIndex = 77;
            this.CmbZipCode.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "ZIP";
            this.label6.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(18, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 75;
            this.checkBox1.Text = "Stare 2";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CkOnlyTask
            // 
            this.CkOnlyTask.AutoSize = true;
            this.CkOnlyTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkOnlyTask.Location = new System.Drawing.Point(521, 70);
            this.CkOnlyTask.Name = "CkOnlyTask";
            this.CkOnlyTask.Size = new System.Drawing.Size(128, 17);
            this.CkOnlyTask.TabIndex = 72;
            this.CkOnlyTask.Text = "Numai task-uri alocate";
            this.CkOnlyTask.UseVisualStyleBackColor = true;
            this.CkOnlyTask.Visible = false;
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(681, 70);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(132, 23);
            this.CmdSave.TabIndex = 68;
            this.CmdSave.Text = "Print";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CkSrchOrder
            // 
            this.CkSrchOrder.AutoSize = true;
            this.CkSrchOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkSrchOrder.Location = new System.Drawing.Point(491, 14);
            this.CkSrchOrder.Name = "CkSrchOrder";
            this.CkSrchOrder.Size = new System.Drawing.Size(88, 17);
            this.CkSrchOrder.TabIndex = 67;
            this.CkSrchOrder.Text = "Caut Comenzi";
            this.CkSrchOrder.UseVisualStyleBackColor = true;
            this.CkSrchOrder.CheckedChanged += new System.EventHandler(this.CkSrchOrder_CheckedChanged);
            // 
            // txtDataCmd
            // 
            this.txtDataCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCmd.Location = new System.Drawing.Point(491, 37);
            this.txtDataCmd.Name = "txtDataCmd";
            this.txtDataCmd.Size = new System.Drawing.Size(108, 20);
            this.txtDataCmd.TabIndex = 66;
            // 
            // CmdCauta
            // 
            this.CmdCauta.Location = new System.Drawing.Point(681, 14);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(132, 23);
            this.CmdCauta.TabIndex = 64;
            this.CmdCauta.Text = "Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Pana La  (ZZ/LL/AAAA)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "De La  (ZZ/LL/AAAA)";
            // 
            // txtValidTo
            // 
            this.txtValidTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidTo.Location = new System.Drawing.Point(395, 13);
            this.txtValidTo.Mask = "00/00/0000";
            this.txtValidTo.Name = "txtValidTo";
            this.txtValidTo.Size = new System.Drawing.Size(72, 20);
            this.txtValidTo.TabIndex = 59;
            // 
            // txtValidFrom
            // 
            this.txtValidFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFrom.Location = new System.Drawing.Point(151, 14);
            this.txtValidFrom.Mask = "00/00/0000";
            this.txtValidFrom.Name = "txtValidFrom";
            this.txtValidFrom.Size = new System.Drawing.Size(72, 20);
            this.txtValidFrom.TabIndex = 58;
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(1, 108);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(813, 325);
            this.MyListView.TabIndex = 62;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            // 
            // CmdExit
            // 
            this.CmdExit.Location = new System.Drawing.Point(688, 439);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(132, 23);
            this.CmdExit.TabIndex = 69;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // frmDeliveryTransp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(821, 463);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDeliveryTransp";
            this.ShowIcon = false;
            this.Text = "Logisitica - Incarcarea Coletelor";
            this.Load += new System.EventHandler(this.frmDeliveryTransp_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDeliveryTransp_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtValidTo;
        private System.Windows.Forms.MaskedTextBox txtValidFrom;
        private System.Windows.Forms.MaskedTextBox txtDataCmd;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.CheckBox CkSrchOrder;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.CheckBox CkOnlyTask;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.CheckBox checkBox1;
        private MultiColumnComboBox CmbZipCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CkBoxSkip;
    }
}