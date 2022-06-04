using System;
using System.Collections.Generic;
using System.Globalization; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace GoWHMgmAdmin
{

    public partial class frmShowOrder4Delivery : Form
    {
        private string MY_FORMAT_STRING = "";
        private bool IS_NUMBER = false;
        private bool LAST_IS_NUMBER = false;
        private bool IS_UPDATE = false;
        public string DATE_FROM = "";
        public string DATE_TO = "";
        public string MY_STATUS = "";
        public bool O_IS_UPDATE = false;
        public long S_SESSION_ID = 0;
        public string S_TRANSPORT_ID = "";
        public string S_COMPANYNAME = "";
        public string S_ROUTE = "";
        public string S_DELEGATE = "";
        public string S_SUBCONTRACT = "";
        public frmShowOrder4Delivery()
        {
            InitializeComponent();


        }

        private void frmShowOrder4Delivery_Load(object sender, EventArgs e)
        {
            int mz = 0;
            LoadRoute();
            LoadCompanyName();
            if (O_IS_UPDATE == true)
            {
                CmbCompanyName.Text = S_COMPANYNAME;
                comboBox1.Text = S_ROUTE;
                int zz=0;
                
                mz=multiColumnComboBox1.FindString(S_TRANSPORT_ID);
            }
            listView1.Columns.Add("Cda", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("CodClient.", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("NumeClient", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Ruta", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Status", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Responsabil", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("WH", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Date", 100, HorizontalAlignment.Left);
            if (S_SESSION_ID != 0)
            {
                MyGlobal.mFrmShowOrder4Delivery.Text += " - Update : " + S_SESSION_ID.ToString();
            }
           
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending ;

            
        }
        public void LoadMyOrder(string mCriteria, string mStatus, string DateFrom, string DateTo)
        {
            string mq = "";
            ListViewItem lvi = null;
            this.listView1.Items.Clear();

            this.listView1.Refresh();
            this.Cursor = Cursors.WaitCursor;
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001," +
                    "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002," +
                    "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                    "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                    "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY] " +
                    "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                    "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                    "where " +
                    "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                    //"AND [iScalaDB].[dbo].[OR010100].OR01091>=" + mStatus.Trim() + " " +
                    //"AND [iScalaDB].[dbo].[OR010100].OR01056='"+ comboBox1.Text.Trim()   +" '" +
                    "AND [iScalaDB].[dbo].[OR010100].OR01091>=5 " +
                    "and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) " +
                    "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "' " +
                    "group by [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01003, " +
                    "[iScalaDB].[dbo].[SL010100].SL01002,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017, " +
                    "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01050,go_lgst_task.VehicleID " +
                    "having  go_lgst_task.VehicleID IS NULL;";
                /* 
                mq = "select UniqueId,CompanyName,Route,VehicleID,Delegate,SubCompanyTransport,COUNT(*),"+
                        "CASE ISNULL(go_lgst_task.Status,0) "+
                        "WHEN 0 THEN 'LIBER' "+ 
                        "WHEN 1 THEN 'ISTASK' "+ 
                        "WHEN 2 THEN 'INPROCESS' "+ 
                        "WHEN 3 THEN 'ISFINISH' END "+
                        ",CONVERT(VARCHAR(10),InDate, 103) AS [DD/MM/YYYY] "+
                        "from go_lgst_task "+
                        "where CONVERT(VARCHAR(10), InDate, 103) "+
                        "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "' " +
                        "group by UniqueId,CompanyName,Route,VehicleID,Delegate,Status,CONVERT(VARCHAR(10),InDate, 103),SubCompanyTransport";
                 */ 
            }
            else
            {
                /*
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001," +
                    "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL140100].SL14003," +
                    "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                    "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                    "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY] " +
                    "from [iScalaDB].[dbo].[SL140100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                    "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                    "where " +
                    "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL140100.SL14001 and iScalaDB.dbo.SL140100.SL14002='00' " +
                    "AND [iScalaDB].[dbo].[OR010100].OR01091>=" + mStatus.Trim() + " " +
                    "AND [iScalaDB].[dbo].[OR010100].OR01056='" + comboBox1.Text.Trim() + " '" +
                    "AND [iScalaDB].[dbo].[OR010100].OR01091>=5 "+
                    "group by [iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003, " +
                    "[iScalaDB].[dbo].[SL140100].SL14003,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017, " +
                    "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01050,go_lgst_task.VehicleID " +
                    "having  go_lgst_task.VehicleID IS NULL;";
                 */
                
                if (O_IS_UPDATE == false)
                {
                    mq = "select [iScalaDB].[dbo].[OR010100].OR01001," +
                        "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002," +
                        "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                        "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                        "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY] " +
                        "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                        "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                        "where " +
                        "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                        //"AND [iScalaDB].[dbo].[OR010100].OR01091>=5 " +
                        "AND [iScalaDB].[dbo].[OR010100].OR01056='" + comboBox1.Text.Trim() + " '" +
                        "AND [iScalaDB].[dbo].[OR010100].OR01091>=5 " +
                        "and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) " +
                        "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "' " +
                        "group by [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01003, " +
                        "[iScalaDB].[dbo].[SL010100].SL01002,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017, " +
                        "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01050,go_lgst_task.VehicleID " +
                        "having  go_lgst_task.VehicleID IS NULL;";

                }
                else
                {
                    mq = "select [iScalaDB].[dbo].[OR010100].OR01001," +
                        "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002," +
                        "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01091," +
                        "[iScalaDB].[dbo].[OR010100].OR01017,[iScalaDB].[dbo].[OR010100].OR01050," +
                        "CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) AS [DD/MM/YYYY] " +
                        "from [iScalaDB].[dbo].[SL010100],[iScalaDB].[dbo].[OR010100] WITH(NOLOCK) " +
                        "LEFT JOIN go_lgst_task ON go_lgst_task.KeyCmdScala COLLATE SQL_Latin1_General_CP1_CI_AS= [iScalaDB].[dbo].[OR010100].OR01001 " +
                        //"AND go_lgst_task.UniqueID="+ mCriteria.Trim() +" " +
                        "where " +
                        "iScalaDB.dbo.OR010100.OR01045=iScalaDB.dbo.SL010100.SL01001 " +
                        //"AND [iScalaDB].[dbo].[OR010100].OR01091>=5 " +
                        "AND [iScalaDB].[dbo].[OR010100].OR01056='" + S_ROUTE.Trim() + " '" +
                        "AND [iScalaDB].[dbo].[OR010100].OR01091>=5 " +
                        "and CONVERT(VARCHAR(10), [iScalaDB].[dbo].[OR010100].OR01015, 103) " +
                        "between '" + DateFrom.Trim() + "' AND '" + DateTo.Trim() + "' " +
                        "group by [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01003, " +
                        "[iScalaDB].[dbo].[SL010100].SL01002,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017, " +
                        "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01050,go_lgst_task.VehicleID " +
                        "having  go_lgst_task.VehicleID IS NULL;";    
                }
                  
            }
                   
        
            
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                lvi = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));	// This is what's displayed in the password column
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                lvi.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                this.listView1.Items.Add(lvi);

            }
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadRoute()
        {
            string mq = "";
            comboBox1.Items.Add("");
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select CODTRASEU from iScalaDB.dbo.RUTA0000 order by CODTRASEU;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                comboBox1.Items.Add(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
            }

            dataread.Close();
            mcmd = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMyOrder("", MY_STATUS, DATE_FROM, DATE_TO);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMyOrder(comboBox1.Text.Trim()  , MY_STATUS, DATE_FROM, DATE_TO);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmShowOrder4Delivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            DATE_FROM = "";
            DATE_TO = "";
            MY_STATUS = "";
            O_IS_UPDATE = false;
            S_SESSION_ID = 0;
            S_TRANSPORT_ID = "";
            S_COMPANYNAME = "";
            S_ROUTE = "";
            S_DELEGATE = "";
            S_SUBCONTRACT = "";

            try
            {
                
                MyGlobal.mFrmShowOrder4Delivery = null;
            }
            catch { }
        }
        private void LoadMyCar()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MyShipping");
            dataTable.Columns.Add("Vehicle", typeof(String));
            dataTable.Columns.Add("Delegate", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.multiColumnComboBox1.Text = "";
            this.multiColumnComboBox1.DataSource = null;
            this.multiColumnComboBox1.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select VehicleID,Delegate from go_lgst_task group by VehicleID,Delegate;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), 
                    MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'")
                    });
            }
            dataread.Close();

            multiColumnComboBox1.DataSource = dataTable;
            multiColumnComboBox1.DisplayMember = "Vehicle";
            multiColumnComboBox1.ValueMember = "Delegate";

            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        public void LoadCompanyName()
        {
            string mq = "";
            this.CmbCompanyName.Items.Add("");  
            DataTable dataTable = new DataTable("CompanyName");
            dataTable.Columns.Add("Name", typeof(String));
            dataTable.Columns.Add("LastSerial", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbCompanyName.Text = "";
            this.CmbCompanyName.DataSource = null;
            this.CmbCompanyName.Items.Clear();

             

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select CompanyKeyID from pegas_user_count;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.CmbCompanyName.Items.Add(" ");
            while (dataread.Read())
            {

                this.CmbCompanyName.Items.Add(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'")); 
            }
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        public void LoadMyCar1()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MyShipping");
            dataTable.Columns.Add("Vehicle", typeof(String));
            dataTable.Columns.Add("Delegate", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.multiColumnComboBox1.Text = "";
            this.multiColumnComboBox1.DataSource = null;
            this.multiColumnComboBox1.Items.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "select VehicleID,Delegate from go_lgst_task group by VehicleID,Delegate;";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), 
                    MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'")
                    });
            }
            dataread.Close();

            multiColumnComboBox1.DataSource = dataTable;
            multiColumnComboBox1.DisplayMember = "Vehicle";
            multiColumnComboBox1.ValueMember = "Delegate";

            mcmd = null;
            this.txtDelegate.Text = ""; 
            this.Cursor = Cursors.Default;
        }

        private void multiColumnComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int k = 0;
            if (e.KeyValue == 20)
            {
                return;
            }
            char ASCII = Convert.ToChar(e.KeyValue);

            string eASCII = ASCII.ToString(); 
            if (eASCII.ToString()  == "\b")
            {
                MY_FORMAT_STRING = "";
                multiColumnComboBox1.Text = "";
                LAST_IS_NUMBER = false;
                IS_NUMBER = false;
                return;
            }
            try
            {
                k = int.Parse(eASCII.ToString());
                IS_NUMBER = true;
            }
            catch
            {
                IS_NUMBER = false;
            }

            if (multiColumnComboBox1.Text.Length >= 1)
            {
                if (LAST_IS_NUMBER != IS_NUMBER)
                {

                    MY_FORMAT_STRING += "-" + eASCII.ToString().ToUpper();
                }
                else
                {
                    MY_FORMAT_STRING += eASCII.ToString().ToUpper();
                }
            }
            else
            {
                MY_FORMAT_STRING += eASCII.ToString().ToUpper();
            }
        }

        private void multiColumnComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (IS_UPDATE == false)
            {
                multiColumnComboBox1.Text = MY_FORMAT_STRING;
                multiColumnComboBox1.SelectionStart = multiColumnComboBox1.Text.Trim().Length;
                LAST_IS_NUMBER = IS_NUMBER;
                if (multiColumnComboBox1.Text == "")
                {
                    this.txtDelegate.Text = "";
                }
            }
            else
            {
                if (multiColumnComboBox1.Text == "")
                {
                    this.txtDelegate.Text = "";  
                }
            }
        }

        private void multiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)multiColumnComboBox1.SelectedItem).Row.ItemArray[1].ToString();
                //this.LblDescOption.ForeColor = System.Drawing.Color.DarkBlue;

                txtDelegate.Text = ms.Trim();
            }
            catch { }
        }
        private void CmbVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            int k = 0;

            if (e.KeyChar.ToString() == "\b")
            {
                MY_FORMAT_STRING = "";
                multiColumnComboBox1.Text = "";
                LAST_IS_NUMBER = false;
                IS_NUMBER = false;
                return;
            }
            try
            {
                k = int.Parse(e.KeyChar.ToString());
                IS_NUMBER = true;
            }
            catch
            {
                IS_NUMBER = false;
            }

            if (multiColumnComboBox1.Text.Length >= 1)
            {
                if (LAST_IS_NUMBER != IS_NUMBER)
                {

                    MY_FORMAT_STRING += "-" + e.KeyChar.ToString().ToUpper();
                }
                else
                {
                    MY_FORMAT_STRING += e.KeyChar.ToString().ToUpper();
                }
            }
            else
            {
                MY_FORMAT_STRING += e.KeyChar.ToString().ToUpper();
            }
        }

        private void CmbVehicle_TextChanged(object sender, EventArgs e)
        {
            multiColumnComboBox1.Text = MY_FORMAT_STRING;
            multiColumnComboBox1.SelectionStart = multiColumnComboBox1.Text.Trim().Length;
            LAST_IS_NUMBER = IS_NUMBER;
        }

        private void CmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)multiColumnComboBox1.SelectedItem).Row.ItemArray[1].ToString();
                //this.LblDescOption.ForeColor = System.Drawing.Color.DarkBlue;

                txtDelegate.Text = ms.Trim();
            }
            catch { }
        }

        private void txtDelegate_Leave(object sender, EventArgs e)
        {
            string sampleString = txtDelegate.Text.Trim();
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo currentInfo = currentCulture.TextInfo;
            txtDelegate.Text = currentInfo.ToTitleCase(sampleString); 
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            long  SesID=0;
            if (O_IS_UPDATE == false)
            {
                if (this.multiColumnComboBox1.Text == "")
                {
                    MessageBox.Show("Nu exista Mijloc de Transport", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (this.txtDelegate.Text.Trim() == "")
                {
                    MessageBox.Show("Nu exista Nume Delegat", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (listView1.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Nu este nimic selectat.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                if (S_COMPANYNAME.Trim() == "")
                {
                    MessageBox.Show("ERR_COMPANY_NAME\r\nNu exista COMPANY NAME","ERROR",MessageBoxButtons.OK ,MessageBoxIcon.Stop   );  
                    return;
                }
                if (S_ROUTE.Trim() == "")
                {
                    MessageBox.Show("ERR_ROUTE\r\nNu exista RUTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
                    return; 
                }
                if (S_TRANSPORT_ID.Trim()  == "")
                {
                    MessageBox.Show("ERR_ROUTE\r\nNu exista TRANSPORT_ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
                    return; 
                }
                if (S_SESSION_ID == 0)
                {
                    MessageBox.Show("ERR_ROUTE\r\nNu exista SESS_ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
                    return; 
                }
                //S_SUBCONTRACT; 

                
            }
            if (S_SESSION_ID == 0)
            {
                SesID = SaveHeader(this.CmbCompanyName.Text.Trim());
            }
            else
            {
                SesID = S_SESSION_ID;
            }
            for (i = 0; i < listView1.Items.Count; i++)
            {

                if(listView1.Items[i].Selected == true)
                {

                    if (O_IS_UPDATE == false)
                    {
                        if (SaveDataProc(SesID, listView1.Items[i].SubItems[1].Text.Trim(), listView1.Items[i].Text.Trim(), listView1.Items[i].SubItems[3].Text.Trim(), CmbCompanyName.Text.Trim(), multiColumnComboBox1.Text.Trim(), txtSubCompanyName.Text.Trim(), txtDelegate.Text.Trim(), listView1.Items[i].SubItems[7].Text.Trim(), 0) <= 0)
                        {
                            MessageBox.Show("Nu se poate salva inregistrarea : " + Convert.ToString(i + 1), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return; 
                        }
                    }
                    else
                    {
                        if (SaveDataProc(SesID, listView1.Items[i].SubItems[1].Text.Trim(), listView1.Items[i].Text.Trim(), listView1.Items[i].SubItems[3].Text.Trim(), CmbCompanyName.Text.Trim(), S_TRANSPORT_ID, S_SUBCONTRACT, S_DELEGATE, listView1.Items[i].SubItems[7].Text.Trim(), 0) <= 0)
                        {
                            MessageBox.Show("Nu se poate salva inregistrarea : " + Convert.ToString(i + 1), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return; 
                        }
                    }
                }
            }
            MessageBox.Show("Datele au fost salvate cu succes\r\n");
            MyGlobal.mFrmDeliveryTransp.LoadData("", "5", DATE_FROM.Trim(), DATE_TO.Trim());
            this.Close(); 
        }
        long SaveDataProc(long mUniqueNumber,string CustomerCode,string mOrder,string mRoute,string mCompanyName, string VehicleID,string SubCompanyName, string Delegate,string OrderDate, long IDREC)
        {
            string mq = "";
            long ret = 0;
            long MyErr = 0;
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
            
            if (IDREC == 0)
            {
                System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("SaveOrders4Delivery");
                mcmd.Connection = MyGlobal.MY_SQL_CON;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerCode", SqlDbType.NChar, CustomerCode.Length));
                mcmd.Parameters["@CustomerCode"].Value = CustomerCode;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNo", SqlDbType.NChar, mOrder.Length));
                mcmd.Parameters["@OrderNo"].Value = mOrder;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UNQID", SqlDbType.BigInt));
                mcmd.Parameters["@UNQID"].Value = mUniqueNumber;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DROUTE", SqlDbType.NVarChar, mRoute.Length));
                mcmd.Parameters["@DROUTE"].Value = mRoute;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TRID", SqlDbType.NVarChar, VehicleID.Length));
                mcmd.Parameters["@TRID"].Value = VehicleID;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DELEGATE", SqlDbType.NVarChar, Delegate.Length));
                mcmd.Parameters["@DELEGATE"].Value = Delegate;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TRCOMPNAME", SqlDbType.NVarChar, mCompanyName.Length));
                mcmd.Parameters["@TRCOMPNAME"].Value = mCompanyName;
                
                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SUBTCOMP", SqlDbType.NVarChar, SubCompanyName.Length));
                mcmd.Parameters["@SUBTCOMP"].Value = SubCompanyName;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SORDERDATE", SqlDbType.NVarChar, OrderDate.Length));
                mcmd.Parameters["@SORDERDATE"].Value = OrderDate;

                mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", SqlDbType.BigInt));
                mcmd.Parameters["@MErr"].Direction = ParameterDirection.Output;
                
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
                    MyErr = (long)mcmd.Parameters["@MERR"].Value;
                }
                catch (Exception m)
                {
                    string msg = m.Message.ToString();
                    MyErr = -100;
                }

                

                dataread.Close();
                mcmd = null;
                ret = MyErr;
            
            }
            else
            {
                System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
                mcmd.Connection = MyGlobal.MY_SQL_CON;

                mq = "update [GoWH].[dbo].[go_lgst_task] SET KeyCmdScala='" + mOrder + "',VehicleID='" + VehicleID.Trim() + "',Delegate='" + Delegate.Trim() + "' where IDLG=" + IDREC.ToString() + ";";
                mcmd.CommandText = mq;
                mcmd.CommandType = System.Data.CommandType.Text;
                try
                {
                    mcmd.ExecuteNonQuery();
                }
                catch (Exception emsg)
                {
                    MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                    ret = -1;
                }
                mcmd = null;
            }
                     
            return ret;
        }
        private long SaveHeader(string CompanyName)
        {
            long MyErr = 0;

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

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("SaveUniqSession");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", SqlDbType.NVarChar, CompanyName.Length));
            mcmd.Parameters["@CompanyName"].Value = CompanyName;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", SqlDbType.BigInt ));
            mcmd.Parameters["@MErr"].Direction = ParameterDirection.Output;

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
                MyErr = (long)mcmd.Parameters["@MERR"].Value;
            }
            catch(Exception m)
            {
                string msg = m.Message.ToString() ; 
                MyErr = -100; 
            }

            //MessageBox.Show("Datele au fost salvate cu succes\r\n");
            
            dataread.Close();
            mcmd = null;
            return MyErr;
        }

        int SaveData(string mOrder, string VehicleID, string Delegate, long IDREC)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IDREC == 0)
            {
                mq = "INSERT INTO [GoWH].[dbo].[go_lgst_task] " +
                    "([KeyCmdScala],[VehicleID],[Delegate],[Status],[InDate],[UpToDate]) " +
                    "VALUES ('" + mOrder.Trim() + "','" + VehicleID.Trim() + "','" + Delegate.Trim() + "',1,getdate(),NULL)";
            }
            else
            {
                mq = "update [GoWH].[dbo].[go_lgst_task] SET KeyCmdScala='" + mOrder + "',VehicleID='" + VehicleID.Trim() + "',Delegate='" + Delegate.Trim() + "' where IDLG=" + IDREC.ToString() + ";";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
            }
            mcmd = null;
            return ret;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter Sorter = new ListViewSorter();
              
            listView1.ListViewItemSorter = Sorter;
            if (!(listView1.ListViewItemSorter is ListViewSorter))
                return;
            Sorter = (ListViewSorter)listView1.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                listView1.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            listView1.Sort();

        }







    }
    public class ListViewSorter : System.Collections.IComparer
    {
        public int Compare(object o1, object o2)
        {
            if (!(o1 is ListViewItem))
                return (0);
            if (!(o2 is ListViewItem))
                return (0);

            ListViewItem lvi1 = (ListViewItem)o2;
            string str1 = lvi1.SubItems[ByColumn].Text;
            ListViewItem lvi2 = (ListViewItem)o1;
            string str2 = lvi2.SubItems[ByColumn].Text;

            int result;
            if (lvi1.ListView.Sorting == SortOrder.Ascending)
                result = String.Compare(str1, str2);
            else
                result = String.Compare(str2, str1);

            LastSort = ByColumn;

            return (result);
        }


        public int ByColumn
        {
            get { return Column; }
            set { Column = value; }
        }
        int Column = 0;

        public int LastSort
        {
            get { return LastColumn; }
            set { LastColumn = value; }
        }
        int LastColumn = 0;
    } 
}