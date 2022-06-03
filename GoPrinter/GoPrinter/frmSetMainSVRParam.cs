using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoPrinter
{
    public partial class frmSetMainSVRParam : Form
    {
        private GroupBox groupBox2;
        private TextBox txtAuthKey;
        private Label label6;
        private TextBox txtIPPRNSVR;
        private Label label5;
        private Button CmdExit;
        private Button CmdSave;
        private GroupBox groupBox1;
        private TextBox txtScIP;
        private Label label9;
        private TextBox txtScDB;
        private Label label10;
        private TextBox txtScPass;
        private Label label7;
        private TextBox txtScUser;
        private Label label8;
        private TextBox txtMSSQLDB;
        private Label label4;
        private TextBox txtMSSQLIP;
        private Label label3;
        private TextBox txtMSSQLPass;
        private Label label1;
        private TextBox txtMSSQLUser;
        private Label label2;
    
        public frmSetMainSVRParam()
        {
            InitializeComponent();
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            if (txtMSSQLUser.Text.Trim() == "")
            {
                MessageBox.Show("Campul SuperUser este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtMSSQLPass.Text.Trim() == "")
            {
                MessageBox.Show("Campul Parola este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtMSSQLIP.Text.Trim() == "")
            {
                MessageBox.Show("Campul IP Address este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtMSSQLDB.Text.Trim() == "")
            {
                MessageBox.Show("Campul DataBase este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtScUser.Text.Trim() == "")
            {
                MessageBox.Show("Campul iScala User este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtScDB.Text.Trim() == "")
            {
                MessageBox.Show("Campul iScala DataBase este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtScIP.Text.Trim() == "")
            {
                MessageBox.Show("Campul iScala IP Server Address este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtIPPRNSVR.Text.Trim() == "")
            {
                MessageBox.Show("Campul IP Print Server este gol.", "GoWHManagamenetAdmin");
                return;

            }
            if (txtAuthKey.Text.Trim() == "")
            {
                MessageBox.Show("Campul Authorisation Key este gol.", "GoWHManagamenetAdmin");
                return;

            }
              
            mRegistry mreg = new mRegistry();
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_USER", CryptorEngine.Encrypt(txtMSSQLUser.Text.Trim(),true)) == false)
            {
                if (mreg.CreateKey(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter") == true)
                {
                    if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_USER", CryptorEngine.Encrypt(txtMSSQLUser.Text.Trim(),true)) == false)
                    {
                        MessageBox.Show("Nu pot salva MSSQL User in registry dupa KEY.", "GoWHManagamenetAdmin");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nu pot salva MSSQL User in registry.", "GoWHManagamenetAdmin");
                    return;
                }
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_PASS", CryptorEngine.Encrypt(txtMSSQLPass.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL Passwd in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_IP", CryptorEngine.Encrypt(txtMSSQLIP.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL IP Address in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "MSSQL_DB", CryptorEngine.Encrypt(txtMSSQLDB.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL DataBase in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "SCALA_USER", CryptorEngine.Encrypt(txtScUser.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala User in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "SCALA_PASS", CryptorEngine.Encrypt(txtScPass.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala Pass in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "SCALA_DB", CryptorEngine.Encrypt(txtScDB.Text.Trim(),true) ) == false)
            {
                MessageBox.Show("Nu pot salva iScala Pass in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "SCALA_IP", CryptorEngine.Encrypt(txtScIP.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala IP Server Address in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "IP_PRINT", CryptorEngine.Encrypt(txtIPPRNSVR.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva IP Adrres Server Print in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "AUTH_KEY", CryptorEngine.Encrypt(txtAuthKey.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva AUTHORIZATION KEY in registry.", "GoWHManagamenetAdmin");
                return;
            }
            mreg = null;
            MessageBox.Show("Am salvat datele cu succes.Aplicatia trebuie repornita.", "GoWHManagamenetAdmin");
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmSetMainSVRParam_Load(object sender, EventArgs e)
        {
            try
            {
                txtMSSQLUser.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_USER, true);
                txtMSSQLPass.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_PASS, true);
                txtMSSQLIP.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP, true);
                txtMSSQLDB.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_DB, true);
                txtScUser.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_USER, true);
                txtScPass.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_PASS, true);
                txtScIP.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_IP, true);
                txtScDB.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_DB, true);
                
                txtAuthKey.Text = CryptorEngine.Decrypt(MyGlobal.MY_AUTH_KEY, true);
            }
            catch { GC.Collect(); }
        }

        private void frmSetMainSVRParam_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmSetSRVParam = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetMainSVRParam));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAuthKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIPPRNSVR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtScIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtScDB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtScPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtScUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMSSQLDB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMSSQLIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMSSQLPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSSQLUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAuthKey);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIPPRNSVR);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(11, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 72);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Setari GoWH ";
            // 
            // txtAuthKey
            // 
            this.txtAuthKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthKey.Location = new System.Drawing.Point(84, 44);
            this.txtAuthKey.Name = "txtAuthKey";
            this.txtAuthKey.Size = new System.Drawing.Size(179, 20);
            this.txtAuthKey.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Auth KEY";
            // 
            // txtIPPRNSVR
            // 
            this.txtIPPRNSVR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPPRNSVR.Location = new System.Drawing.Point(84, 18);
            this.txtIPPRNSVR.Name = "txtIPPRNSVR";
            this.txtIPPRNSVR.Size = new System.Drawing.Size(179, 20);
            this.txtIPPRNSVR.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "IP PrintSRV";
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(197, 351);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(91, 25);
            this.CmdExit.TabIndex = 26;
            this.CmdExit.Text = "E&xit";
            this.CmdExit.UseVisualStyleBackColor = true;
            // 
            // CmdSave
            // 
            this.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSave.Location = new System.Drawing.Point(197, 320);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(91, 25);
            this.CmdSave.TabIndex = 25;
            this.CmdSave.Text = "&Save";
            this.CmdSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtScIP);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtScDB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtScPass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtScUser);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtMSSQLDB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMSSQLIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMSSQLPass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMSSQLUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 227);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Setari MSSQL ";
            // 
            // txtScIP
            // 
            this.txtScIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScIP.Location = new System.Drawing.Point(84, 201);
            this.txtScIP.Name = "txtScIP";
            this.txtScIP.Size = new System.Drawing.Size(179, 20);
            this.txtScIP.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "iScala IP";
            // 
            // txtScDB
            // 
            this.txtScDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScDB.Location = new System.Drawing.Point(84, 175);
            this.txtScDB.Name = "txtScDB";
            this.txtScDB.Size = new System.Drawing.Size(179, 20);
            this.txtScDB.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "iScala DB";
            // 
            // txtScPass
            // 
            this.txtScPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScPass.Location = new System.Drawing.Point(84, 149);
            this.txtScPass.Name = "txtScPass";
            this.txtScPass.Size = new System.Drawing.Size(179, 20);
            this.txtScPass.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "iScala Pass";
            // 
            // txtScUser
            // 
            this.txtScUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScUser.Location = new System.Drawing.Point(84, 123);
            this.txtScUser.Name = "txtScUser";
            this.txtScUser.Size = new System.Drawing.Size(179, 20);
            this.txtScUser.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "iScala User";
            // 
            // txtMSSQLDB
            // 
            this.txtMSSQLDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLDB.Location = new System.Drawing.Point(84, 97);
            this.txtMSSQLDB.Name = "txtMSSQLDB";
            this.txtMSSQLDB.Size = new System.Drawing.Size(179, 20);
            this.txtMSSQLDB.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nume DB";
            // 
            // txtMSSQLIP
            // 
            this.txtMSSQLIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLIP.Location = new System.Drawing.Point(84, 71);
            this.txtMSSQLIP.Name = "txtMSSQLIP";
            this.txtMSSQLIP.Size = new System.Drawing.Size(179, 20);
            this.txtMSSQLIP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "IP Address";
            // 
            // txtMSSQLPass
            // 
            this.txtMSSQLPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLPass.Location = new System.Drawing.Point(84, 45);
            this.txtMSSQLPass.Name = "txtMSSQLPass";
            this.txtMSSQLPass.Size = new System.Drawing.Size(179, 20);
            this.txtMSSQLPass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Passwd";
            // 
            // txtMSSQLUser
            // 
            this.txtMSSQLUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLUser.Location = new System.Drawing.Point(84, 19);
            this.txtMSSQLUser.Name = "txtMSSQLUser";
            this.txtMSSQLUser.Size = new System.Drawing.Size(179, 20);
            this.txtMSSQLUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SuperUser";
            // 
            // frmSetMainSVRParam
            // 
            this.ClientSize = new System.Drawing.Size(299, 385);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSetMainSVRParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSetMainSVRParam_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}