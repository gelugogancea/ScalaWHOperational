namespace GoWHMgmAdmin
{
    partial class frmAddConfAreaStorage
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
            this.label1 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGreutate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInaltime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLatime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLungime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CkPickingAllow = new System.Windows.Forms.CheckBox();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSalvez = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LblWHDescriere = new System.Windows.Forms.Label();
            this.txtQtyMAX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQtyMIN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbWH = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestiune";
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(3, 2);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(675, 269);
            this.MyListView.TabIndex = 9;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cod Zona";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaCode.Location = new System.Drawing.Point(433, 338);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(107, 20);
            this.txtAreaCode.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(433, 364);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(234, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Descriere";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQtyMAX);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtQtyMIN);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtGreutate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtInaltime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLatime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLungime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(178, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 172);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proprietati ";
            // 
            // txtGreutate
            // 
            this.txtGreutate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGreutate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGreutate.Location = new System.Drawing.Point(120, 91);
            this.txtGreutate.Name = "txtGreutate";
            this.txtGreutate.Size = new System.Drawing.Size(54, 20);
            this.txtGreutate.TabIndex = 3;
            this.txtGreutate.Text = "0";
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
            this.txtInaltime.TabIndex = 2;
            this.txtInaltime.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Inaltime";
            // 
            // txtLatime
            // 
            this.txtLatime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLatime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLatime.Location = new System.Drawing.Point(120, 39);
            this.txtLatime.Name = "txtLatime";
            this.txtLatime.Size = new System.Drawing.Size(54, 20);
            this.txtLatime.TabIndex = 1;
            this.txtLatime.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Latime";
            // 
            // txtLungime
            // 
            this.txtLungime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLungime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLungime.Location = new System.Drawing.Point(120, 13);
            this.txtLungime.Name = "txtLungime";
            this.txtLungime.Size = new System.Drawing.Size(54, 20);
            this.txtLungime.TabIndex = 0;
            this.txtLungime.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lungime";
            // 
            // CkPickingAllow
            // 
            this.CkPickingAllow.AutoSize = true;
            this.CkPickingAllow.BackColor = System.Drawing.SystemColors.Control;
            this.CkPickingAllow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkPickingAllow.Location = new System.Drawing.Point(569, 338);
            this.CkPickingAllow.Name = "CkPickingAllow";
            this.CkPickingAllow.Size = new System.Drawing.Size(91, 17);
            this.CkPickingAllow.TabIndex = 6;
            this.CkPickingAllow.Text = "Permis picking";
            this.CkPickingAllow.UseVisualStyleBackColor = false;
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(576, 428);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 11;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSalvez
            // 
            this.CmdSalvez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSalvez.Location = new System.Drawing.Point(576, 397);
            this.CmdSalvez.Name = "CmdSalvez";
            this.CmdSalvez.Size = new System.Drawing.Size(91, 25);
            this.CmdSalvez.TabIndex = 8;
            this.CmdSalvez.Text = "&Salvez";
            this.CmdSalvez.UseVisualStyleBackColor = true;
            this.CmdSalvez.Click += new System.EventHandler(this.CmdSalvez_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 25);
            this.button1.TabIndex = 26;
            this.button1.Text = "E&xit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblWHDescriere
            // 
            this.LblWHDescriere.AutoSize = true;
            this.LblWHDescriere.Location = new System.Drawing.Point(430, 313);
            this.LblWHDescriere.Name = "LblWHDescriere";
            this.LblWHDescriere.Size = new System.Drawing.Size(0, 13);
            this.LblWHDescriere.TabIndex = 27;
            // 
            // txtQtyMAX
            // 
            this.txtQtyMAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQtyMAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyMAX.Location = new System.Drawing.Point(120, 143);
            this.txtQtyMAX.Name = "txtQtyMAX";
            this.txtQtyMAX.Size = new System.Drawing.Size(54, 20);
            this.txtQtyMAX.TabIndex = 106;
            this.txtQtyMAX.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Canitate MAX.";
            // 
            // txtQtyMIN
            // 
            this.txtQtyMIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQtyMIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyMIN.Location = new System.Drawing.Point(120, 117);
            this.txtQtyMIN.Name = "txtQtyMIN";
            this.txtQtyMIN.Size = new System.Drawing.Size(54, 20);
            this.txtQtyMIN.TabIndex = 105;
            this.txtQtyMIN.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Canitate MIN.";
            // 
            // CmbWH
            // 
            this.CmbWH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbWH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbWH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbWH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbWH.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbWH.FormattingEnabled = true;
            this.CmbWH.Location = new System.Drawing.Point(433, 289);
            this.CmbWH.Name = "CmbWH";
            this.CmbWH.Size = new System.Drawing.Size(234, 21);
            this.CmbWH.TabIndex = 4;
            this.CmbWH.SelectedIndexChanged += new System.EventHandler(this.CmbWH_SelectedIndexChanged);
            // 
            // frmAddConfAreaStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 461);
            this.Controls.Add(this.LblWHDescriere);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbWH);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSalvez);
            this.Controls.Add(this.CkPickingAllow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAreaCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmAddConfAreaStorage";
            this.ShowIcon = false;
            this.Text = "Adaugare/Configurare Zone de Stocare";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddConfAreaStorage_FormClosed);
            this.Load += new System.EventHandler(this.frmAddConfAreaStorage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAreaCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGreutate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInaltime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLatime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLungime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CkPickingAllow;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSalvez;
        private MultiColumnComboBox CmbWH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblWHDescriere;
        private System.Windows.Forms.TextBox txtQtyMAX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQtyMIN;
        private System.Windows.Forms.Label label9;
    }
}