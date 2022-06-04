using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GoWHMgmAdmin
{
    public partial class frmInventoryInit : Form
    {
        public frmInventoryInit()
        {
            InitializeComponent();
        }

        private void frmInventoryInit_Load(object sender, EventArgs e)
        {
            string a = "";
            string b = "";
            a=SystemInformation.ComputerName.ToString();
           
            b=SystemInformation.UserName.ToString();
                     
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventoryInit_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryInit=null;
            }
            catch { }
        }

        private void CmdInit_Click(object sender, EventArgs e)
        {
            long ID = 0;
            string crypt = "";
            

            if (txtInitPass.Text.Trim() == "")
            {
                MessageBox.Show("Nu este setata nicio Parola","");
                return;
            }
            if (txtConfirmPass.Text.Trim() == "")
            {
                MessageBox.Show("Nu este completata Parola de confirmare", "");
                return;
            }
            if (txtInitPass.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                MessageBox.Show("Parola de Confirmare nu este aceeasi cu cea initiala ", "");
                return;
            }
            else
            {
                crypt = CryptorEngine.Encrypt(txtConfirmPass.Text.Trim(), true);
            }
            if (this.txtValidFrom.Text.Trim() == "__/__/____")
            {
                MessageBox.Show("Nu este setata validarea De La");
                return;
            }
            if (this.txtValidTo.Text.Trim() == "__/__/____")
            {
                MessageBox.Show("Nu este setata validarea Pana La");
                return;
            }
            if (txt1.Text.Trim() == "")
            {
                MessageBox.Show("Trebuie setat cel putin un Responsabil pentru Inventar");
                return;
            }

            if (MessageBox.Show("Esti sigur ca datele sunt corecte ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            this.Cursor = Cursors.No;
            ID = MyInventoryInit(MyGlobal.SwitchDate4Sys(txtValidFrom.Text.ToString(), MyGlobal.MY_LANGUAGE), MyGlobal.SwitchDate4Sys(txtValidTo.Text.ToString(), MyGlobal.MY_LANGUAGE), txt1.Text.ToString(), txt2.Text.ToString(), txt3.Text.ToString(), txt4.Text.ToString(), txt5.Text.ToString(), txt6.Text.ToString(), txt7.Text.ToString(), txt8.Text.ToString(), txt9.Text.ToString(), txt10.Text.ToString(), crypt.Trim());
            LblIDInvent.Text = ID.ToString();
            this.Cursor = Cursors.Default;
            CmdInit.Enabled = false;
            MessageBox.Show("Inventarul Numarul : "+ ID.ToString()+ " s-a initializat cu succes");
        }
        private long MyInventoryInit(string Dela, string PanaLa, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10,string encryptpass)
        {
            
            int MyErr = 0;
            long InventoryID = 0;

            if (MyGlobal.MY_SQL_CON.State == ConnectionState.Broken || MyGlobal.MY_SQL_CON.State == ConnectionState.Closed)
            {
                try
                {
                    MyGlobal.MY_SQL_CON.Close();

                }
                catch { GC.Collect(); }
                try
                {
                    MyGlobal.MY_SQL_CON.Open();
                }
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return -1; }
            }

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("InitInventory");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VFROM",SqlDbType.DateTime));
            mcmd.Parameters["@VFROM"].Value = Dela;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VTO", SqlDbType.DateTime));
            mcmd.Parameters["@VTO"].Value = PanaLa;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP1", SqlDbType.NVarChar,R1.Length));
            mcmd.Parameters["@RESP1"].Value = R1;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP2", SqlDbType.NVarChar, R2.Length));
            mcmd.Parameters["@RESP2"].Value = R2;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP3", SqlDbType.NVarChar, R3.Length));
            mcmd.Parameters["@RESP3"].Value = R3;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP4", SqlDbType.NVarChar, R4.Length));
            mcmd.Parameters["@RESP4"].Value = R4;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP5", SqlDbType.NVarChar, R5.Length));
            mcmd.Parameters["@RESP5"].Value = R5;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP6", SqlDbType.NVarChar, R6.Length));
            mcmd.Parameters["@RESP6"].Value = R6;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP7", SqlDbType.NVarChar, R7.Length));
            mcmd.Parameters["@RESP7"].Value = R7;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP8", SqlDbType.NVarChar, R8.Length));
            mcmd.Parameters["@RESP8"].Value = R8;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP9", SqlDbType.NVarChar, R9.Length));
            mcmd.Parameters["@RESP9"].Value = R9;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESP10", SqlDbType.NVarChar, R10.Length));
            mcmd.Parameters["@RESP10"].Value = R10;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MYPASSWD", SqlDbType.NVarChar, encryptpass.Length));
            mcmd.Parameters["@MYPASSWD"].Value = encryptpass;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MYUSER", SqlDbType.NVarChar));
            mcmd.Parameters["@MYUSER"].Value = MyGlobal.MyUserInfo.MyUser;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDINVENTORY", SqlDbType.BigInt));
            mcmd.Parameters["@IDINVENTORY"].Direction = ParameterDirection.Output;
            
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MERR", SqlDbType.Int));
            mcmd.Parameters["@MERR"].Direction = ParameterDirection.Output;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            
            do
            {
                while (dataread.Read())
                {
            
                }
            } while (dataread.NextResult());
            try
            {
                InventoryID = (long)mcmd.Parameters["@IDINVENTORY"].Value;
            }
            catch { MyErr = 0; }
            try
            {
                MyErr = (int)mcmd.Parameters["@MERR"].Value;
            }
            catch { MyErr = 0; }
            
            if(MyErr==-1)
            {
                MessageBox.Show("Nu s-a putut initializa cu SUCCES acest inventar","");
            }
            else if (MyErr == -2)
            {
                MessageBox.Show("Nu sunt generate Liste de Inventar", "");
            }
            dataread.Close();
            mcmd = null;
            return InventoryID;
        }
    }
}
