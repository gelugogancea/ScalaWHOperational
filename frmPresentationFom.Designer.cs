namespace GoWHMgmAdmin
{
    partial class frmPresentationFom
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
            this.MyListView = new System.Windows.Forms.ListView();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSalvez = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CkAmbalaj = new System.Windows.Forms.CheckBox();
            this.LblARDescrieri = new System.Windows.Forms.Label();
            this.LblDPartener = new System.Windows.Forms.Label();
            this.CmbArticol = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CkImpartire = new System.Windows.Forms.CheckBox();
            this.CkInmultire = new System.Windows.Forms.CheckBox();
            this.txtCoeficient = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbUOM = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantitate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CkPartType = new System.Windows.Forms.CheckBox();
            this.CmbPartener = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescriere = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbTipProprietate = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProprietate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LVMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiazaInClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbCodPartener = new System.Windows.Forms.RadioButton();
            this.rbCodBare = new System.Windows.Forms.RadioButton();
            this.rbCodArticol = new System.Windows.Forms.RadioButton();
            this.CmbTipMiscare = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.LVMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(3, 34);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(790, 252);
            this.MyListView.TabIndex = 19;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(692, 6);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 25);
            this.CmdCauta.TabIndex = 18;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(48, 6);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(206, 20);
            this.txtCauta.TabIndex = 14;
            this.txtCauta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCauta_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Cauta ";
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(692, 499);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 20;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSalvez
            // 
            this.CmdSalvez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSalvez.Location = new System.Drawing.Point(692, 468);
            this.CmdSalvez.Name = "CmdSalvez";
            this.CmdSalvez.Size = new System.Drawing.Size(91, 25);
            this.CmdSalvez.TabIndex = 13;
            this.CmdSalvez.Text = "&Salvez";
            this.CmdSalvez.UseVisualStyleBackColor = true;
            this.CmdSalvez.Click += new System.EventHandler(this.CmdSalvez_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CkAmbalaj);
            this.groupBox2.Controls.Add(this.LblARDescrieri);
            this.groupBox2.Controls.Add(this.LblDPartener);
            this.groupBox2.Controls.Add(this.CmbArticol);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.CkImpartire);
            this.groupBox2.Controls.Add(this.CkInmultire);
            this.groupBox2.Controls.Add(this.txtCoeficient);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CmbUOM);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCantitate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CkPartType);
            this.groupBox2.Controls.Add(this.CmbPartener);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDescriere);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBarCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 222);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cod / Simbol";
            // 
            // CkAmbalaj
            // 
            this.CkAmbalaj.AutoSize = true;
            this.CkAmbalaj.BackColor = System.Drawing.SystemColors.Control;
            this.CkAmbalaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkAmbalaj.Location = new System.Drawing.Point(283, 96);
            this.CkAmbalaj.Name = "CkAmbalaj";
            this.CkAmbalaj.Size = new System.Drawing.Size(67, 17);
            this.CkAmbalaj.TabIndex = 56;
            this.CkAmbalaj.Text = "Ambalare";
            this.CkAmbalaj.UseVisualStyleBackColor = false;
            // 
            // LblARDescrieri
            // 
            this.LblARDescrieri.AutoSize = true;
            this.LblARDescrieri.Location = new System.Drawing.Point(58, 43);
            this.LblARDescrieri.Name = "LblARDescrieri";
            this.LblARDescrieri.Size = new System.Drawing.Size(0, 13);
            this.LblARDescrieri.TabIndex = 55;
            // 
            // LblDPartener
            // 
            this.LblDPartener.AutoSize = true;
            this.LblDPartener.Location = new System.Drawing.Point(58, 96);
            this.LblDPartener.Name = "LblDPartener";
            this.LblDPartener.Size = new System.Drawing.Size(0, 13);
            this.LblDPartener.TabIndex = 54;
            // 
            // CmbArticol
            // 
            this.CmbArticol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArticol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbArticol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbArticol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbArticol.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbArticol.FormattingEnabled = true;
            this.CmbArticol.Location = new System.Drawing.Point(61, 19);
            this.CmbArticol.Name = "CmbArticol";
            this.CmbArticol.Size = new System.Drawing.Size(289, 21);
            this.CmbArticol.TabIndex = 0;
            this.CmbArticol.SelectedIndexChanged += new System.EventHandler(this.CmbArticol_SelectedIndexChanged);
            this.CmbArticol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbArticol_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Articol";
            // 
            // CkImpartire
            // 
            this.CkImpartire.AutoSize = true;
            this.CkImpartire.BackColor = System.Drawing.SystemColors.Control;
            this.CkImpartire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkImpartire.Location = new System.Drawing.Point(292, 165);
            this.CkImpartire.Name = "CkImpartire";
            this.CkImpartire.Size = new System.Drawing.Size(63, 17);
            this.CkImpartire.TabIndex = 8;
            this.CkImpartire.Text = "Impartire";
            this.CkImpartire.UseVisualStyleBackColor = false;
            this.CkImpartire.CheckedChanged += new System.EventHandler(this.CkImpartire_CheckedChanged);
            this.CkImpartire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CkImpartire_KeyDown);
            // 
            // CkInmultire
            // 
            this.CkInmultire.AutoSize = true;
            this.CkInmultire.BackColor = System.Drawing.SystemColors.Control;
            this.CkInmultire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkInmultire.Location = new System.Drawing.Point(224, 165);
            this.CkInmultire.Name = "CkInmultire";
            this.CkInmultire.Size = new System.Drawing.Size(62, 17);
            this.CkInmultire.TabIndex = 7;
            this.CkInmultire.Text = "Inmultire";
            this.CkInmultire.UseVisualStyleBackColor = false;
            this.CkInmultire.CheckedChanged += new System.EventHandler(this.CkInmultire_CheckedChanged);
            this.CkInmultire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CkInmultire_KeyDown);
            // 
            // txtCoeficient
            // 
            this.txtCoeficient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCoeficient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoeficient.Location = new System.Drawing.Point(283, 193);
            this.txtCoeficient.Name = "txtCoeficient";
            this.txtCoeficient.Size = new System.Drawing.Size(67, 20);
            this.txtCoeficient.TabIndex = 9;
            this.txtCoeficient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCoeficient_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Coeficient";
            // 
            // CmbUOM
            // 
            this.CmbUOM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbUOM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUOM.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbUOM.FormattingEnabled = true;
            this.CmbUOM.Location = new System.Drawing.Point(61, 164);
            this.CmbUOM.Name = "CmbUOM";
            this.CmbUOM.Size = new System.Drawing.Size(161, 21);
            this.CmbUOM.TabIndex = 6;
            this.CmbUOM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUOM_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Conversie";
            // 
            // txtCantitate
            // 
            this.txtCantitate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantitate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantitate.Location = new System.Drawing.Point(283, 114);
            this.txtCantitate.Name = "txtCantitate";
            this.txtCantitate.Size = new System.Drawing.Size(67, 20);
            this.txtCantitate.TabIndex = 4;
            this.txtCantitate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantitate_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Cantitate";
            // 
            // CkPartType
            // 
            this.CkPartType.AutoSize = true;
            this.CkPartType.BackColor = System.Drawing.SystemColors.Control;
            this.CkPartType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkPartType.Location = new System.Drawing.Point(283, 73);
            this.CkPartType.Name = "CkPartType";
            this.CkPartType.Size = new System.Drawing.Size(60, 17);
            this.CkPartType.TabIndex = 2;
            this.CkPartType.Text = "Furnizor";
            this.CkPartType.UseVisualStyleBackColor = false;
            this.CkPartType.CheckedChanged += new System.EventHandler(this.CkPartType_CheckedChanged);
            // 
            // CmbPartener
            // 
            this.CmbPartener.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPartener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbPartener.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbPartener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbPartener.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbPartener.FormattingEnabled = true;
            this.CmbPartener.Location = new System.Drawing.Point(61, 72);
            this.CmbPartener.Name = "CmbPartener";
            this.CmbPartener.Size = new System.Drawing.Size(161, 21);
            this.CmbPartener.TabIndex = 1;
            this.CmbPartener.SelectedIndexChanged += new System.EventHandler(this.CmbPartener_SelectedIndexChanged);
            this.CmbPartener.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPartener_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Partener";
            // 
            // txtDescriere
            // 
            this.txtDescriere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescriere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescriere.Location = new System.Drawing.Point(61, 138);
            this.txtDescriere.Name = "txtDescriere";
            this.txtDescriere.Size = new System.Drawing.Size(289, 20);
            this.txtDescriere.TabIndex = 5;
            this.txtDescriere.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescriere_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Descriere";
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.Location = new System.Drawing.Point(61, 115);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(161, 20);
            this.txtBarCode.TabIndex = 3;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cod";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbTipProprietate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtProprietate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(380, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 77);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caracteristici Fizice";
            // 
            // CmbTipProprietate
            // 
            this.CmbTipProprietate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTipProprietate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbTipProprietate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbTipProprietate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbTipProprietate.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbTipProprietate.FormattingEnabled = true;
            this.CmbTipProprietate.Location = new System.Drawing.Point(61, 19);
            this.CmbTipProprietate.Name = "CmbTipProprietate";
            this.CmbTipProprietate.Size = new System.Drawing.Size(133, 21);
            this.CmbTipProprietate.TabIndex = 10;
            this.CmbTipProprietate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTipProprietate_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Tip";
            // 
            // txtProprietate
            // 
            this.txtProprietate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtProprietate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProprietate.Location = new System.Drawing.Point(61, 48);
            this.txtProprietate.Name = "txtProprietate";
            this.txtProprietate.Size = new System.Drawing.Size(133, 20);
            this.txtProprietate.TabIndex = 11;
            this.txtProprietate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProprietate_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Proprietate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(377, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Tip Miscare";
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
            // rbCodPartener
            // 
            this.rbCodPartener.AutoSize = true;
            this.rbCodPartener.Location = new System.Drawing.Point(483, 7);
            this.rbCodPartener.Name = "rbCodPartener";
            this.rbCodPartener.Size = new System.Drawing.Size(87, 17);
            this.rbCodPartener.TabIndex = 17;
            this.rbCodPartener.TabStop = true;
            this.rbCodPartener.Text = "Cod Partener";
            this.rbCodPartener.UseVisualStyleBackColor = true;
            // 
            // rbCodBare
            // 
            this.rbCodBare.AutoSize = true;
            this.rbCodBare.Location = new System.Drawing.Point(369, 7);
            this.rbCodBare.Name = "rbCodBare";
            this.rbCodBare.Size = new System.Drawing.Size(97, 17);
            this.rbCodBare.TabIndex = 16;
            this.rbCodBare.TabStop = true;
            this.rbCodBare.Text = "Cod Echivalent";
            this.rbCodBare.UseVisualStyleBackColor = true;
            // 
            // rbCodArticol
            // 
            this.rbCodArticol.AutoSize = true;
            this.rbCodArticol.Location = new System.Drawing.Point(270, 7);
            this.rbCodArticol.Name = "rbCodArticol";
            this.rbCodArticol.Size = new System.Drawing.Size(76, 17);
            this.rbCodArticol.TabIndex = 15;
            this.rbCodArticol.TabStop = true;
            this.rbCodArticol.Text = "Cod Articol";
            this.rbCodArticol.UseVisualStyleBackColor = true;
            // 
            // CmbTipMiscare
            // 
            this.CmbTipMiscare.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTipMiscare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbTipMiscare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbTipMiscare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbTipMiscare.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbTipMiscare.FormattingEnabled = true;
            this.CmbTipMiscare.Location = new System.Drawing.Point(445, 401);
            this.CmbTipMiscare.Name = "CmbTipMiscare";
            this.CmbTipMiscare.Size = new System.Drawing.Size(129, 21);
            this.CmbTipMiscare.TabIndex = 12;
            this.CmbTipMiscare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTipMiscare_KeyDown);
            // 
            // frmPresentationFom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(829, 526);
            this.Controls.Add(this.rbCodPartener);
            this.Controls.Add(this.rbCodBare);
            this.Controls.Add(this.rbCodArticol);
            this.Controls.Add(this.CmbTipMiscare);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSalvez);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MyListView);
            this.MaximizeBox = false;
            this.Name = "frmPresentationFom";
            this.ShowIcon = false;
            this.Text = "Forme de Prezentare";
            this.Load += new System.EventHandler(this.frmPresentationFom_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPresentationFom_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.LVMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSalvez;
        private System.Windows.Forms.GroupBox groupBox2;
        private MultiColumnComboBox CmbPartener;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MultiColumnComboBox CmbTipProprietate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProprietate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CkImpartire;
        private System.Windows.Forms.CheckBox CkInmultire;
        private System.Windows.Forms.TextBox txtCoeficient;
        private System.Windows.Forms.Label label9;
        private MultiColumnComboBox CmbUOM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantitate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CkPartType;
        private MultiColumnComboBox CmbTipMiscare;
        private System.Windows.Forms.Label label10;
        private MultiColumnComboBox CmbArticol;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblARDescrieri;
        private System.Windows.Forms.Label LblDPartener;
        private System.Windows.Forms.ContextMenuStrip LVMenu;
        private System.Windows.Forms.ToolStripMenuItem copiazaInClipBoardToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbCodPartener;
        private System.Windows.Forms.RadioButton rbCodBare;
        private System.Windows.Forms.RadioButton rbCodArticol;
        private System.Windows.Forms.CheckBox CkAmbalaj;
    }
}