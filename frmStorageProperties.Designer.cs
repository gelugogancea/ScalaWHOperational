namespace GoWHMgmAdmin
{
    partial class frmStorageProperties
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
            this.MyListStore = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblSelectLocator = new System.Windows.Forms.Label();
            this.CmbSTArea = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbWH = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MyListLocator = new System.Windows.Forms.ListView();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSalvez = new System.Windows.Forms.Button();
            this.CkLock = new System.Windows.Forms.CheckBox();
            this.txtStack = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtByRow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbClasificare = new System.Windows.Forms.RadioButton();
            this.LblTotalInList = new System.Windows.Forms.Label();
            this.rbExtendGroup = new System.Windows.Forms.RadioButton();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbDenumireArticol = new System.Windows.Forms.RadioButton();
            this.rbArticol = new System.Windows.Forms.RadioButton();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CkShowMeProduct = new System.Windows.Forms.CheckBox();
            this.rbDynamic = new System.Windows.Forms.RadioButton();
            this.rbStatic = new System.Windows.Forms.RadioButton();
            this.LVMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiazaInClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aratamiArticoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtQtyMAX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtyMIN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.LVMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyListStore
            // 
            this.MyListStore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListStore.Location = new System.Drawing.Point(12, 64);
            this.MyListStore.Name = "MyListStore";
            this.MyListStore.Size = new System.Drawing.Size(418, 227);
            this.MyListStore.TabIndex = 18;
            this.MyListStore.UseCompatibleStateImageBehavior = false;
            this.MyListStore.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListStore_MouseDoubleClick);
            this.MyListStore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyListStore_MouseClick);
            this.MyListStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListStore_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblSelectLocator);
            this.groupBox1.Controls.Add(this.CmbSTArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbWH);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.MyListLocator);
            this.groupBox1.Location = new System.Drawing.Point(12, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 106);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Locatoare";
            // 
            // LblSelectLocator
            // 
            this.LblSelectLocator.AutoSize = true;
            this.LblSelectLocator.BackColor = System.Drawing.SystemColors.Control;
            this.LblSelectLocator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblSelectLocator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSelectLocator.ForeColor = System.Drawing.Color.Blue;
            this.LblSelectLocator.Location = new System.Drawing.Point(13, 73);
            this.LblSelectLocator.Name = "LblSelectLocator";
            this.LblSelectLocator.Size = new System.Drawing.Size(2, 20);
            this.LblSelectLocator.TabIndex = 43;
            this.LblSelectLocator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbSTArea
            // 
            this.CmbSTArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSTArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbSTArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbSTArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSTArea.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbSTArea.FormattingEnabled = true;
            this.CmbSTArea.Location = new System.Drawing.Point(82, 42);
            this.CmbSTArea.Name = "CmbSTArea";
            this.CmbSTArea.Size = new System.Drawing.Size(125, 21);
            this.CmbSTArea.TabIndex = 4;
            this.CmbSTArea.SelectedIndexChanged += new System.EventHandler(this.CmbSTArea_SelectedIndexChanged);
            this.CmbSTArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSTArea_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Zona Stocare";
            // 
            // CmbWH
            // 
            this.CmbWH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbWH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbWH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbWH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbWH.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbWH.FormattingEnabled = true;
            this.CmbWH.Location = new System.Drawing.Point(82, 15);
            this.CmbWH.Name = "CmbWH";
            this.CmbWH.Size = new System.Drawing.Size(125, 21);
            this.CmbWH.TabIndex = 3;
            this.CmbWH.SelectedIndexChanged += new System.EventHandler(this.CmbWH_SelectedIndexChanged);
            this.CmbWH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbWH_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Gestiune";
            // 
            // MyListLocator
            // 
            this.MyListLocator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListLocator.Location = new System.Drawing.Point(213, 15);
            this.MyListLocator.Name = "MyListLocator";
            this.MyListLocator.Size = new System.Drawing.Size(195, 85);
            this.MyListLocator.TabIndex = 5;
            this.MyListLocator.UseCompatibleStateImageBehavior = false;
            this.MyListLocator.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListLocator_MouseDoubleClick);
            this.MyListLocator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListLocator_KeyDown);
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(711, 468);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 17;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSalvez
            // 
            this.CmdSalvez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSalvez.Location = new System.Drawing.Point(711, 437);
            this.CmdSalvez.Name = "CmdSalvez";
            this.CmdSalvez.Size = new System.Drawing.Size(91, 25);
            this.CmdSalvez.TabIndex = 9;
            this.CmdSalvez.Text = "&Salvez";
            this.CmdSalvez.UseVisualStyleBackColor = true;
            this.CmdSalvez.Click += new System.EventHandler(this.CmdSalvez_Click);
            // 
            // CkLock
            // 
            this.CkLock.AutoSize = true;
            this.CkLock.BackColor = System.Drawing.SystemColors.Control;
            this.CkLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkLock.Location = new System.Drawing.Point(373, 419);
            this.CkLock.Name = "CkLock";
            this.CkLock.Size = new System.Drawing.Size(53, 17);
            this.CkLock.TabIndex = 8;
            this.CkLock.Text = "Blocat";
            this.CkLock.UseVisualStyleBackColor = false;
            this.CkLock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CkLock_KeyDown);
            // 
            // txtStack
            // 
            this.txtStack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStack.Location = new System.Drawing.Point(94, 419);
            this.txtStack.Name = "txtStack";
            this.txtStack.Size = new System.Drawing.Size(75, 20);
            this.txtStack.TabIndex = 6;
            this.txtStack.Text = "0";
            this.txtStack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStack_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "In Stiva";
            // 
            // txtByRow
            // 
            this.txtByRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtByRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtByRow.Location = new System.Drawing.Point(94, 445);
            this.txtByRow.Name = "txtByRow";
            this.txtByRow.Size = new System.Drawing.Size(75, 20);
            this.txtByRow.TabIndex = 7;
            this.txtByRow.Text = "0";
            this.txtByRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtByRow_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Pe Rand";
            // 
            // rbClasificare
            // 
            this.rbClasificare.AutoSize = true;
            this.rbClasificare.Location = new System.Drawing.Point(732, 41);
            this.rbClasificare.Name = "rbClasificare";
            this.rbClasificare.Size = new System.Drawing.Size(73, 17);
            this.rbClasificare.TabIndex = 16;
            this.rbClasificare.TabStop = true;
            this.rbClasificare.Text = "Clasificare";
            this.rbClasificare.UseVisualStyleBackColor = true;
            // 
            // LblTotalInList
            // 
            this.LblTotalInList.AutoSize = true;
            this.LblTotalInList.ForeColor = System.Drawing.Color.Blue;
            this.LblTotalInList.Location = new System.Drawing.Point(507, 416);
            this.LblTotalInList.Name = "LblTotalInList";
            this.LblTotalInList.Size = new System.Drawing.Size(13, 13);
            this.LblTotalInList.TabIndex = 96;
            this.LblTotalInList.Text = "0";
            // 
            // rbExtendGroup
            // 
            this.rbExtendGroup.AutoSize = true;
            this.rbExtendGroup.Location = new System.Drawing.Point(637, 40);
            this.rbExtendGroup.Name = "rbExtendGroup";
            this.rbExtendGroup.Size = new System.Drawing.Size(91, 17);
            this.rbExtendGroup.TabIndex = 15;
            this.rbExtendGroup.TabStop = true;
            this.rbExtendGroup.Text = "Grupa Extinsa";
            this.rbExtendGroup.UseVisualStyleBackColor = true;
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Location = new System.Drawing.Point(577, 40);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 14;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Grupa";
            this.rbGroup.UseVisualStyleBackColor = true;
            this.rbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbGroup_KeyDown);
            // 
            // rbDenumireArticol
            // 
            this.rbDenumireArticol.AutoSize = true;
            this.rbDenumireArticol.Location = new System.Drawing.Point(510, 40);
            this.rbDenumireArticol.Name = "rbDenumireArticol";
            this.rbDenumireArticol.Size = new System.Drawing.Size(70, 17);
            this.rbDenumireArticol.TabIndex = 13;
            this.rbDenumireArticol.TabStop = true;
            this.rbDenumireArticol.Text = "Descriere";
            this.rbDenumireArticol.UseVisualStyleBackColor = true;
            this.rbDenumireArticol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbDenumireArticol_KeyDown);
            // 
            // rbArticol
            // 
            this.rbArticol.AutoSize = true;
            this.rbArticol.Location = new System.Drawing.Point(433, 40);
            this.rbArticol.Name = "rbArticol";
            this.rbArticol.Size = new System.Drawing.Size(76, 17);
            this.rbArticol.TabIndex = 12;
            this.rbArticol.TabStop = true;
            this.rbArticol.Text = "Cod Articol";
            this.rbArticol.UseVisualStyleBackColor = true;
            this.rbArticol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbArticol_KeyDown);
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(732, 5);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 24);
            this.CmdCauta.TabIndex = 11;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(477, 9);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(206, 20);
            this.txtCauta.TabIndex = 10;
            this.txtCauta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCauta_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 95;
            this.label14.Text = "Criteriu";
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(433, 64);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(390, 339);
            this.MyListView.TabIndex = 92;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CkShowMeProduct);
            this.groupBox2.Controls.Add(this.rbDynamic);
            this.groupBox2.Controls.Add(this.rbStatic);
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 52);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alocare";
            // 
            // CkShowMeProduct
            // 
            this.CkShowMeProduct.AutoSize = true;
            this.CkShowMeProduct.BackColor = System.Drawing.SystemColors.Control;
            this.CkShowMeProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkShowMeProduct.Location = new System.Drawing.Point(146, 18);
            this.CkShowMeProduct.Name = "CkShowMeProduct";
            this.CkShowMeProduct.Size = new System.Drawing.Size(118, 17);
            this.CkShowMeProduct.TabIndex = 2;
            this.CkShowMeProduct.Text = "Arata ce este alocat";
            this.CkShowMeProduct.UseVisualStyleBackColor = false;
            this.CkShowMeProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CkShowMeProduct_KeyDown);
            // 
            // rbDynamic
            // 
            this.rbDynamic.AutoSize = true;
            this.rbDynamic.Location = new System.Drawing.Point(77, 18);
            this.rbDynamic.Name = "rbDynamic";
            this.rbDynamic.Size = new System.Drawing.Size(63, 17);
            this.rbDynamic.TabIndex = 1;
            this.rbDynamic.TabStop = true;
            this.rbDynamic.Text = "Dinamic";
            this.rbDynamic.UseVisualStyleBackColor = true;
            this.rbDynamic.CheckedChanged += new System.EventHandler(this.rbDynamic_CheckedChanged_1);
            this.rbDynamic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbDynamic_KeyDown);
            // 
            // rbStatic
            // 
            this.rbStatic.AutoSize = true;
            this.rbStatic.Location = new System.Drawing.Point(6, 19);
            this.rbStatic.Name = "rbStatic";
            this.rbStatic.Size = new System.Drawing.Size(52, 17);
            this.rbStatic.TabIndex = 0;
            this.rbStatic.TabStop = true;
            this.rbStatic.Text = "Static";
            this.rbStatic.UseVisualStyleBackColor = true;
            this.rbStatic.CheckedChanged += new System.EventHandler(this.rbStatic_CheckedChanged_1);
            this.rbStatic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbStatic_KeyDown);
            // 
            // LVMenu
            // 
            this.LVMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LVMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiazaInClipBoardToolStripMenuItem,
            this.aratamiArticoleToolStripMenuItem});
            this.LVMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.LVMenu.Name = "LVMenu";
            this.LVMenu.Size = new System.Drawing.Size(183, 48);
            // 
            // copiazaInClipBoardToolStripMenuItem
            // 
            this.copiazaInClipBoardToolStripMenuItem.Name = "copiazaInClipBoardToolStripMenuItem";
            this.copiazaInClipBoardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copiazaInClipBoardToolStripMenuItem.Text = "Copiaza in ClipBoard";
            this.copiazaInClipBoardToolStripMenuItem.Click += new System.EventHandler(this.copiazaInClipBoardToolStripMenuItem_Click);
            // 
            // aratamiArticoleToolStripMenuItem
            // 
            this.aratamiArticoleToolStripMenuItem.Name = "aratamiArticoleToolStripMenuItem";
            this.aratamiArticoleToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aratamiArticoleToolStripMenuItem.Text = "Arata-mi Articole ";
            this.aratamiArticoleToolStripMenuItem.Click += new System.EventHandler(this.aratamiArticoleToolStripMenuItem_Click);
            // 
            // txtQtyMAX
            // 
            this.txtQtyMAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQtyMAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyMAX.Location = new System.Drawing.Point(260, 445);
            this.txtQtyMAX.Name = "txtQtyMAX";
            this.txtQtyMAX.Size = new System.Drawing.Size(75, 20);
            this.txtQtyMAX.TabIndex = 102;
            this.txtQtyMAX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Canitate MAX.";
            // 
            // txtQtyMIN
            // 
            this.txtQtyMIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQtyMIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyMIN.Location = new System.Drawing.Point(260, 419);
            this.txtQtyMIN.Name = "txtQtyMIN";
            this.txtQtyMIN.Size = new System.Drawing.Size(75, 20);
            this.txtQtyMIN.TabIndex = 101;
            this.txtQtyMIN.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "Canitate MIN.";
            // 
            // frmStorageProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 503);
            this.Controls.Add(this.txtQtyMAX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQtyMIN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbClasificare);
            this.Controls.Add(this.LblTotalInList);
            this.Controls.Add(this.rbExtendGroup);
            this.Controls.Add(this.rbGroup);
            this.Controls.Add(this.rbDenumireArticol);
            this.Controls.Add(this.rbArticol);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.txtByRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CkLock);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSalvez);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MyListStore);
            this.MaximizeBox = false;
            this.Name = "frmStorageProperties";
            this.ShowIcon = false;
            this.Text = "Setarea Proprietatilor de Stocare";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStorageProperties_FormClosed);
            this.Activated += new System.EventHandler(this.frmStorageProperties_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStorageProperties_KeyDown);
            this.Load += new System.EventHandler(this.frmStorageProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.LVMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MyListStore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblSelectLocator;
        private MultiColumnComboBox CmbSTArea;
        private System.Windows.Forms.Label label1;
        private MultiColumnComboBox CmbWH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView MyListLocator;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSalvez;
        private System.Windows.Forms.CheckBox CkLock;
        private System.Windows.Forms.TextBox txtStack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtByRow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbClasificare;
        private System.Windows.Forms.Label LblTotalInList;
        private System.Windows.Forms.RadioButton rbExtendGroup;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.RadioButton rbDenumireArticol;
        private System.Windows.Forms.RadioButton rbArticol;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDynamic;
        private System.Windows.Forms.RadioButton rbStatic;
        private System.Windows.Forms.CheckBox CkShowMeProduct;
        private System.Windows.Forms.ContextMenuStrip LVMenu;
        private System.Windows.Forms.ToolStripMenuItem copiazaInClipBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aratamiArticoleToolStripMenuItem;
        private System.Windows.Forms.TextBox txtQtyMAX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtyMIN;
        private System.Windows.Forms.Label label5;
    }
}