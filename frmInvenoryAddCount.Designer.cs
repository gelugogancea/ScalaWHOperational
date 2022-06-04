namespace GoWHMgmAdmin
{
    partial class frmInvenoryAddCount
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
            this.MyListView = new System.Windows.Forms.ListView();
            this.grpAddCount = new System.Windows.Forms.GroupBox();
            this.LblArtDescription = new System.Windows.Forms.Label();
            this.txtListNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmdCaut = new System.Windows.Forms.Button();
            this.CkCloseCounting = new System.Windows.Forms.CheckBox();
            this.CmdSaveQty = new System.Windows.Forms.Button();
            this.CmbCountOper = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CMbArticole = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblWH = new System.Windows.Forms.Label();
            this.LblArea = new System.Windows.Forms.Label();
            this.Cmd3DLoc = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFinalizeCounting = new System.Windows.Forms.GroupBox();
            this.CkAutoValidate = new System.Windows.Forms.CheckBox();
            this.LblWHCODE = new System.Windows.Forms.Label();
            this.CkCloseValidation = new System.Windows.Forms.CheckBox();
            this.CmdCautareValidare = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.LblCountNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblQty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmdValidare = new System.Windows.Forms.Button();
            this.txtArticleCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CkNeuron = new System.Windows.Forms.CheckBox();
            this.grpAddCount.SuspendLayout();
            this.grpFinalizeCounting.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(12, 12);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(702, 210);
            this.MyListView.TabIndex = 0;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.SelectedIndexChanged += new System.EventHandler(this.MyListView_SelectedIndexChanged);
            // 
            // grpAddCount
            // 
            this.grpAddCount.Controls.Add(this.LblArtDescription);
            this.grpAddCount.Controls.Add(this.txtListNo);
            this.grpAddCount.Controls.Add(this.label9);
            this.grpAddCount.Controls.Add(this.CmdCaut);
            this.grpAddCount.Controls.Add(this.CkCloseCounting);
            this.grpAddCount.Controls.Add(this.CmdSaveQty);
            this.grpAddCount.Controls.Add(this.CmbCountOper);
            this.grpAddCount.Controls.Add(this.label6);
            this.grpAddCount.Controls.Add(this.txtQty);
            this.grpAddCount.Controls.Add(this.label5);
            this.grpAddCount.Controls.Add(this.CMbArticole);
            this.grpAddCount.Controls.Add(this.label4);
            this.grpAddCount.Controls.Add(this.LblWH);
            this.grpAddCount.Controls.Add(this.LblArea);
            this.grpAddCount.Controls.Add(this.Cmd3DLoc);
            this.grpAddCount.Controls.Add(this.label1);
            this.grpAddCount.Location = new System.Drawing.Point(15, 228);
            this.grpAddCount.Name = "grpAddCount";
            this.grpAddCount.Size = new System.Drawing.Size(700, 156);
            this.grpAddCount.TabIndex = 11;
            this.grpAddCount.TabStop = false;
            this.grpAddCount.Text = "Operatii de Raportare Inventar";
            // 
            // LblArtDescription
            // 
            this.LblArtDescription.AutoSize = true;
            this.LblArtDescription.Location = new System.Drawing.Point(217, 20);
            this.LblArtDescription.Name = "LblArtDescription";
            this.LblArtDescription.Size = new System.Drawing.Size(10, 13);
            this.LblArtDescription.TabIndex = 60;
            this.LblArtDescription.Text = "-";
            // 
            // txtListNo
            // 
            this.txtListNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtListNo.Location = new System.Drawing.Point(304, 69);
            this.txtListNo.Name = "txtListNo";
            this.txtListNo.Size = new System.Drawing.Size(43, 20);
            this.txtListNo.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Nr.Lista";
            // 
            // CmdCaut
            // 
            this.CmdCaut.Location = new System.Drawing.Point(613, 15);
            this.CmdCaut.Name = "CmdCaut";
            this.CmdCaut.Size = new System.Drawing.Size(74, 23);
            this.CmdCaut.TabIndex = 2;
            this.CmdCaut.Text = "Cautare";
            this.CmdCaut.UseVisualStyleBackColor = true;
            this.CmdCaut.Click += new System.EventHandler(this.CmdCaut_Click);
            // 
            // CkCloseCounting
            // 
            this.CkCloseCounting.AutoSize = true;
            this.CkCloseCounting.Location = new System.Drawing.Point(12, 126);
            this.CkCloseCounting.Name = "CkCloseCounting";
            this.CkCloseCounting.Size = new System.Drawing.Size(187, 17);
            this.CkCloseCounting.TabIndex = 7;
            this.CkCloseCounting.Text = "Inchiderea procedurii de numarare";
            this.CkCloseCounting.UseVisualStyleBackColor = true;
            this.CkCloseCounting.Click += new System.EventHandler(this.CkCloseCounting_Click);
            // 
            // CmdSaveQty
            // 
            this.CmdSaveQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSaveQty.Location = new System.Drawing.Point(232, 122);
            this.CmdSaveQty.Name = "CmdSaveQty";
            this.CmdSaveQty.Size = new System.Drawing.Size(115, 23);
            this.CmdSaveQty.TabIndex = 8;
            this.CmdSaveQty.Text = "Salvare";
            this.CmdSaveQty.UseVisualStyleBackColor = true;
            this.CmdSaveQty.Click += new System.EventHandler(this.CmdSaveQty_Click);
            this.CmdSaveQty.Leave += new System.EventHandler(this.CmdSaveQty_Leave);
            // 
            // CmbCountOper
            // 
            this.CmbCountOper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCountOper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbCountOper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbCountOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbCountOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbCountOper.FormattingEnabled = true;
            this.CmbCountOper.Location = new System.Drawing.Point(79, 95);
            this.CmbCountOper.Name = "CmbCountOper";
            this.CmbCountOper.Size = new System.Drawing.Size(268, 21);
            this.CmbCountOper.TabIndex = 6;
            this.CmbCountOper.Leave += new System.EventHandler(this.CmbCountOper_Leave);
            this.CmbCountOper.GotFocus += new System.EventHandler(this.CmbCountOper_GotFocus);
            this.CmbCountOper.TextChanged += new System.EventHandler(this.CmbCountOper_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Operator";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(79, 69);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(78, 20);
            this.txtQty.TabIndex = 4;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Cantitate";
            // 
            // CMbArticole
            // 
            this.CMbArticole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMbArticole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CMbArticole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CMbArticole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMbArticole.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMbArticole.FormattingEnabled = true;
            this.CMbArticole.Location = new System.Drawing.Point(79, 15);
            this.CMbArticole.Name = "CMbArticole";
            this.CMbArticole.Size = new System.Drawing.Size(132, 21);
            this.CMbArticole.TabIndex = 1;
            this.CMbArticole.SelectedIndexChanged += new System.EventHandler(this.CMbArticole_SelectedIndexChanged);
            this.CMbArticole.Leave += new System.EventHandler(this.CMbArticole_Leave);
            this.CMbArticole.GotFocus += new System.EventHandler(this.CMbArticole_GotFocus);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Cod Articol";
            // 
            // LblWH
            // 
            this.LblWH.AutoSize = true;
            this.LblWH.Location = new System.Drawing.Point(242, 46);
            this.LblWH.Name = "LblWH";
            this.LblWH.Size = new System.Drawing.Size(10, 13);
            this.LblWH.TabIndex = 46;
            this.LblWH.Text = "-";
            // 
            // LblArea
            // 
            this.LblArea.AutoSize = true;
            this.LblArea.Location = new System.Drawing.Point(163, 46);
            this.LblArea.Name = "LblArea";
            this.LblArea.Size = new System.Drawing.Size(10, 13);
            this.LblArea.TabIndex = 45;
            this.LblArea.Text = "-";
            // 
            // Cmd3DLoc
            // 
            this.Cmd3DLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmd3DLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Cmd3DLoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Cmd3DLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd3DLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Cmd3DLoc.FormattingEnabled = true;
            this.Cmd3DLoc.Location = new System.Drawing.Point(79, 42);
            this.Cmd3DLoc.Name = "Cmd3DLoc";
            this.Cmd3DLoc.Size = new System.Drawing.Size(78, 21);
            this.Cmd3DLoc.TabIndex = 3;
            this.Cmd3DLoc.SelectedIndexChanged += new System.EventHandler(this.Cmd3DLoc_SelectedIndexChanged);
            this.Cmd3DLoc.Leave += new System.EventHandler(this.Cmd3DLoc_Leave);
            this.Cmd3DLoc.GotFocus += new System.EventHandler(this.Cmd3DLoc_GotFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Adresa Loc.";
            // 
            // grpFinalizeCounting
            // 
            this.grpFinalizeCounting.Controls.Add(this.CkAutoValidate);
            this.grpFinalizeCounting.Controls.Add(this.LblWHCODE);
            this.grpFinalizeCounting.Controls.Add(this.CkCloseValidation);
            this.grpFinalizeCounting.Controls.Add(this.CmdCautareValidare);
            this.grpFinalizeCounting.Controls.Add(this.LblInfo);
            this.grpFinalizeCounting.Controls.Add(this.LblCountNo);
            this.grpFinalizeCounting.Controls.Add(this.label10);
            this.grpFinalizeCounting.Controls.Add(this.LblQty);
            this.grpFinalizeCounting.Controls.Add(this.label8);
            this.grpFinalizeCounting.Controls.Add(this.CmdValidare);
            this.grpFinalizeCounting.Controls.Add(this.txtArticleCode);
            this.grpFinalizeCounting.Controls.Add(this.label7);
            this.grpFinalizeCounting.Location = new System.Drawing.Point(464, 390);
            this.grpFinalizeCounting.Name = "grpFinalizeCounting";
            this.grpFinalizeCounting.Size = new System.Drawing.Size(75, 57);
            this.grpFinalizeCounting.TabIndex = 12;
            this.grpFinalizeCounting.TabStop = false;
            this.grpFinalizeCounting.Text = "Validarea Cantitatilor Inventariate";
            this.grpFinalizeCounting.Visible = false;
            // 
            // CkAutoValidate
            // 
            this.CkAutoValidate.AutoSize = true;
            this.CkAutoValidate.Location = new System.Drawing.Point(6, 103);
            this.CkAutoValidate.Name = "CkAutoValidate";
            this.CkAutoValidate.Size = new System.Drawing.Size(89, 17);
            this.CkAutoValidate.TabIndex = 12;
            this.CkAutoValidate.Text = "Validare Auto";
            this.CkAutoValidate.UseVisualStyleBackColor = true;
            // 
            // LblWHCODE
            // 
            this.LblWHCODE.AutoSize = true;
            this.LblWHCODE.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblWHCODE.Location = new System.Drawing.Point(303, 79);
            this.LblWHCODE.Name = "LblWHCODE";
            this.LblWHCODE.Size = new System.Drawing.Size(10, 13);
            this.LblWHCODE.TabIndex = 63;
            this.LblWHCODE.Text = "-";
            // 
            // CkCloseValidation
            // 
            this.CkCloseValidation.AutoSize = true;
            this.CkCloseValidation.Location = new System.Drawing.Point(6, 126);
            this.CkCloseValidation.Name = "CkCloseValidation";
            this.CkCloseValidation.Size = new System.Drawing.Size(180, 17);
            this.CkCloseValidation.TabIndex = 13;
            this.CkCloseValidation.Text = "Inchiderea procedurii de validare";
            this.CkCloseValidation.UseVisualStyleBackColor = true;
            this.CkCloseValidation.Click += new System.EventHandler(this.CkCloseValidation_Click);
            // 
            // CmdCautareValidare
            // 
            this.CmdCautareValidare.Location = new System.Drawing.Point(257, 17);
            this.CmdCautareValidare.Name = "CmdCautareValidare";
            this.CmdCautareValidare.Size = new System.Drawing.Size(56, 23);
            this.CmdCautareValidare.TabIndex = 11;
            this.CmdCautareValidare.Text = "Cautare";
            this.CmdCautareValidare.UseVisualStyleBackColor = true;
            this.CmdCautareValidare.Click += new System.EventHandler(this.CmdCautareValidare_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblInfo.Location = new System.Drawing.Point(13, 79);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(10, 13);
            this.LblInfo.TabIndex = 62;
            this.LblInfo.Text = "-";
            // 
            // LblCountNo
            // 
            this.LblCountNo.AutoSize = true;
            this.LblCountNo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblCountNo.Location = new System.Drawing.Point(264, 50);
            this.LblCountNo.Name = "LblCountNo";
            this.LblCountNo.Size = new System.Drawing.Size(10, 13);
            this.LblCountNo.TabIndex = 61;
            this.LblCountNo.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(195, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Numarat";
            // 
            // LblQty
            // 
            this.LblQty.AutoSize = true;
            this.LblQty.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblQty.Location = new System.Drawing.Point(82, 50);
            this.LblQty.Name = "LblQty";
            this.LblQty.Size = new System.Drawing.Size(10, 13);
            this.LblQty.TabIndex = 59;
            this.LblQty.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Cantitate";
            // 
            // CmdValidare
            // 
            this.CmdValidare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdValidare.Location = new System.Drawing.Point(198, 122);
            this.CmdValidare.Name = "CmdValidare";
            this.CmdValidare.Size = new System.Drawing.Size(115, 23);
            this.CmdValidare.TabIndex = 14;
            this.CmdValidare.Text = "Validare";
            this.CmdValidare.UseVisualStyleBackColor = true;
            this.CmdValidare.Click += new System.EventHandler(this.CmdValidare_Click);
            // 
            // txtArticleCode
            // 
            this.txtArticleCode.Location = new System.Drawing.Point(85, 19);
            this.txtArticleCode.Name = "txtArticleCode";
            this.txtArticleCode.Size = new System.Drawing.Size(166, 20);
            this.txtArticleCode.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Cod Articol";
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(587, 390);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(115, 23);
            this.CmdExit.TabIndex = 9;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CkNeuron
            // 
            this.CkNeuron.AutoSize = true;
            this.CkNeuron.Location = new System.Drawing.Point(27, 394);
            this.CkNeuron.Name = "CkNeuron";
            this.CkNeuron.Size = new System.Drawing.Size(61, 17);
            this.CkNeuron.TabIndex = 13;
            this.CkNeuron.Text = "Neuron";
            this.CkNeuron.UseVisualStyleBackColor = true;
            // 
            // frmInvenoryAddCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 417);
            this.Controls.Add(this.CkNeuron);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.grpFinalizeCounting);
            this.Controls.Add(this.grpAddCount);
            this.Controls.Add(this.MyListView);
            this.MaximizeBox = false;
            this.Name = "frmInvenoryAddCount";
            this.ShowIcon = false;
            this.Text = "Introducere Rezultate Inventar";
            this.Load += new System.EventHandler(this.frmInvenoryAddCount_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInvenoryAddCount_FormClosed);
            this.grpAddCount.ResumeLayout(false);
            this.grpAddCount.PerformLayout();
            this.grpFinalizeCounting.ResumeLayout(false);
            this.grpFinalizeCounting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.GroupBox grpAddCount;
        private System.Windows.Forms.GroupBox grpFinalizeCounting;
        private MultiColumnComboBox Cmd3DLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblWH;
        private System.Windows.Forms.Label LblArea;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private MultiColumnComboBox CMbArticole;
        private System.Windows.Forms.Label label4;
        private MultiColumnComboBox CmbCountOper;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CmdSaveQty;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.CheckBox CkCloseCounting;
        private System.Windows.Forms.Label LblQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CmdValidare;
        private System.Windows.Forms.TextBox txtArticleCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Label LblCountNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button CmdCaut;
        private System.Windows.Forms.Button CmdCautareValidare;
        private System.Windows.Forms.CheckBox CkCloseValidation;
        private System.Windows.Forms.Label LblWHCODE;
        private System.Windows.Forms.CheckBox CkAutoValidate;
        private System.Windows.Forms.TextBox txtListNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblArtDescription;
        private System.Windows.Forms.CheckBox CkNeuron;

    }
}