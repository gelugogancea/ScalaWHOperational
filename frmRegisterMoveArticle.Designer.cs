namespace GoWHMgmAdmin
{
    partial class frmRegisterMoveArticle
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
            this.txtQty = new System.Windows.Forms.TextBox();
            this.MyListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArticol = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.CmbArticol = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbMoveTo = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbSTArea = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.CmbUser = new GoWHMgmAdmin.MultiColumnComboBox();
            this.SuspendLayout();
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(636, 270);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(127, 20);
            this.txtQty.TabIndex = 4;
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(12, 12);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(790, 252);
            this.MyListView.TabIndex = 20;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Articol";
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(636, 318);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(129, 24);
            this.CmdSave.TabIndex = 24;
            this.CmdSave.Text = "Salvez";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Qty";
            // 
            // txtArticol
            // 
            this.txtArticol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticol.Location = new System.Drawing.Point(288, 318);
            this.txtArticol.Name = "txtArticol";
            this.txtArticol.Size = new System.Drawing.Size(67, 20);
            this.txtArticol.TabIndex = 26;
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(13, 318);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(269, 20);
            this.txtDesc.TabIndex = 27;
            // 
            // CmbArticol
            // 
            this.CmbArticol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArticol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbArticol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbArticol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbArticol.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbArticol.FormattingEnabled = true;
            this.CmbArticol.Location = new System.Drawing.Point(15, 316);
            this.CmbArticol.Name = "CmbArticol";
            this.CmbArticol.Size = new System.Drawing.Size(317, 21);
            this.CmbArticol.TabIndex = 28;
            // 
            // CmbMoveTo
            // 
            this.CmbMoveTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbMoveTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbMoveTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbMoveTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbMoveTo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbMoveTo.FormattingEnabled = true;
            this.CmbMoveTo.Location = new System.Drawing.Point(198, 270);
            this.CmbMoveTo.Name = "CmbMoveTo";
            this.CmbMoveTo.Size = new System.Drawing.Size(134, 21);
            this.CmbMoveTo.TabIndex = 2;
            // 
            // CmbSTArea
            // 
            this.CmbSTArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSTArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbSTArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbSTArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSTArea.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbSTArea.FormattingEnabled = true;
            this.CmbSTArea.Location = new System.Drawing.Point(34, 270);
            this.CmbSTArea.Name = "CmbSTArea";
            this.CmbSTArea.Size = new System.Drawing.Size(136, 21);
            this.CmbSTArea.TabIndex = 1;
            this.CmbSTArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSTArea_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Doc.Receptie";
            // 
            // txtDocNo
            // 
            this.txtDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNo.Location = new System.Drawing.Point(636, 294);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(127, 20);
            this.txtDocNo.TabIndex = 29;
            // 
            // CmbUser
            // 
            this.CmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUser.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbUser.FormattingEnabled = true;
            this.CmbUser.Location = new System.Drawing.Point(345, 270);
            this.CmbUser.Name = "CmbUser";
            this.CmbUser.Size = new System.Drawing.Size(208, 21);
            this.CmbUser.TabIndex = 31;
            // 
            // frmRegisterMoveArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 349);
            this.Controls.Add(this.CmbUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.CmbArticol);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtArticol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.CmbMoveTo);
            this.Controls.Add(this.CmbSTArea);
            this.MaximizeBox = false;
            this.Name = "frmRegisterMoveArticle";
            this.Text = "Mutare Articole";
            this.Load += new System.EventHandler(this.frmRegisterMoveArticle_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegisterMoveArticle_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MultiColumnComboBox CmbSTArea;
        private MultiColumnComboBox CmbMoveTo;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ListView MyListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArticol;
        private System.Windows.Forms.TextBox txtDesc;
        private MultiColumnComboBox CmbArticol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDocNo;
        private MultiColumnComboBox CmbUser;
    }
}