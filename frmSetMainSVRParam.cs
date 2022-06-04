using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmSetMainSVRParam : Form
    {
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
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_USER", CryptorEngine.Encrypt(txtMSSQLUser.Text.Trim(),true)) == false)
            {
                if (mreg.CreateKey(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin") == true)
                {
                    if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_USER", CryptorEngine.Encrypt(txtMSSQLUser.Text.Trim(),true)) == false)
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
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_PASS", CryptorEngine.Encrypt(txtMSSQLPass.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL Passwd in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_IP", CryptorEngine.Encrypt(txtMSSQLIP.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL IP Address in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MSSQL_DB", CryptorEngine.Encrypt(txtMSSQLDB.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva MSSQL DataBase in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_USER", CryptorEngine.Encrypt(txtScUser.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala User in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_PASS", CryptorEngine.Encrypt(txtScPass.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala Pass in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_DB", CryptorEngine.Encrypt(txtScDB.Text.Trim(),true) ) == false)
            {
                MessageBox.Show("Nu pot salva iScala Pass in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "SCALA_IP", CryptorEngine.Encrypt(txtScIP.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva iScala IP Server Address in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "IP_PRINT", CryptorEngine.Encrypt(txtIPPRNSVR.Text.Trim(),true)) == false)
            {
                MessageBox.Show("Nu pot salva IP Adrres Server Print in registry.", "GoWHManagamenetAdmin");
                return;
            }
            if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "AUTH_KEY", CryptorEngine.Encrypt(txtAuthKey.Text.Trim(),true)) == false)
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
                if (MyGlobal.MY_MSSQL_USER.Trim() != "")
                {
                    txtMSSQLUser.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_USER, true);
                    txtMSSQLPass.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_PASS, true);
                    txtMSSQLIP.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP, true);
                    txtMSSQLDB.Text = CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_DB, true);
                    txtScUser.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_USER, true);
                    txtScPass.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_PASS, true);
                    txtScIP.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_IP, true);
                    txtScDB.Text = CryptorEngine.Decrypt(MyGlobal.MY_ISCALA_DB, true);
                    txtIPPRNSVR.Text = CryptorEngine.Decrypt(MyGlobal.MY_IP_PRINTSVR, true);
                    txtAuthKey.Text = CryptorEngine.Decrypt(MyGlobal.MY_AUTH_KEY, true);
                }
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
    }
}