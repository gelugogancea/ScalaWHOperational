namespace GoWHMgmAdmin
{
    partial class frmAddConf3DLoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccLevel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNLocDown = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNLocUp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNLocRight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNLocLeft = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGreutate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInaltime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLatime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLungime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSalvez = new System.Windows.Forms.Button();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.LblZSDescriere = new System.Windows.Forms.Label();
            this.CmbWH = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbSTArea = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(1, 33);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(703, 236);
            this.MyListView.TabIndex = 16;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Zona Stocare";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccLevel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSymbol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 196);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Locator";
            // 
            // txtAccLevel
            // 
            this.txtAccLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAccLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccLevel.Location = new System.Drawing.Point(77, 39);
            this.txtAccLevel.Name = "txtAccLevel";
            this.txtAccLevel.Size = new System.Drawing.Size(67, 20);
            this.txtAccLevel.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Nivel Acces";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNLocDown);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNLocUp);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNLocRight);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtNLocLeft);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(207, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 123);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Orientare";
            // 
            // txtNLocDown
            // 
            this.txtNLocDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNLocDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNLocDown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNLocDown.Location = new System.Drawing.Point(120, 91);
            this.txtNLocDown.Name = "txtNLocDown";
            this.txtNLocDown.Size = new System.Drawing.Size(54, 20);
            this.txtNLocDown.TabIndex = 11;
            this.txtNLocDown.Leave += new System.EventHandler(this.txtNLocDown_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Locator Jos";
            // 
            // txtNLocUp
            // 
            this.txtNLocUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNLocUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNLocUp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNLocUp.Location = new System.Drawing.Point(120, 65);
            this.txtNLocUp.Name = "txtNLocUp";
            this.txtNLocUp.Size = new System.Drawing.Size(54, 20);
            this.txtNLocUp.TabIndex = 10;
            this.txtNLocUp.Leave += new System.EventHandler(this.txtNLocUp_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Locator Sus";
            // 
            // txtNLocRight
            // 
            this.txtNLocRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNLocRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNLocRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNLocRight.Location = new System.Drawing.Point(120, 39);
            this.txtNLocRight.Name = "txtNLocRight";
            this.txtNLocRight.Size = new System.Drawing.Size(54, 20);
            this.txtNLocRight.TabIndex = 9;
            this.txtNLocRight.Leave += new System.EventHandler(this.txtNLocRight_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Locator Dreapta";
            // 
            // txtNLocLeft
            // 
            this.txtNLocLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNLocLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNLocLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNLocLeft.Location = new System.Drawing.Point(120, 13);
            this.txtNLocLeft.Name = "txtNLocLeft";
            this.txtNLocLeft.Size = new System.Drawing.Size(54, 20);
            this.txtNLocLeft.TabIndex = 8;
            this.txtNLocLeft.Leave += new System.EventHandler(this.txtNLocLeft_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Locator Stanga";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtGreutate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtInaltime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtLatime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLungime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 123);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proprietati ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(175, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Kg";
            // 
            // txtGreutate
            // 
            this.txtGreutate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGreutate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGreutate.Location = new System.Drawing.Point(120, 91);
            this.txtGreutate.Name = "txtGreutate";
            this.txtGreutate.Size = new System.Drawing.Size(54, 20);
            this.txtGreutate.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Greutate MAX. Admisa";
            // 
            // txtInaltime
            // 
            this.txtInaltime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInaltime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInaltime.Location = new System.Drawing.Point(120, 65);
            this.txtInaltime.Name = "txtInaltime";
            this.txtInaltime.Size = new System.Drawing.Size(54, 20);
            this.txtInaltime.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Inaltime (m)";
            // 
            // txtLatime
            // 
            this.txtLatime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLatime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLatime.Location = new System.Drawing.Point(120, 39);
            this.txtLatime.Name = "txtLatime";
            this.txtLatime.Size = new System.Drawing.Size(54, 20);
            this.txtLatime.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Latime (m)";
            // 
            // txtLungime
            // 
            this.txtLungime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLungime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLungime.Location = new System.Drawing.Point(120, 13);
            this.txtLungime.Name = "txtLungime";
            this.txtLungime.Size = new System.Drawing.Size(54, 20);
            this.txtLungime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lungime (m)";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(200, 13);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(187, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Descriere";
            // 
            // txtSymbol
            // 
            this.txtSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(77, 13);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(67, 20);
            this.txtSymbol.TabIndex = 1;
            this.txtSymbol.Leave += new System.EventHandler(this.txtSymbol_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Simbol";
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(423, 6);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(163, 20);
            this.txtCauta.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(343, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Cauta Locator";
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(605, 484);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 13;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSalvez
            // 
            this.CmdSalvez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSalvez.Location = new System.Drawing.Point(605, 453);
            this.CmdSalvez.Name = "CmdSalvez";
            this.CmdSalvez.Size = new System.Drawing.Size(91, 25);
            this.CmdSalvez.TabIndex = 12;
            this.CmdSalvez.Text = "&Salvez";
            this.CmdSalvez.UseVisualStyleBackColor = true;
            this.CmdSalvez.Click += new System.EventHandler(this.CmdSalvez_Click);
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(605, 3);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 25);
            this.CmdCauta.TabIndex = 15;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Gestiune";
            // 
            // LblZSDescriere
            // 
            this.LblZSDescriere.AutoSize = true;
            this.LblZSDescriere.Location = new System.Drawing.Point(75, 299);
            this.LblZSDescriere.Name = "LblZSDescriere";
            this.LblZSDescriere.Size = new System.Drawing.Size(0, 13);
            this.LblZSDescriere.TabIndex = 34;
            // 
            // CmbWH
            // 
            this.CmbWH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbWH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbWH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbWH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbWH.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbWH.FormattingEnabled = true;
            this.CmbWH.Location = new System.Drawing.Point(64, 6);
            this.CmbWH.Name = "CmbWH";
            this.CmbWH.Size = new System.Drawing.Size(234, 21);
            this.CmbWH.TabIndex = 33;
            this.CmbWH.SelectedIndexChanged += new System.EventHandler(this.CmbWH_SelectedIndexChanged);
            this.CmbWH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbWH_KeyPress);
            this.CmbWH.Click += new System.EventHandler(this.CmbWH_Click);
            // 
            // CmbSTArea
            // 
            this.CmbSTArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSTArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbSTArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbSTArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSTArea.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbSTArea.FormattingEnabled = true;
            this.CmbSTArea.Location = new System.Drawing.Point(78, 275);
            this.CmbSTArea.Name = "CmbSTArea";
            this.CmbSTArea.Size = new System.Drawing.Size(125, 21);
            this.CmbSTArea.TabIndex = 0;
            this.CmbSTArea.SelectedIndexChanged += new System.EventHandler(this.CmbSTArea_SelectedIndexChanged);
            this.CmbSTArea.Click += new System.EventHandler(this.CmbSTArea_Click);
            // 
            // frmAddConf3DLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 526);
            this.Controls.Add(this.LblZSDescriere);
            this.Controls.Add(this.CmbWH);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CmbSTArea);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSalvez);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyListView);
            this.MaximizeBox = false;
            this.Name = "frmAddConf3DLoc";
            this.ShowIcon = false;
            this.Text = "Adaugare/Configurare Locatoare 3D";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddConf3DLoc_FormClosed);
            this.Load += new System.EventHandler(this.frmAddConf3DLoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccLevel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNLocDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNLocUp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNLocRight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNLocLeft;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGreutate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInaltime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLatime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLungime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSalvez;
        private System.Windows.Forms.Button CmdCauta;
        private MultiColumnComboBox CmbSTArea;
        private MultiColumnComboBox CmbWH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LblZSDescriere;
    }
}