using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        public int R_OPTION = 0;
        private void CmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { MyGlobal.mFrmReport = null; }
            catch { };
            GC.Collect(); 
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.No;
            this.Refresh();
            MyGlobal.mFrmShowReport = new frmShowReport();
            if (R_OPTION == 1)
            {
                if (this.txtDeLa.Text.Trim() == "-  -" || this.txtDeLa.Text.Trim() == "/  /")
                {
                    MessageBox.Show("Nu este setat De La");
                    return;
                }
                if (this.txtPanaLa.Text.Trim() == "-  -" || this.txtPanaLa.Text.Trim() == "/  /")
                {
                    MessageBox.Show("Nu este setat Pana La");
                    return;
                }
                
                MyGlobal.mFrmShowReport.ShowReport(txtDeLa.Text.Trim(), txtPanaLa.Text.Trim(), R_OPTION, "","","");
            }
            else if (R_OPTION == 2)
            {
                MyGlobal.mFrmShowReport.ShowReport("","", R_OPTION, "", CmbArticol.Text.Trim()   , txtLocSymbol.Text.Trim()   );
            }
           
            MyGlobal.mFrmShowReport.Show();
            this.Cursor = Cursors.Default;
            this.Refresh();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (R_OPTION == 1)
            {
                label4.Visible = false;
                label5.Visible = false;
                CmbArticol.Visible = false;
                txtLocSymbol.Visible = false; 
            }
            else if (R_OPTION==2)
            {
                txtDeLa.Visible = false;
                txtPanaLa.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                LoadArticle();

            }
            else if (R_OPTION==3)
            {
            
            }
        }
        private void LoadArticle()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MasterData");
            dataTable.Columns.Add("COD", typeof(String));
            dataTable.Columns.Add("Denumire", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbArticol.Text = "";
            CmbArticol.DataSource = null;
            this.CmbArticol.Items.Clear();
            this.CmbArticol.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT StockCode,Description1+Description2 FROM dbo.go_article_masterdata order by StockCode;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbArticol.DataSource = dataTable;
            CmbArticol.DisplayMember = "COD";
            CmbArticol.ValueMember = "Denumire";
            CmbArticol.Text = "";
            this.CmbArticol.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
