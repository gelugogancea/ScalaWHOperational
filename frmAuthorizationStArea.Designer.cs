namespace GoWHMgmAdmin
{
    partial class frmAuthorizationStArea
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
            this.CmdCauta = new System.Windows.Forms.Button();
            this.txtCauta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSalvez = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblValid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblOrgRole = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblRealName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbUser = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblStAreaDescription = new System.Windows.Forms.Label();
            this.LblWhDescription = new System.Windows.Forms.Label();
            this.CmbSTArea = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbWH = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rbDescriere = new System.Windows.Forms.RadioButton();
            this.rbCodStArea = new System.Windows.Forms.RadioButton();
            this.CkAllArea = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(630, 9);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 25);
            this.CmdCauta.TabIndex = 7;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // txtCauta
            // 
            this.txtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCauta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauta.Location = new System.Drawing.Point(56, 12);
            this.txtCauta.Name = "txtCauta";
            this.txtCauta.Size = new System.Drawing.Size(206, 20);
            this.txtCauta.TabIndex = 4;
            this.txtCauta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCauta_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Cauta ";
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(5, 54);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(716, 263);
            this.MyListView.TabIndex = 8;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(630, 438);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 9;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSalvez
            // 
            this.CmdSalvez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSalvez.Location = new System.Drawing.Point(630, 407);
            this.CmdSalvez.Name = "CmdSalvez";
            this.CmdSalvez.Size = new System.Drawing.Size(91, 25);
            this.CmdSalvez.TabIndex = 3;
            this.CmdSalvez.Text = "&Salvez";
            this.CmdSalvez.UseVisualStyleBackColor = true;
            this.CmdSalvez.Click += new System.EventHandler(this.CmdSalvez_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblValid);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LblOrgRole);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LblRealName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbUser);
            this.groupBox1.Location = new System.Drawing.Point(6, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 158);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utilizator";
            // 
            // LblValid
            // 
            this.LblValid.AutoSize = true;
            this.LblValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblValid.Location = new System.Drawing.Point(77, 124);
            this.LblValid.Name = "LblValid";
            this.LblValid.Size = new System.Drawing.Size(10, 13);
            this.LblValid.TabIndex = 54;
            this.LblValid.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Valid";
            // 
            // LblOrgRole
            // 
            this.LblOrgRole.AutoSize = true;
            this.LblOrgRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblOrgRole.Location = new System.Drawing.Point(77, 103);
            this.LblOrgRole.Name = "LblOrgRole";
            this.LblOrgRole.Size = new System.Drawing.Size(10, 13);
            this.LblOrgRole.TabIndex = 52;
            this.LblOrgRole.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Functie";
            // 
            // LblRealName
            // 
            this.LblRealName.AutoSize = true;
            this.LblRealName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblRealName.Location = new System.Drawing.Point(77, 79);
            this.LblRealName.Name = "LblRealName";
            this.LblRealName.Size = new System.Drawing.Size(10, 13);
            this.LblRealName.TabIndex = 50;
            this.LblRealName.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Nume Real";
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblUser.Location = new System.Drawing.Point(77, 53);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(10, 13);
            this.LblUser.TabIndex = 48;
            this.LblUser.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Log User";
            // 
            // CmbUser
            // 
            this.CmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUser.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbUser.FormattingEnabled = true;
            this.CmbUser.Location = new System.Drawing.Point(9, 23);
            this.CmbUser.Name = "CmbUser";
            this.CmbUser.Size = new System.Drawing.Size(216, 21);
            this.CmbUser.TabIndex = 0;
            this.CmbUser.SelectedIndexChanged += new System.EventHandler(this.CmbUser_SelectedIndexChanged);
            this.CmbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUser_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CkAllArea);
            this.groupBox2.Controls.Add(this.LblStAreaDescription);
            this.groupBox2.Controls.Add(this.LblWhDescription);
            this.groupBox2.Controls.Add(this.CmbSTArea);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CmbWH);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(307, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 158);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Utilizator";
            // 
            // LblStAreaDescription
            // 
            this.LblStAreaDescription.AutoSize = true;
            this.LblStAreaDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblStAreaDescription.Location = new System.Drawing.Point(76, 95);
            this.LblStAreaDescription.Name = "LblStAreaDescription";
            this.LblStAreaDescription.Size = new System.Drawing.Size(10, 13);
            this.LblStAreaDescription.TabIndex = 54;
            this.LblStAreaDescription.Text = "-";
            // 
            // LblWhDescription
            // 
            this.LblWhDescription.AutoSize = true;
            this.LblWhDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblWhDescription.Location = new System.Drawing.Point(76, 43);
            this.LblWhDescription.Name = "LblWhDescription";
            this.LblWhDescription.Size = new System.Drawing.Size(10, 13);
            this.LblWhDescription.TabIndex = 53;
            this.LblWhDescription.Text = "-";
            // 
            // CmbSTArea
            // 
            this.CmbSTArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSTArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbSTArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbSTArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSTArea.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbSTArea.FormattingEnabled = true;
            this.CmbSTArea.Location = new System.Drawing.Point(79, 71);
            this.CmbSTArea.Name = "CmbSTArea";
            this.CmbSTArea.Size = new System.Drawing.Size(125, 21);
            this.CmbSTArea.TabIndex = 2;
            this.CmbSTArea.SelectedIndexChanged += new System.EventHandler(this.CmbSTArea_SelectedIndexChanged);
            this.CmbSTArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSTArea_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 51;
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
            this.CmbWH.Location = new System.Drawing.Point(79, 19);
            this.CmbWH.Name = "CmbWH";
            this.CmbWH.Size = new System.Drawing.Size(125, 21);
            this.CmbWH.TabIndex = 1;
            this.CmbWH.SelectedIndexChanged += new System.EventHandler(this.CmbWH_SelectedIndexChanged);
            this.CmbWH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbWH_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Gestiune";
            // 
            // rbDescriere
            // 
            this.rbDescriere.AutoSize = true;
            this.rbDescriere.Location = new System.Drawing.Point(377, 15);
            this.rbDescriere.Name = "rbDescriere";
            this.rbDescriere.Size = new System.Drawing.Size(70, 17);
            this.rbDescriere.TabIndex = 6;
            this.rbDescriere.TabStop = true;
            this.rbDescriere.Text = "Descriere";
            this.rbDescriere.UseVisualStyleBackColor = true;
            // 
            // rbCodStArea
            // 
            this.rbCodStArea.AutoSize = true;
            this.rbCodStArea.Location = new System.Drawing.Point(286, 15);
            this.rbCodStArea.Name = "rbCodStArea";
            this.rbCodStArea.Size = new System.Drawing.Size(47, 17);
            this.rbCodStArea.TabIndex = 5;
            this.rbCodStArea.TabStop = true;
            this.rbCodStArea.Text = "Cod ";
            this.rbCodStArea.UseVisualStyleBackColor = true;
            // 
            // CkAllArea
            // 
            this.CkAllArea.AutoSize = true;
            this.CkAllArea.Location = new System.Drawing.Point(209, 22);
            this.CkAllArea.Name = "CkAllArea";
            this.CkAllArea.Size = new System.Drawing.Size(90, 17);
            this.CkAllArea.TabIndex = 55;
            this.CkAllArea.Text = "Toate Zonele";
            this.CkAllArea.UseVisualStyleBackColor = true;
            // 
            // frmAuthorizationStArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 487);
            this.Controls.Add(this.rbDescriere);
            this.Controls.Add(this.rbCodStArea);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSalvez);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtCauta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MyListView);
            this.MaximizeBox = false;
            this.Name = "frmAuthorizationStArea";
            this.ShowIcon = false;
            this.Text = "Autorizare Zone";
            this.Load += new System.EventHandler(this.frmAuthorizationStArea_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAuthorizationStArea_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.TextBox txtCauta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSalvez;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblValid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblOrgRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblRealName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label label2;
        private MultiColumnComboBox CmbUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblStAreaDescription;
        private System.Windows.Forms.Label LblWhDescription;
        private MultiColumnComboBox CmbSTArea;
        private System.Windows.Forms.Label label1;
        private MultiColumnComboBox CmbWH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbDescriere;
        private System.Windows.Forms.RadioButton rbCodStArea;
        private System.Windows.Forms.CheckBox CkAllArea;
    }
}