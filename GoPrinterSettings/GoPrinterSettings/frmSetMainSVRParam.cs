using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoPrinterSettings
{
    public partial class frmSetMainSVRParam : Form
    {
        private GroupBox groupBox2;
        private TextBox txtAuthKey;
        private Label label6;
        private Button CmdExit;
        private Button CmdSave;
        private GroupBox groupBox1;
        private TextBox txtMSSQLDB;
        private Label label4;
        private TextBox txtMSSQLIP;
        private Label label3;
        private TextBox txtMSSQLPass;
        private Label label1;
        private TextBox txtMSSQLUser;
        private Label label5;
        private ComboBox CmbPrinter;
        private Label label7;
        private ComboBox CmbPrinter1;
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
            if (CmbPrinter.Text.Trim() == "")
            {
                MessageBox.Show("Nu ai selectat Imprimanta.", "GoWHManagamenetAdmin");
                return;

            }
            if (CmbPrinter1.Text.Trim() == "")
            {
                MessageBox.Show("Nu ai selectat a doua Imprimanta.", "GoWHManagamenetAdmin");
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
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "PRINTER_DEF", CryptorEngine.Encrypt(CmbPrinter.Text.Trim(), true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala User in registry.", "GoWHManagamenetAdmin");
                return;
            }

            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "PRINTER_DEF1", CryptorEngine.Encrypt(CmbPrinter1.Text.Trim(), true)) == false)
            {
                MessageBox.Show("Nu pot salva a doua imprimanta in registry.", "GoWHManagamenetAdmin");
                return;
            }
            
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoPrinter", "AUTH_KEY", CryptorEngine.Encrypt(txtAuthKey.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva AUTHORIZATION KEY in registry.", "GoWHManagamenetAdmin");
                return;
            }
            mreg = null;
            MessageBox.Show("Am salvat datele cu succes.", "GoWHManagamenetAdmin");
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
            GiveMeDefaultPrinter();
            MyGlobal.GiveServersSettings();
            try
            {
                txtMSSQLUser.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_USER, true);
                txtMSSQLPass.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_PASS, true);
                txtMSSQLIP.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP, true);
                txtMSSQLDB.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_DB, true);
                CmbPrinter.Text = CryptorEngine.Decrypt(MyGlobal.MY_PRINTER, true);
                CmbPrinter1.Text = CryptorEngine.Decrypt(MyGlobal.MY_PRINTER1, true);
                //txtIPPRNSVR.Text = CryptorEngine.Decrypt(MyGlobal.MY_IP_PRINTSVR, true);
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
            this.CmdExit = new System.Windows.Forms.Button();
            this.CmdSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbPrinter = new System.Windows.Forms.ComboBox();
            this.txtMSSQLDB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMSSQLIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMSSQLPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSSQLUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbPrinter1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAuthKey);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 50);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Setari GoWH ";
            // 
            // txtAuthKey
            // 
            this.txtAuthKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthKey.Location = new System.Drawing.Point(84, 19);
            this.txtAuthKey.Name = "txtAuthKey";
            this.txtAuthKey.Size = new System.Drawing.Size(179, 20);
            this.txtAuthKey.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Auth KEY";
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
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
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
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CmbPrinter1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CmbPrinter);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Imprimanta";
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.Location = new System.Drawing.Point(84, 123);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(178, 21);
            this.CmbPrinter.TabIndex = 15;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Imprimanta 1";
            // 
            // CmbPrinter1
            // 
            this.CmbPrinter1.FormattingEnabled = true;
            this.CmbPrinter1.Location = new System.Drawing.Point(85, 159);
            this.CmbPrinter1.Name = "CmbPrinter1";
            this.CmbPrinter1.Size = new System.Drawing.Size(178, 21);
            this.CmbPrinter1.TabIndex = 17;
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
        private void GiveMeDefaultPrinter()
        {
            
            foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                this.CmbPrinter.Items.Add(strPrinter);
   
            }
            foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                this.CmbPrinter1.Items.Add(strPrinter);

            }

           
            
        }
        
    }
}