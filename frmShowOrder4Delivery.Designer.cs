namespace GoWHMgmAdmin
{
    partial class frmShowOrder4Delivery
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDelegate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmdSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbCompanyName = new System.Windows.Forms.ComboBox();
            this.txtSubCompanyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.multiColumnComboBox1 = new GoWHMgmAdmin.MultiColumnComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(293, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(5, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(680, 355);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ruta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(580, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 21);
            this.button2.TabIndex = 8;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDelegate
            // 
            this.txtDelegate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDelegate.Location = new System.Drawing.Point(212, 32);
            this.txtDelegate.Name = "txtDelegate";
            this.txtDelegate.Size = new System.Drawing.Size(108, 20);
            this.txtDelegate.TabIndex = 77;
            this.txtDelegate.Leave += new System.EventHandler(this.txtDelegate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Delegat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Transport";
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(580, 3);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(105, 21);
            this.CmdSave.TabIndex = 79;
            this.CmdSave.Text = "Save";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Companie";
            // 
            // CmbCompanyName
            // 
            this.CmbCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbCompanyName.FormattingEnabled = true;
            this.CmbCompanyName.Location = new System.Drawing.Point(75, 3);
            this.CmbCompanyName.Name = "CmbCompanyName";
            this.CmbCompanyName.Size = new System.Drawing.Size(153, 21);
            this.CmbCompanyName.TabIndex = 80;
            // 
            // txtSubCompanyName
            // 
            this.txtSubCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubCompanyName.Location = new System.Drawing.Point(398, 33);
            this.txtSubCompanyName.Name = "txtSubCompanyName";
            this.txtSubCompanyName.Size = new System.Drawing.Size(176, 20);
            this.txtSubCompanyName.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "SubContract";
            // 
            // multiColumnComboBox1
            // 
            this.multiColumnComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.multiColumnComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.multiColumnComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiColumnComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiColumnComboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.multiColumnComboBox1.FormattingEnabled = true;
            this.multiColumnComboBox1.Location = new System.Drawing.Point(70, 34);
            this.multiColumnComboBox1.Name = "multiColumnComboBox1";
            this.multiColumnComboBox1.Size = new System.Drawing.Size(92, 21);
            this.multiColumnComboBox1.TabIndex = 78;
            this.multiColumnComboBox1.SelectedIndexChanged += new System.EventHandler(this.multiColumnComboBox1_SelectedIndexChanged);
            this.multiColumnComboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.multiColumnComboBox1_KeyDown);
            this.multiColumnComboBox1.TextChanged += new System.EventHandler(this.multiColumnComboBox1_TextChanged);
            // 
            // frmShowOrder4Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 418);
            this.Controls.Add(this.txtSubCompanyName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbCompanyName);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.multiColumnComboBox1);
            this.Controls.Add(this.txtDelegate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.MaximizeBox = false;
            this.Name = "frmShowOrder4Delivery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Order 4 Delivery";
            this.Load += new System.EventHandler(this.frmShowOrder4Delivery_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShowOrder4Delivery_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        public MultiColumnComboBox multiColumnComboBox1;
        public System.Windows.Forms.TextBox txtDelegate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox CmbCompanyName;
        public System.Windows.Forms.TextBox txtSubCompanyName;
        private System.Windows.Forms.Label label5;
    }
}