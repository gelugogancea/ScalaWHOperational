namespace GoWHMgmAdmin
{
    partial class frmImportArticle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportArticle));
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdImport = new System.Windows.Forms.Button();
            this.MyListView = new System.Windows.Forms.ListView();
            this.LblTotalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTotalLock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTotalUpdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTotalInsert = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbCodArticol = new System.Windows.Forms.RadioButton();
            this.rbDenumireArticol = new System.Windows.Forms.RadioButton();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbExtendGroup = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblDescOption = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSCriteria = new System.Windows.Forms.TextBox();
            this.CkLock = new System.Windows.Forms.CheckBox();
            this.LVMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiazaInClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblTotalInList = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbImpConditionat = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.LVMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(637, 437);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 9;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdImport
            // 
            this.CmdImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdImport.Location = new System.Drawing.Point(637, 406);
            this.CmdImport.Name = "CmdImport";
            this.CmdImport.Size = new System.Drawing.Size(91, 25);
            this.CmdImport.TabIndex = 8;
            this.CmdImport.Text = "&Import";
            this.CmdImport.UseVisualStyleBackColor = true;
            this.CmdImport.Click += new System.EventHandler(this.CmdImport_Click);
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(12, 54);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(716, 336);
            this.MyListView.TabIndex = 14;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseClick);
            this.MyListView.SelectedIndexChanged += new System.EventHandler(this.MyListView_SelectedIndexChanged);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // LblTotalRecords
            // 
            this.LblTotalRecords.AutoSize = true;
            this.LblTotalRecords.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalRecords.Location = new System.Drawing.Point(130, 482);
            this.LblTotalRecords.Name = "LblTotalRecords";
            this.LblTotalRecords.Size = new System.Drawing.Size(13, 13);
            this.LblTotalRecords.TabIndex = 20;
            this.LblTotalRecords.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Total Inregistrari";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTotalLock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LblTotalUpdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LblTotalInsert);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 83);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inregistrari Articole";
            // 
            // LblTotalLock
            // 
            this.LblTotalLock.AutoSize = true;
            this.LblTotalLock.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalLock.Location = new System.Drawing.Point(118, 58);
            this.LblTotalLock.Name = "LblTotalLock";
            this.LblTotalLock.Size = new System.Drawing.Size(13, 13);
            this.LblTotalLock.TabIndex = 24;
            this.LblTotalLock.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Total Lock ";
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
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Total Modificate";
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
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Total Inserate";
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(637, 9);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 25);
            this.CmdCauta.TabIndex = 5;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(63, 12);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(206, 20);
            this.txtCauta.TabIndex = 0;
            this.txtCauta.TextChanged += new System.EventHandler(this.txtCauta_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Cauta ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // rbCodArticol
            // 
            this.rbCodArticol.AutoSize = true;
            this.rbCodArticol.Location = new System.Drawing.Point(275, 13);
            this.rbCodArticol.Name = "rbCodArticol";
            this.rbCodArticol.Size = new System.Drawing.Size(76, 17);
            this.rbCodArticol.TabIndex = 1;
            this.rbCodArticol.TabStop = true;
            this.rbCodArticol.Text = "Cod Articol";
            this.rbCodArticol.UseVisualStyleBackColor = true;
            this.rbCodArticol.CheckedChanged += new System.EventHandler(this.rbCodArticol_CheckedChanged);
            // 
            // rbDenumireArticol
            // 
            this.rbDenumireArticol.AutoSize = true;
            this.rbDenumireArticol.Location = new System.Drawing.Point(348, 13);
            this.rbDenumireArticol.Name = "rbDenumireArticol";
            this.rbDenumireArticol.Size = new System.Drawing.Size(70, 17);
            this.rbDenumireArticol.TabIndex = 2;
            this.rbDenumireArticol.TabStop = true;
            this.rbDenumireArticol.Text = "Descriere";
            this.rbDenumireArticol.UseVisualStyleBackColor = true;
            this.rbDenumireArticol.CheckedChanged += new System.EventHandler(this.rbDenumireArticol_CheckedChanged);
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Location = new System.Drawing.Point(424, 13);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 3;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Grupa";
            this.rbGroup.UseVisualStyleBackColor = true;
            this.rbGroup.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // rbExtendGroup
            // 
            this.rbExtendGroup.AutoSize = true;
            this.rbExtendGroup.Location = new System.Drawing.Point(475, 13);
            this.rbExtendGroup.Name = "rbExtendGroup";
            this.rbExtendGroup.Size = new System.Drawing.Size(91, 17);
            this.rbExtendGroup.TabIndex = 4;
            this.rbExtendGroup.TabStop = true;
            this.rbExtendGroup.Text = "Grupa Extinsa";
            this.rbExtendGroup.UseVisualStyleBackColor = true;
            this.rbExtendGroup.CheckedChanged += new System.EventHandler(this.rbExtendGroup_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbImpConditionat);
            this.groupBox2.Controls.Add(this.LblDescOption);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSCriteria);
            this.groupBox2.Location = new System.Drawing.Point(185, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 83);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import Conditionat";
            // 
            // LblDescOption
            // 
            this.LblDescOption.AutoSize = true;
            this.LblDescOption.Location = new System.Drawing.Point(6, 38);
            this.LblDescOption.Name = "LblDescOption";
            this.LblDescOption.Size = new System.Drawing.Size(0, 13);
            this.LblDescOption.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Criteria";
            // 
            // txtSCriteria
            // 
            this.txtSCriteria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCriteria.Location = new System.Drawing.Point(271, 13);
            this.txtSCriteria.Name = "txtSCriteria";
            this.txtSCriteria.Size = new System.Drawing.Size(128, 20);
            this.txtSCriteria.TabIndex = 7;
            // 
            // CkLock
            // 
            this.CkLock.AutoSize = true;
            this.CkLock.BackColor = System.Drawing.SystemColors.Control;
            this.CkLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkLock.Location = new System.Drawing.Point(572, 13);
            this.CkLock.Name = "CkLock";
            this.CkLock.Size = new System.Drawing.Size(47, 17);
            this.CkLock.TabIndex = 44;
            this.CkLock.Text = "Lock";
            this.CkLock.UseVisualStyleBackColor = false;
            this.CkLock.CheckedChanged += new System.EventHandler(this.CkLock_CheckedChanged);
            // 
            // LVMenu
            // 
            this.LVMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LVMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiazaInClipBoardToolStripMenuItem});
            this.LVMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.LVMenu.Name = "LVMenu";
            this.LVMenu.Size = new System.Drawing.Size(183, 26);
            // 
            // copiazaInClipBoardToolStripMenuItem
            // 
            this.copiazaInClipBoardToolStripMenuItem.Name = "copiazaInClipBoardToolStripMenuItem";
            this.copiazaInClipBoardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copiazaInClipBoardToolStripMenuItem.Text = "Copiaza in ClipBoard";
            this.copiazaInClipBoardToolStripMenuItem.Click += new System.EventHandler(this.copiazaInClipBoardToolStripMenuItem_Click);
            // 
            // LblTotalInList
            // 
            this.LblTotalInList.AutoSize = true;
            this.LblTotalInList.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalInList.Location = new System.Drawing.Point(303, 482);
            this.LblTotalInList.Name = "LblTotalInList";
            this.LblTotalInList.Size = new System.Drawing.Size(13, 13);
            this.LblTotalInList.TabIndex = 46;
            this.LblTotalInList.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 482);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Total In List";
            // 
            // CmbImpConditionat
            // 
            this.CmbImpConditionat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbImpConditionat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbImpConditionat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbImpConditionat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbImpConditionat.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbImpConditionat.FormattingEnabled = true;
            this.CmbImpConditionat.Location = new System.Drawing.Point(9, 12);
            this.CmbImpConditionat.Name = "CmbImpConditionat";
            this.CmbImpConditionat.Size = new System.Drawing.Size(211, 21);
            this.CmbImpConditionat.TabIndex = 49;
            this.CmbImpConditionat.SelectedIndexChanged += new System.EventHandler(this.CmbImpConditionat_SelectedIndexChanged);
            // 
            // frmImportArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 504);
            this.Controls.Add(this.LblTotalInList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CkLock);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbExtendGroup);
            this.Controls.Add(this.rbGroup);
            this.Controls.Add(this.rbDenumireArticol);
            this.Controls.Add(this.rbCodArticol);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTotalRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmImportArticle";
            this.Text = "Import Articole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportArticle_FormClosed);
            this.Load += new System.EventHandler(this.frmImportArticle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.LVMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdImport;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Label LblTotalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblTotalUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTotalInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbCodArticol;
        private System.Windows.Forms.RadioButton rbDenumireArticol;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.RadioButton rbExtendGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSCriteria;
        private System.Windows.Forms.Label LblDescOption;
        private System.Windows.Forms.Label LblTotalLock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CkLock;
        private System.Windows.Forms.ContextMenuStrip LVMenu;
        private System.Windows.Forms.ToolStripMenuItem copiazaInClipBoardToolStripMenuItem;
        private MultiColumnComboBox CmbImpConditionat;
        private System.Windows.Forms.Label LblTotalInList;
        private System.Windows.Forms.Label label7;
    }
}