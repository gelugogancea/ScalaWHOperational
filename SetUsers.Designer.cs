namespace GoWHMgmAdmin
{
    partial class SetUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUsers));
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSave = new System.Windows.Forms.Button();
            this.txtOrgRole = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRealSurname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MyListFuncRight = new System.Windows.Forms.ListView();
            this.MyListAvailableFunc = new System.Windows.Forms.ListView();
            this.MyListView = new System.Windows.Forms.ListView();
            this.txtAccessLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValidTo = new System.Windows.Forms.MaskedTextBox();
            this.txtValidFrom = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(703, 471);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 38;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdSave
            // 
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Location = new System.Drawing.Point(133, 471);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(91, 25);
            this.CmdSave.TabIndex = 37;
            this.CmdSave.Text = "&Save User";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // txtOrgRole
            // 
            this.txtOrgRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgRole.Location = new System.Drawing.Point(88, 441);
            this.txtOrgRole.Name = "txtOrgRole";
            this.txtOrgRole.Size = new System.Drawing.Size(136, 20);
            this.txtOrgRole.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Functie";
            // 
            // txtRealSurname
            // 
            this.txtRealSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealSurname.Location = new System.Drawing.Point(88, 415);
            this.txtRealSurname.Name = "txtRealSurname";
            this.txtRealSurname.Size = new System.Drawing.Size(136, 20);
            this.txtRealSurname.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Prenume";
            // 
            // txtRealName
            // 
            this.txtRealName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealName.Location = new System.Drawing.Point(88, 389);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(136, 20);
            this.txtRealName.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nume";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(88, 363);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(136, 20);
            this.txtPassword.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Parola";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(88, 337);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(136, 20);
            this.txtUserName.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Utilizator";
            // 
            // MyListFuncRight
            // 
            this.MyListFuncRight.Location = new System.Drawing.Point(432, 12);
            this.MyListFuncRight.Name = "MyListFuncRight";
            this.MyListFuncRight.Size = new System.Drawing.Size(362, 205);
            this.MyListFuncRight.TabIndex = 26;
            this.MyListFuncRight.UseCompatibleStateImageBehavior = false;
            this.MyListFuncRight.SelectedIndexChanged += new System.EventHandler(this.MyListFuncRight_SelectedIndexChanged);
            this.MyListFuncRight.DoubleClick += new System.EventHandler(this.MyListFuncRight_DoubleClick);
            this.MyListFuncRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListFuncRight_KeyDown);
            // 
            // MyListAvailableFunc
            // 
            this.MyListAvailableFunc.Location = new System.Drawing.Point(432, 223);
            this.MyListAvailableFunc.Name = "MyListAvailableFunc";
            this.MyListAvailableFunc.Size = new System.Drawing.Size(362, 238);
            this.MyListAvailableFunc.TabIndex = 25;
            this.MyListAvailableFunc.UseCompatibleStateImageBehavior = false;
            this.MyListAvailableFunc.SelectedIndexChanged += new System.EventHandler(this.MyListAvailableFunc_SelectedIndexChanged);
            this.MyListAvailableFunc.DoubleClick += new System.EventHandler(this.MyListAvailableFunc_DoubleClick);
            // 
            // MyListView
            // 
            this.MyListView.Location = new System.Drawing.Point(2, 12);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(424, 319);
            this.MyListView.TabIndex = 24;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.SelectedIndexChanged += new System.EventHandler(this.MyListView_SelectedIndexChanged);
            this.MyListView.DoubleClick += new System.EventHandler(this.MyListView_DoubleClick);
            this.MyListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyListView_KeyPress);
            // 
            // txtAccessLevel
            // 
            this.txtAccessLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessLevel.Location = new System.Drawing.Point(311, 339);
            this.txtAccessLevel.Name = "txtAccessLevel";
            this.txtAccessLevel.Size = new System.Drawing.Size(109, 20);
            this.txtAccessLevel.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Nivel Acces";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValidTo);
            this.groupBox1.Controls.Add(this.txtValidFrom);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(232, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 96);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Validare ";
            // 
            // txtValidTo
            // 
            this.txtValidTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidTo.Location = new System.Drawing.Point(59, 46);
            this.txtValidTo.Mask = "00/00/0000  00:00:00";
            this.txtValidTo.Name = "txtValidTo";
            this.txtValidTo.Size = new System.Drawing.Size(129, 20);
            this.txtValidTo.TabIndex = 61;
            // 
            // txtValidFrom
            // 
            this.txtValidFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFrom.Location = new System.Drawing.Point(59, 19);
            this.txtValidFrom.Mask = "00/00/0000  00:00:00";
            this.txtValidFrom.Name = "txtValidFrom";
            this.txtValidFrom.Size = new System.Drawing.Size(129, 20);
            this.txtValidFrom.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Format : LL/DD/YYYY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Pana La";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "De La";
            // 
            // SetUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 504);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAccessLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.txtOrgRole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRealSurname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyListFuncRight);
            this.Controls.Add(this.MyListAvailableFunc);
            this.Controls.Add(this.MyListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetUsers";
            this.Text = "SetUsers";
            this.Load += new System.EventHandler(this.SetUsers_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetUsers_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.TextBox txtOrgRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRealSurname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView MyListFuncRight;
        private System.Windows.Forms.ListView MyListAvailableFunc;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.TextBox txtAccessLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtValidFrom;
        private System.Windows.Forms.MaskedTextBox txtValidTo;
    }
}