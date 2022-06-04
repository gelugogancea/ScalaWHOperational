namespace GoWHMgmAdmin
{
    partial class frmInventoryTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryTeam));
            this.MyListView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblValid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblOrgRole = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblRealName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdExit = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt6 = new System.Windows.Forms.TextBox();
            this.CmbUser = new GoWHMgmAdmin.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyListView
            // 
            this.MyListView.BackColor = System.Drawing.Color.White;
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyListView.Location = new System.Drawing.Point(12, 12);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(687, 184);
            this.MyListView.TabIndex = 9;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 158);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supervisor";
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
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(578, 303);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(121, 26);
            this.CmdSave.TabIndex = 50;
            this.CmdSave.Text = "Save";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CmdExit
            // 
            this.CmdExit.Location = new System.Drawing.Point(578, 335);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(121, 26);
            this.CmdExit.TabIndex = 51;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(337, 213);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(231, 20);
            this.txt1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Oper 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Oper 2";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(337, 239);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(231, 20);
            this.txt2.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Oper 3";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(337, 265);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(231, 20);
            this.txt3.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Oper 4";
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(337, 291);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(231, 20);
            this.txt4.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Oper 5";
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(337, 317);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(231, 20);
            this.txt5.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Oper 6";
            // 
            // txt6
            // 
            this.txt6.Location = new System.Drawing.Point(337, 343);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(231, 20);
            this.txt6.TabIndex = 62;
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
            // frmInventoryTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 376);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MyListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInventoryTeam";
            this.Text = "Configurarea Echipelor de Inventariere";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryTeam_FormClosed);
            this.Load += new System.EventHandler(this.frmInventoryTeam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MyListView;
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
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt6;
    }
}