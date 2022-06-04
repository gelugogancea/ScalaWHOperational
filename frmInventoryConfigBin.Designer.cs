namespace GoWHMgmAdmin
{
    partial class frmInventoryConfigBin
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
            this.CmdExit = new System.Windows.Forms.Button();
            this.MyListView = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtWH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmbLocatii = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CkDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(402, 317);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(115, 23);
            this.CmdExit.TabIndex = 10;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(12, 37);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(505, 172);
            this.MyListView.TabIndex = 78;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            this.MyListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyListView_MouseDoubleClick);
            this.MyListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyListView_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Locator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Zona";
            // 
            // txtArea
            // 
            this.txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArea.Location = new System.Drawing.Point(70, 266);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(289, 20);
            this.txtArea.TabIndex = 82;
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // txtWH
            // 
            this.txtWH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWH.Location = new System.Drawing.Point(70, 292);
            this.txtWH.Name = "txtWH";
            this.txtWH.Size = new System.Drawing.Size(289, 20);
            this.txtWH.TabIndex = 84;
            this.txtWH.Leave += new System.EventHandler(this.txtWH_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Depozit";
            // 
            // CmdSave
            // 
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Location = new System.Drawing.Point(402, 282);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(115, 23);
            this.CmdSave.TabIndex = 85;
            this.CmdSave.Text = "Salvare";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CmbLocatii
            // 
            this.CmbLocatii.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLocatii.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbLocatii.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbLocatii.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbLocatii.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.CmbLocatii.FormattingEnabled = true;
            this.CmbLocatii.Location = new System.Drawing.Point(70, 226);
            this.CmbLocatii.Name = "CmbLocatii";
            this.CmbLocatii.Size = new System.Drawing.Size(289, 21);
            this.CmbLocatii.TabIndex = 79;
            // 
            // CkDelete
            // 
            this.CkDelete.AutoSize = true;
            this.CkDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkDelete.Location = new System.Drawing.Point(70, 320);
            this.CkDelete.Name = "CkDelete";
            this.CkDelete.Size = new System.Drawing.Size(48, 17);
            this.CkDelete.TabIndex = 86;
            this.CkDelete.Text = "Sterg";
            this.CkDelete.UseVisualStyleBackColor = true;
            // 
            // frmInventoryConfigBin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 352);
            this.Controls.Add(this.CkDelete);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.txtWH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbLocatii);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.CmdExit);
            this.MaximizeBox = false;
            this.Name = "frmInventoryConfigBin";
            this.ShowIcon = false;
            this.Text = "Bin Config for Inventory";
            this.Load += new System.EventHandler(this.frmInventoryConfigBin_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryConfigBin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.ListView MyListView;
        private MultiColumnComboBox CmbLocatii;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtWH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.CheckBox CkDelete;
    }
}