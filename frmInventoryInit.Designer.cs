namespace GoWHMgmAdmin
{
    partial class frmInventoryInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryInit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInitPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblIDInvent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValidTo = new System.Windows.Forms.MaskedTextBox();
            this.txtValidFrom = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.txt9 = new System.Windows.Forms.TextBox();
            this.txt8 = new System.Windows.Forms.TextBox();
            this.txt7 = new System.Windows.Forms.TextBox();
            this.txt6 = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdInit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmPass);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtInitPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LblIDInvent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValidTo);
            this.groupBox1.Controls.Add(this.txtValidFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perioada desfasurarii inventarului";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(150, 71);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(235, 20);
            this.txtConfirmPass.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Confirmare Parola";
            // 
            // txtInitPass
            // 
            this.txtInitPass.Location = new System.Drawing.Point(150, 50);
            this.txtInitPass.Name = "txtInitPass";
            this.txtInitPass.PasswordChar = '*';
            this.txtInitPass.Size = new System.Drawing.Size(235, 20);
            this.txtInitPass.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Parola inchidere proceduri";
            // 
            // LblIDInvent
            // 
            this.LblIDInvent.AutoSize = true;
            this.LblIDInvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIDInvent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblIDInvent.Location = new System.Drawing.Point(391, 69);
            this.LblIDInvent.Name = "LblIDInvent";
            this.LblIDInvent.Size = new System.Drawing.Size(18, 20);
            this.LblIDInvent.TabIndex = 10;
            this.LblIDInvent.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID Inventar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pana La  (ZZ/LL/AAAA)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "De La  (ZZ/LL/AAAA)";
            // 
            // txtValidTo
            // 
            this.txtValidTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidTo.Location = new System.Drawing.Point(394, 19);
            this.txtValidTo.Mask = "00/00/0000";
            this.txtValidTo.Name = "txtValidTo";
            this.txtValidTo.Size = new System.Drawing.Size(72, 20);
            this.txtValidTo.TabIndex = 6;
            // 
            // txtValidFrom
            // 
            this.txtValidFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFrom.Location = new System.Drawing.Point(150, 20);
            this.txtValidFrom.Mask = "00/00/0000";
            this.txtValidFrom.Name = "txtValidFrom";
            this.txtValidFrom.Size = new System.Drawing.Size(72, 20);
            this.txtValidFrom.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt10);
            this.groupBox2.Controls.Add(this.txt9);
            this.groupBox2.Controls.Add(this.txt8);
            this.groupBox2.Controls.Add(this.txt7);
            this.groupBox2.Controls.Add(this.txt6);
            this.groupBox2.Controls.Add(this.txt5);
            this.groupBox2.Controls.Add(this.txt4);
            this.groupBox2.Controls.Add(this.txt3);
            this.groupBox2.Controls.Add(this.txt2);
            this.groupBox2.Controls.Add(this.txt1);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 289);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comisia de Inventar";
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(17, 256);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(468, 20);
            this.txt10.TabIndex = 17;
            // 
            // txt9
            // 
            this.txt9.Location = new System.Drawing.Point(17, 230);
            this.txt9.Name = "txt9";
            this.txt9.Size = new System.Drawing.Size(468, 20);
            this.txt9.TabIndex = 16;
            // 
            // txt8
            // 
            this.txt8.Location = new System.Drawing.Point(17, 204);
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(468, 20);
            this.txt8.TabIndex = 15;
            // 
            // txt7
            // 
            this.txt7.Location = new System.Drawing.Point(17, 178);
            this.txt7.Name = "txt7";
            this.txt7.Size = new System.Drawing.Size(468, 20);
            this.txt7.TabIndex = 14;
            // 
            // txt6
            // 
            this.txt6.Location = new System.Drawing.Point(17, 152);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(468, 20);
            this.txt6.TabIndex = 13;
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(17, 126);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(468, 20);
            this.txt5.TabIndex = 12;
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(17, 100);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(468, 20);
            this.txt4.TabIndex = 11;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(17, 74);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(468, 20);
            this.txt3.TabIndex = 10;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(17, 48);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(468, 20);
            this.txt2.TabIndex = 9;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(17, 22);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(468, 20);
            this.txt1.TabIndex = 8;
            // 
            // CmdExit
            // 
            this.CmdExit.Location = new System.Drawing.Point(520, 115);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(132, 23);
            this.CmdExit.TabIndex = 4;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // CmdInit
            // 
            this.CmdInit.Location = new System.Drawing.Point(520, 34);
            this.CmdInit.Name = "CmdInit";
            this.CmdInit.Size = new System.Drawing.Size(132, 23);
            this.CmdInit.TabIndex = 5;
            this.CmdInit.Text = "Initializare";
            this.CmdInit.UseVisualStyleBackColor = true;
            this.CmdInit.Click += new System.EventHandler(this.CmdInit_Click);
            // 
            // frmInventoryInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 416);
            this.Controls.Add(this.CmdInit);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInventoryInit";
            this.Text = "Initializare Inventar";
            this.Load += new System.EventHandler(this.frmInventoryInit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryInit_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtValidTo;
        private System.Windows.Forms.MaskedTextBox txtValidFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.TextBox txt9;
        private System.Windows.Forms.TextBox txt8;
        private System.Windows.Forms.TextBox txt7;
        private System.Windows.Forms.TextBox txt6;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label LblIDInvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdExit;
        private System.Windows.Forms.Button CmdInit;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInitPass;
        private System.Windows.Forms.Label label4;
    }
}