namespace GoWHMgmAdmin
{
    partial class frmSetRoute2Order
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.multiColumnComboBox1 = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbPostalCode = new GoWHMgmAdmin.MultiColumnComboBox();
            this.CmbOrders = new GoWHMgmAdmin.MultiColumnComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Comenzi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Cod Postal";
            // 
            // MyListView
            // 
            this.MyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MyListView.Location = new System.Drawing.Point(12, 39);
            this.MyListView.Name = "MyListView";
            this.MyListView.Size = new System.Drawing.Size(717, 252);
            this.MyListView.TabIndex = 77;
            this.MyListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Ruta";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // multiColumnComboBox1
            // 
            this.multiColumnComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.multiColumnComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.multiColumnComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiColumnComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiColumnComboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.multiColumnComboBox1.FormattingEnabled = true;
            this.multiColumnComboBox1.Location = new System.Drawing.Point(267, 12);
            this.multiColumnComboBox1.Name = "multiColumnComboBox1";
            this.multiColumnComboBox1.Size = new System.Drawing.Size(100, 21);
            this.multiColumnComboBox1.TabIndex = 79;
            this.multiColumnComboBox1.SelectedIndexChanged += new System.EventHandler(this.multiColumnComboBox1_SelectedIndexChanged);
            // 
            // CmbPostalCode
            // 
            this.CmbPostalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPostalCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbPostalCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbPostalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbPostalCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbPostalCode.FormattingEnabled = true;
            this.CmbPostalCode.Location = new System.Drawing.Point(445, 12);
            this.CmbPostalCode.Name = "CmbPostalCode";
            this.CmbPostalCode.Size = new System.Drawing.Size(158, 21);
            this.CmbPostalCode.TabIndex = 76;
            // 
            // CmbOrders
            // 
            this.CmbOrders.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbOrders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbOrders.FormattingEnabled = true;
            this.CmbOrders.Location = new System.Drawing.Point(73, 12);
            this.CmbOrders.Name = "CmbOrders";
            this.CmbOrders.Size = new System.Drawing.Size(147, 21);
            this.CmbOrders.TabIndex = 58;
            // 
            // frmSetRoute2Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 379);
            this.Controls.Add(this.multiColumnComboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MyListView);
            this.Controls.Add(this.CmbPostalCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbOrders);
            this.Controls.Add(this.label4);
            this.Name = "frmSetRoute2Order";
            this.ShowIcon = false;
            this.Text = "Set Route To Order";
            this.Load += new System.EventHandler(this.frmSetRoute2Order_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MultiColumnComboBox CmbOrders;
        private System.Windows.Forms.Label label4;
        private MultiColumnComboBox CmbPostalCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView MyListView;
        private MultiColumnComboBox multiColumnComboBox1;
        private System.Windows.Forms.Label label2;

    }
}