namespace GoWHMgmAdmin
{
    partial class frmInventoryGenerateList
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
            this.CmdCreateList = new System.Windows.Forms.Button();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdPrintList = new System.Windows.Forms.Button();
            this.txtListNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CkOption = new System.Windows.Forms.CheckBox();
            this.CkInventSeq = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInventSeqNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CmdCreateList
            // 
            this.CmdCreateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCreateList.Location = new System.Drawing.Point(3, 2);
            this.CmdCreateList.Name = "CmdCreateList";
            this.CmdCreateList.Size = new System.Drawing.Size(90, 23);
            this.CmdCreateList.TabIndex = 87;
            this.CmdCreateList.Text = "Generare Liste";
            this.CmdCreateList.UseVisualStyleBackColor = true;
            this.CmdCreateList.Click += new System.EventHandler(this.CmdCreateList_Click);
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(154, 115);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(107, 23);
            this.CmdExit.TabIndex = 86;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdPrintList
            // 
            this.CmdPrintList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPrintList.Location = new System.Drawing.Point(99, 2);
            this.CmdPrintList.Name = "CmdPrintList";
            this.CmdPrintList.Size = new System.Drawing.Size(162, 23);
            this.CmdPrintList.TabIndex = 88;
            this.CmdPrintList.Text = "Tiparire Liste";
            this.CmdPrintList.UseVisualStyleBackColor = true;
            this.CmdPrintList.Click += new System.EventHandler(this.CmdPrintList_Click);
            // 
            // txtListNo
            // 
            this.txtListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtListNo.Location = new System.Drawing.Point(154, 31);
            this.txtListNo.Name = "txtListNo";
            this.txtListNo.Size = new System.Drawing.Size(107, 20);
            this.txtListNo.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Lista Nr";
            // 
            // CkOption
            // 
            this.CkOption.AutoSize = true;
            this.CkOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkOption.Location = new System.Drawing.Point(154, 57);
            this.CkOption.Name = "CkOption";
            this.CkOption.Size = new System.Drawing.Size(45, 17);
            this.CkOption.TabIndex = 91;
            this.CkOption.Text = "Lista";
            this.CkOption.UseVisualStyleBackColor = true;
            this.CkOption.CheckedChanged += new System.EventHandler(this.CkOption_CheckedChanged);
            // 
            // CkInventSeq
            // 
            this.CkInventSeq.AutoSize = true;
            this.CkInventSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkInventSeq.Location = new System.Drawing.Point(154, 80);
            this.CkInventSeq.Name = "CkInventSeq";
            this.CkInventSeq.Size = new System.Drawing.Size(94, 17);
            this.CkInventSeq.TabIndex = 92;
            this.CkInventSeq.Text = "Inventar Partial";
            this.CkInventSeq.UseVisualStyleBackColor = true;
            this.CkInventSeq.CheckedChanged += new System.EventHandler(this.CkInventSeq_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Inventat Nr  :";
            // 
            // txtInventSeqNo
            // 
            this.txtInventSeqNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventSeqNo.Location = new System.Drawing.Point(85, 77);
            this.txtInventSeqNo.Name = "txtInventSeqNo";
            this.txtInventSeqNo.Size = new System.Drawing.Size(63, 20);
            this.txtInventSeqNo.TabIndex = 93;
            this.txtInventSeqNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmInventoryGenerateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 150);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInventSeqNo);
            this.Controls.Add(this.CkInventSeq);
            this.Controls.Add(this.CkOption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtListNo);
            this.Controls.Add(this.CmdPrintList);
            this.Controls.Add(this.CmdCreateList);
            this.Controls.Add(this.CmdExit);
            this.MaximizeBox = false;
            this.Name = "frmInventoryGenerateList";
            this.ShowIcon = false;
            this.Text = "Create Inventory List";
            this.Load += new System.EventHandler(this.frmInventoryGenerateList_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryGenerateList_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCreateList;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdPrintList;
        private System.Windows.Forms.TextBox txtListNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CkOption;
        private System.Windows.Forms.CheckBox CkInventSeq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInventSeqNo;
    }
}