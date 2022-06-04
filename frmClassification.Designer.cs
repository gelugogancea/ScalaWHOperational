namespace GoWHMgmAdmin
{
    partial class frmClassification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassification));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClassDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblValidClass = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCategoryDesc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblValidCategory = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblValidGroup = new System.Windows.Forms.Label();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblValidType = new System.Windows.Forms.Label();
            this.txtTypeDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.rbExtendGroup = new System.Windows.Forms.RadioButton();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbDenumireArticol = new System.Windows.Forms.RadioButton();
            this.rbCodArticol = new System.Windows.Forms.RadioButton();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.LblTotalInList = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.LblClass = new System.Windows.Forms.Label();
            this.txtCharNr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbClasificare = new System.Windows.Forms.RadioButton();
            this.LVMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiazaInClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbType = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbGroup = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbCategory = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbClass = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.LVMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtClassDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LblValidClass);
            this.groupBox1.Controls.Add(this.CmbClass);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 89);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clasa";
            // 
            // txtClassDesc
            // 
            this.txtClassDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtClassDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassDesc.Location = new System.Drawing.Point(7, 60);
            this.txtClassDesc.Name = "txtClassDesc";
            this.txtClassDesc.Size = new System.Drawing.Size(403, 20);
            this.txtClassDesc.TabIndex = 2;
            this.txtClassDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassDesc_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Descriere";
            // 
            // LblValidClass
            // 
            this.LblValidClass.AutoSize = true;
            this.LblValidClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValidClass.Image = ((System.Drawing.Image)(resources.GetObject("LblValidClass.Image")));
            this.LblValidClass.Location = new System.Drawing.Point(382, 22);
            this.LblValidClass.Name = "LblValidClass";
            this.LblValidClass.Size = new System.Drawing.Size(28, 18);
            this.LblValidClass.TabIndex = 58;
            this.LblValidClass.Text = "     ";
            this.LblValidClass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblValidClass_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Descriere";
            // 
            // txtCategoryDesc
            // 
            this.txtCategoryDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCategoryDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryDesc.Location = new System.Drawing.Point(7, 60);
            this.txtCategoryDesc.Name = "txtCategoryDesc";
            this.txtCategoryDesc.Size = new System.Drawing.Size(403, 20);
            this.txtCategoryDesc.TabIndex = 4;
            this.txtCategoryDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryDesc_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblValidCategory);
            this.groupBox2.Controls.Add(this.CmbCategory);
            this.groupBox2.Controls.Add(this.txtCategoryDesc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(9, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 89);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categorie";
            // 
            // LblValidCategory
            // 
            this.LblValidCategory.AutoSize = true;
            this.LblValidCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValidCategory.Image = ((System.Drawing.Image)(resources.GetObject("LblValidCategory.Image")));
            this.LblValidCategory.Location = new System.Drawing.Point(382, 22);
            this.LblValidCategory.Name = "LblValidCategory";
            this.LblValidCategory.Size = new System.Drawing.Size(28, 18);
            this.LblValidCategory.TabIndex = 62;
            this.LblValidCategory.Text = "     ";
            this.LblValidCategory.Click += new System.EventHandler(this.LblValidCategory_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblValidGroup);
            this.groupBox3.Controls.Add(this.CmbGroup);
            this.groupBox3.Controls.Add(this.txtGroupDesc);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 89);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grupa";
            // 
            // LblValidGroup
            // 
            this.LblValidGroup.AutoSize = true;
            this.LblValidGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValidGroup.Image = ((System.Drawing.Image)(resources.GetObject("LblValidGroup.Image")));
            this.LblValidGroup.Location = new System.Drawing.Point(382, 22);
            this.LblValidGroup.Name = "LblValidGroup";
            this.LblValidGroup.Size = new System.Drawing.Size(28, 18);
            this.LblValidGroup.TabIndex = 65;
            this.LblValidGroup.Text = "     ";
            this.LblValidGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblValidGroup_MouseClick);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGroupDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupDesc.Location = new System.Drawing.Point(7, 60);
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(403, 20);
            this.txtGroupDesc.TabIndex = 6;
            this.txtGroupDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupDesc_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Descriere";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LblValidType);
            this.groupBox4.Controls.Add(this.CmbType);
            this.groupBox4.Controls.Add(this.txtTypeDesc);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(9, 297);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 89);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tip";
            // 
            // LblValidType
            // 
            this.LblValidType.AutoSize = true;
            this.LblValidType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValidType.Image = ((System.Drawing.Image)(resources.GetObject("LblValidType.Image")));
            this.LblValidType.Location = new System.Drawing.Point(382, 23);
            this.LblValidType.Name = "LblValidType";
            this.LblValidType.Size = new System.Drawing.Size(28, 18);
            this.LblValidType.TabIndex = 68;
            this.LblValidType.Text = "     ";
            this.LblValidType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblValidType_MouseClick);
            // 
            // txtTypeDesc
            // 
            this.txtTypeDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTypeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTypeDesc.Location = new System.Drawing.Point(7, 60);
            this.txtTypeDesc.Name = "txtTypeDesc";
            this.txtTypeDesc.Size = new System.Drawing.Size(403, 20);
            this.txtTypeDesc.TabIndex = 8;
            this.txtTypeDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTypeDesc_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Descriere";
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(730, 428);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 17;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // rbExtendGroup
            // 
            this.rbExtendGroup.AutoSize = true;
            this.rbExtendGroup.Location = new System.Drawing.Point(635, 47);
            this.rbExtendGroup.Name = "rbExtendGroup";
            this.rbExtendGroup.Size = new System.Drawing.Size(91, 17);
            this.rbExtendGroup.TabIndex = 13;
            this.rbExtendGroup.TabStop = true;
            this.rbExtendGroup.Text = "Grupa Extinsa";
            this.rbExtendGroup.UseVisualStyleBackColor = true;
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Location = new System.Drawing.Point(575, 47);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 12;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Grupa";
            this.rbGroup.UseVisualStyleBackColor = true;
            // 
            // rbDenumireArticol
            // 
            this.rbDenumireArticol.AutoSize = true;
            this.rbDenumireArticol.Location = new System.Drawing.Point(508, 47);
            this.rbDenumireArticol.Name = "rbDenumireArticol";
            this.rbDenumireArticol.Size = new System.Drawing.Size(70, 17);
            this.rbDenumireArticol.TabIndex = 11;
            this.rbDenumireArticol.TabStop = true;
            this.rbDenumireArticol.Text = "Descriere";
            this.rbDenumireArticol.UseVisualStyleBackColor = true;
            // 
            // rbCodArticol
            // 
            this.rbCodArticol.AutoSize = true;
            this.rbCodArticol.Location = new System.Drawing.Point(431, 47);
            this.rbCodArticol.Name = "rbCodArticol";
            this.rbCodArticol.Size = new System.Drawing.Size(76, 17);
            this.rbCodArticol.TabIndex = 10;
            this.rbCodArticol.TabStop = true;
            this.rbCodArticol.Text = "Cod Articol";
            this.rbCodArticol.UseVisualStyleBackColor = true;
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(730, 12);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 24);
            this.CmdCauta.TabIndex = 14;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(475, 16);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(206, 20);
            this.txtCauta.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(431, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 78;
            this.label14.Text = "Criteriu";
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(431, 71);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(390, 315);
            this.MyListView.TabIndex = 15;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseClick);
            this.MyListView.SelectedIndexChanged += new System.EventHandler(this.MyListView_SelectedIndexChanged);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // LblTotalInList
            // 
            this.LblTotalInList.AutoSize = true;
            this.LblTotalInList.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalInList.Location = new System.Drawing.Point(543, 434);
            this.LblTotalInList.Name = "LblTotalInList";
            this.LblTotalInList.Size = new System.Drawing.Size(13, 13);
            this.LblTotalInList.TabIndex = 80;
            this.LblTotalInList.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Total In List";
            // 
            // CmdSave
            // 
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Location = new System.Drawing.Point(730, 392);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(91, 25);
            this.CmdSave.TabIndex = 16;
            this.CmdSave.Text = "&Salvez";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // LblClass
            // 
            this.LblClass.AutoSize = true;
            this.LblClass.BackColor = System.Drawing.SystemColors.Control;
            this.LblClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClass.ForeColor = System.Drawing.Color.Blue;
            this.LblClass.Location = new System.Drawing.Point(12, 397);
            this.LblClass.Name = "LblClass";
            this.LblClass.Size = new System.Drawing.Size(2, 20);
            this.LblClass.TabIndex = 82;
            this.LblClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCharNr
            // 
            this.txtCharNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCharNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharNr.Location = new System.Drawing.Point(614, 397);
            this.txtCharNr.Name = "txtCharNr";
            this.txtCharNr.Size = new System.Drawing.Size(60, 20);
            this.txtCharNr.TabIndex = 83;
            this.txtCharNr.Text = "5";
            this.txtCharNr.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Nr Crt. indentare";
            this.label5.Visible = false;
            // 
            // rbClasificare
            // 
            this.rbClasificare.AutoSize = true;
            this.rbClasificare.Location = new System.Drawing.Point(730, 48);
            this.rbClasificare.Name = "rbClasificare";
            this.rbClasificare.Size = new System.Drawing.Size(73, 17);
            this.rbClasificare.TabIndex = 85;
            this.rbClasificare.TabStop = true;
            this.rbClasificare.Text = "Clasificare";
            this.rbClasificare.UseVisualStyleBackColor = true;
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
            // CmbType
            // 
            this.CmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbType.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(9, 20);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(367, 21);
            this.CmbType.TabIndex = 7;
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            this.CmbType.Leave += new System.EventHandler(this.CmbType_Leave);
            this.CmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbType_KeyDown);
            this.CmbType.DropDown += new System.EventHandler(this.CmbType_DropDown);
            // 
            // CmbGroup
            // 
            this.CmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbGroup.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbGroup.FormattingEnabled = true;
            this.CmbGroup.Location = new System.Drawing.Point(9, 19);
            this.CmbGroup.Name = "CmbGroup";
            this.CmbGroup.Size = new System.Drawing.Size(367, 21);
            this.CmbGroup.TabIndex = 5;
            this.CmbGroup.SelectedIndexChanged += new System.EventHandler(this.CmbGroup_SelectedIndexChanged);
            this.CmbGroup.Leave += new System.EventHandler(this.CmbGroup_Leave);
            this.CmbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbGroup_KeyDown);
            this.CmbGroup.DropDown += new System.EventHandler(this.CmbGroup_DropDown);
            // 
            // CmbCategory
            // 
            this.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbCategory.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbCategory.FormattingEnabled = true;
            this.CmbCategory.Location = new System.Drawing.Point(9, 19);
            this.CmbCategory.Name = "CmbCategory";
            this.CmbCategory.Size = new System.Drawing.Size(367, 21);
            this.CmbCategory.TabIndex = 3;
            this.CmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            this.CmbCategory.Leave += new System.EventHandler(this.CmbCategory_Leave);
            this.CmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbCategory_KeyDown);
            this.CmbCategory.DropDown += new System.EventHandler(this.CmbCategory_DropDown);
            // 
            // CmbClass
            // 
            this.CmbClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbClass.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbClass.FormattingEnabled = true;
            this.CmbClass.Location = new System.Drawing.Point(9, 19);
            this.CmbClass.Name = "CmbClass";
            this.CmbClass.Size = new System.Drawing.Size(367, 21);
            this.CmbClass.TabIndex = 1;
            this.CmbClass.SelectedIndexChanged += new System.EventHandler(this.CmbClass_SelectedIndexChanged);
            this.CmbClass.Leave += new System.EventHandler(this.CmbClass_Leave);
            this.CmbClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbClass_KeyDown);
            this.CmbClass.DropDown += new System.EventHandler(this.CmbClass_DropDown);
            // 
            // frmClassification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 461);
            this.Controls.Add(this.rbClasificare);
            this.Controls.Add(this.txtCharNr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblClass);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.LblTotalInList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbExtendGroup);
            this.Controls.Add(this.rbGroup);
            this.Controls.Add(this.rbDenumireArticol);
            this.Controls.Add(this.rbCodArticol);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClassification";
            this.Text = "Clasificare Articole";
            this.Load += new System.EventHandler(this.frmClassification_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClassification_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.LVMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblValidClass;
        private MultiColumnComboBox CmbClass;
        private System.Windows.Forms.TextBox txtClassDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCategoryDesc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblValidCategory;
        private MultiColumnComboBox CmbCategory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblValidGroup;
        private MultiColumnComboBox CmbGroup;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblValidType;
        private MultiColumnComboBox CmbType;
        private System.Windows.Forms.TextBox txtTypeDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.RadioButton rbExtendGroup;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.RadioButton rbDenumireArticol;
        private System.Windows.Forms.RadioButton rbCodArticol;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Label LblTotalInList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Label LblClass;
        private System.Windows.Forms.TextBox txtCharNr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbClasificare;
        private System.Windows.Forms.ContextMenuStrip LVMenu;
        private System.Windows.Forms.ToolStripMenuItem copiazaInClipBoardToolStripMenuItem;
    }
}