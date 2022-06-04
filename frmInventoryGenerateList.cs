using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmInventoryGenerateList : Form
    {
        public long ID_INVENTAR = 0;
        public int[] MY_INVENT_LIST = null;
        public frmInventoryGenerateList()
        {
            InitializeComponent();
        }

        private void CmdCreateList_Click(object sender, EventArgs e)
        {
            int i = 0;
            i=GenerateList();
            if (i == -1)
            {
                MessageBox.Show("Listele au fost deja generate","Eroare",MessageBoxButtons.OK  ,MessageBoxIcon.Error   ,MessageBoxDefaultButton.Button1     );  
                return; 
            }
            else if (i == -100)
            {
                MessageBox.Show("SQL Engine Error\r\nVerificati SQL statement sau SP", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                MessageBox.Show("Listele de Inventar au fost generate cu succes.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private int GenerateList()
        {
            int MyErr = 0;

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

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("[InventCreateList]");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@INVENTNo", SqlDbType.BigInt));
            mcmd.Parameters["@INVENTNo"].Value = ID_INVENTAR;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mErr", SqlDbType.Int));
            mcmd.Parameters["@mErr"].Direction = ParameterDirection.Output;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
             try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception ermsg)
            {
                string m = "";
                m = ermsg.ToString();
            }
            MyErr = (int)mcmd.Parameters["@mErr"].Value ; 

            mcmd = null;
            return MyErr;
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmInventoryGenerateList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmInventoryGenerateList = null;  
            }
            catch { }
        }

        private void CmdPrintList_Click(object sender, EventArgs e)
        {
            int MyListNo = 0;
            int TotalListe = 0;
            int i = 0;
            if (txtListNo.Text.Trim() == "" && CkOption.Checked==false   )
            {
                if (MessageBox.Show("ATENTIE!!!\r\nAti ales optiunea pentru tiparirea tuturor listelor generate pentru acest Inventar.\r\n\r\nContinui ? ", "OK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return; 
                }
                if (GiveMeTotalList() == -1)
                {
                    MessageBox.Show("Nu sunt generate liste", "OOoooppppsss");
                    return;
                }
                else
                {
                    TotalListe = MY_INVENT_LIST.GetUpperBound(0);
                    TotalListe++;
                    MessageBox.Show("Pentru inventarul cu numarul " + ID_INVENTAR.ToString() + "\r\nsunt generate " + TotalListe.ToString()  + " liste de inventar\r\n\r\nApasa OK pentru tiparire", "OK");  
                }
                for (i = 0; i <= MY_INVENT_LIST.GetUpperBound(0); i++)
                {
                    PrintList(MY_INVENT_LIST[i] );
                }
                MessageBox.Show("Am terminat de procesat\r\nDaca exista probleme de tiparire\r\nListele se pot tipari specificand numarul listei de inventar.","OK");  
            }
            else
            {
                if (CkOption.Checked == false)
                {
                    try
                    {
                        MyListNo = int.Parse(txtListNo.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Numarul Listei este reprezentat numeric.", "Oooppsss!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                else
                {
                    if (txtListNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Nu exista o denumire Zona.", "Oooppsss!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return; 
                    }
                }
            }
            if (PrintList(MyListNo) < 0)
            {
                MessageBox.Show("Nu am gasit lista care sa indeplineasca conditiile de cautare.", "Oooppsss!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private int PrintList(int ListNo)
        {
            string mq = "";
            int x = 0;
            string MyListNo = "";
            string MyKeyStock = "";
            string MyDescription = "";
            string MyLocator = "";
            string MyInventArea = "";
            
            this.Cursor = Cursors.WaitCursor;
            Reports.xtrInventoryList mRep = new GoWHMgmAdmin.Reports.xtrInventoryList();   

             
            mRep.DataSource = mRep.dsInventoryList1;
            mRep.DataMember = mRep.dsInventoryList1.tblInventoryList.ToString();      

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (CkOption.Checked == false)
            {
                mq = "SELECT go_invent_list.InventoryNo, go_invent_list.ListNo, go_invent_list_detail.KeyStock, " +
                "go_invent_list_detail.Description, go_invent_list_detail.Locator, " +
                "go_invent_list_detail.InventArea " +
                "FROM  go_invent_list INNER JOIN " +
                "go_invent_list_detail ON go_invent_list.ID = go_invent_list_detail.IDListNo " +
                "and go_invent_list.InventoryNo=" + ID_INVENTAR.ToString() + " AND go_invent_list.ListNo=" + ListNo.ToString() + " " +
                "order by go_invent_list_detail.Locator,go_invent_list_detail.Description;";
            }
            else
            {
                mq = "SELECT go_invent_list.InventoryNo, go_invent_list.ListNo, go_invent_list_detail.KeyStock, " +
                "go_invent_list_detail.Description, go_invent_list_detail.Locator, " +
                "go_invent_list_detail.InventArea " +
                "FROM  go_invent_list INNER JOIN " +
                "go_invent_list_detail ON go_invent_list.ID = go_invent_list_detail.IDListNo " +
                "and go_invent_list.InventoryNo=" + ID_INVENTAR.ToString() + " AND go_invent_list_detail.InventArea LIKE '"+ txtListNo.Text.Trim() +"%'  " +
                "order by go_invent_list_detail.Locator,go_invent_list_detail.Description;";
            }
            try
            {

                mcmd.CommandText = mq;
                mcmd.CommandType = System.Data.CommandType.Text;
                dataread = mcmd.ExecuteReader();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.Trim());
            }


            while (dataread.Read())
            {
                MyListNo=MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                MyKeyStock = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                MyDescription = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                MyLocator = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");
                MyInventArea = MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'");
                mRep.dsInventoryList1.tblInventoryList.Rows.Add(new object[] {  ID_INVENTAR.ToString(),MyListNo,MyKeyStock,MyDescription,MyLocator,MyInventArea       });
                x++;
            }
            if (x > 0)
            {
                mRep.CreateDocument();
                mRep.PrintDialog();
            }
            else
            {
                x = -1;
            }
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
            return x;
        }
        private int GiveMeTotalList()
        {
            string mq = "";
            int x = 0;
            int mRet = 0;
            int ListNo = 0;
            MY_INVENT_LIST = null;
            MY_INVENT_LIST = new int[1];
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            mq = "SELECT go_invent_list.ListNo "+
                 "FROM  go_invent_list INNER JOIN "+
                 "go_invent_list_detail ON go_invent_list.ID = go_invent_list_detail.IDListNo "+
                 "and go_invent_list.InventoryNo="+ ID_INVENTAR.ToString()  +" " + 
                 "group by go_invent_list.ListNo;";
            try
            {
                mcmd.CommandText = mq;
                mcmd.CommandType = System.Data.CommandType.Text;
                dataread = mcmd.ExecuteReader();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.Trim());
            }
            while (dataread.Read())
            {
                
                ListNo  = int.Parse( MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                MY_INVENT_LIST=(int[])MyGlobal.ResizeArray(MY_INVENT_LIST, x + 1);
                MY_INVENT_LIST[x] = ListNo;  
                x++;
            }
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            if (x == 0)
            {
                mRet = -1;  
            }

            
            return mRet; 
        }

        private void CkOption_CheckedChanged(object sender, EventArgs e)
        {
            if (CkOption.Checked == false)
            {
                CkOption.Text = "Lista";  
            }
            else
            {
                CkOption.Text = "Nume Zona";
            }
        }

        private void frmInventoryGenerateList_Load(object sender, EventArgs e)
        {
            txtInventSeqNo.Visible = false;
            label2.Visible = false;  
        }

        private void CkInventSeq_CheckedChanged(object sender, EventArgs e)
        {

            if (CkInventSeq.Checked == true)
            {
                CmdCreateList.Enabled = false;
                txtInventSeqNo.Visible  = true;
                label2.Visible  = true;  
            }
            else
            {
                CmdCreateList.Enabled = true;
                txtInventSeqNo.Visible  = false;
                label2.Visible = false ;  
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}