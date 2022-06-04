using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmImportArticle : Form
    {
        private bool MY_CANCEL = false;
        public frmImportArticle()
        {
            InitializeComponent();
        }

        private void frmImportArticle_Load(object sender, EventArgs e)
        {
            this.rbCodArticol.Checked = true;
            SetListColumns();
            SetComboBoxConditionat();
            LVMenu.Visible = false;
            LoadFromMasterData(0, "");
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

        private void frmImportArticle_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmImpArt=null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CmdImport_Click(object sender, EventArgs e)
        {
            LblTotalInList.Text = "0";
            MyListView.Focus(); 
            if (LoadArticleFromERP() == 0)
            {
                
                MessageBox.Show("Au fost procesate in total : "+LblTotalRecords.Text+" inregistrari.");
            }
        }
        private int LoadArticleFromERP()
        {
            ListViewItem k = null;
            long x = 0;
            int z = 0;
            string mq = "";
            int mret = 0;
            string[] mres = new string[32];
            string mLUserID = "";
            string mLUserNamer = "";
            /*
            string StockCode= "";
            string Description1= "";
            string Description2= "";
            string PriceLocCurr= "";
            string UserDefined1= "";
            string UserDefined2= "";
            string UserDefined3= "";
            string UserDefined4= "";
            string UserDefined5= "";
            string UserDefined6= "";
            string UserDefined7= "";
            string UserDefined8= "";
            string UserDefined9= "";
            string UserDefine10= "";
            string AllowNegQty= "";
            string TestSNqty= "";
            string ExtProdGroup= "";
            string Purchaser= "";
            string ProductGroup= "";
            string ArticlStatus= "";
            string CountOfOrgin= "";
            string ShipmRoule= "";
            string UnitCodeStoc = "";
            */
            bool mreturn=false;
            long xinsert = 0;
            long xupdate = 0;
            long xtotal = 0;
            long xlock = 0;
            bool IsLocked = false;
            LblTotalInsert.Text = "0";
            LblTotalUpdate.Text = "0";
            LblTotalRecords.Text = "0";
            this.LblTotalLock.Text = "0";
            System.Data.SqlClient.SqlDataReader dataread = null; 
            SetListColumns();
            if(this.CmbImpConditionat.Text.Trim()!="" && this.txtSCriteria.Text.Trim()=="")
            {
                MessageBox.Show("Ati ales o optiune de import conditionat dar nu ati completat nici un criteriu.");
                return -1;
            }
            else if (this.CmbImpConditionat.Text.Trim() == "" && this.txtSCriteria.Text.Trim() != "")
            {
                MessageBox.Show("Este completat Criteria dar nu ati selectat nici o optiune.");
                return -1;
            }
            try
            {
                MyGlobal.MY_SCALA_CON.Open();

            }
            catch
            {
                MessageBox.Show("Nu ma pot conecta la " + MyGlobal.MY_ISCALA_IP, "GoWHManagementAdmin");
                return -1;
            }
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SCALA_CON;
            mq = PrepareStatement("ROM", this.txtSCriteria.Text.Trim());
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                dataread = mcmd.ExecuteReader();
            }
            catch(Exception erx)
            {
                MessageBox.Show("A aparut eroarea \r\n " +erx.Message.Trim()+"\r\n");
                mret = -1;
                goto MYEND;
            }
            this.MyListView.BeginUpdate();
            try
            {
                while (dataread.Read())
                {

                    if (MY_CANCEL == true)
                    {
                        MY_CANCEL = false;
                        DialogResult m = MessageBox.Show("Esti sigur ca vrei sa intrerupi procedura de import?", "", MessageBoxButtons.YesNo);
                        if (m == DialogResult.Yes)
                        {
                            goto MYEND;
                        }
                    }
                    mres[0] = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
                    mres[1] = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                    mres[2] = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                    mres[3] = MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'");
                    mres[4] = MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'");
                    mres[5] = MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'");
                    mres[6] = MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'");
                    mres[7] = MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'");
                    mres[8] = MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'");
                    mres[9] = MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'");
                    mres[10] = MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'");
                    mres[11] = MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'");
                    mres[12] = MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'");
                    mres[13] = MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'");
                    mres[14] = MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'");
                    mres[15] = MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'");
                    mres[16] = MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'");
                    mres[17] = MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'");
                    mres[18] = MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'");
                    mres[19] = MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'");
                    mres[20] = MyGlobal.Srch2Escape(dataread[20].ToString().Trim(), "'");
                    mres[21] = MyGlobal.Srch2Escape(dataread[21].ToString().Trim(), "'");
                    mres[22] = MyGlobal.Srch2Escape(dataread[22].ToString().Trim(), "'");
                    mres[23] = MyGlobal.Srch2Escape(dataread[23].ToString().Trim(), "'");
                    mres[24] = MyGlobal.Srch2Escape(dataread[24].ToString().Trim(), "'");
                    mres[25] = MyGlobal.Srch2Escape(dataread[25].ToString().Trim(), "'");
                    mres[26] = MyGlobal.Srch2Escape(dataread[26].ToString().Trim(), "'");
                    mres[27] = MyGlobal.Srch2Escape(dataread[27].ToString().Trim(), "'");
                    mres[28] = MyGlobal.Srch2Escape(dataread[28].ToString().Trim(), "'");
                    mres[29] = MyGlobal.Srch2Escape(dataread[29].ToString().Trim(), "'");
                    mres[30] = MyGlobal.Srch2Escape(dataread[30].ToString().Trim(), "'");
                    mres[31] = MyGlobal.Srch2Escape(dataread[31].ToString().Trim(), "'");
                    mreturn = IsForUpdate(mres[0], ref IsLocked, ref mLUserID, ref mLUserNamer);


                    if (IsLocked == false)
                    {
                        if (mreturn == false)
                        {

                            if (ImportInMasterData(mres, false) < 0)
                            {
                                mret = -1;
                                goto MYEND;
                            }
                            else
                            {

                                if (ImportGroupAndExGroup(mres, false) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportCountryOrig(mres, false) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportPurchaser(mres, false) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportStatus(mres, false) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                xinsert++;
                                LblTotalInsert.Text = xinsert.ToString().Trim();
                                LblTotalInsert.Refresh();
                            }
                        }
                        else
                        {
                            if (ImportInMasterData(mres, true) < 0)
                            {
                                mret = -1;
                                goto MYEND;
                            }
                            else
                            {
                                if (ImportGroupAndExGroup(mres, true) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportCountryOrig(mres, true) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportPurchaser(mres, true) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                if (ImportStatus(mres, true) < 0)
                                {
                                    mret = -1;
                                    goto MYEND;
                                }
                                xupdate++;
                                LblTotalUpdate.Text = xupdate.ToString().Trim();
                                LblTotalUpdate.Refresh();
                            }
                        }
                        k = new ListViewItem(mres[0].Trim());
                        k.SubItems.Add(mres[1].Trim());
                        k.SubItems.Add(mres[2].Trim());
                        k.SubItems.Add(mres[3].Trim());
                        k.SubItems.Add(mres[4].Trim());
                        k.SubItems.Add(mres[5].Trim());
                        k.SubItems.Add(mres[6].Trim());
                        k.SubItems.Add(mres[7].Trim());
                        k.SubItems.Add(mres[8].Trim());
                        k.SubItems.Add(mres[9].Trim());
                        k.SubItems.Add(mres[10].Trim());
                        k.SubItems.Add(mres[11].Trim());
                        k.SubItems.Add(mres[12].Trim());
                        k.SubItems.Add(mres[13].Trim());
                        k.SubItems.Add(mres[14].Trim());
                        k.SubItems.Add(mres[15].Trim());
                        k.SubItems.Add(mres[16].Trim());
                        k.SubItems.Add(mres[17].Trim());
                        k.SubItems.Add(mres[18].Trim());
                        k.SubItems.Add(mres[19].Trim());
                        k.SubItems.Add(mres[20].Trim());
                        k.SubItems.Add(mres[21].Trim());
                        k.SubItems.Add(mres[22].Trim());
                        k.SubItems.Add(mres[23].Trim());
                        k.SubItems.Add(mres[24].Trim());
                        k.SubItems.Add(mres[25].Trim());
                        k.SubItems.Add(mres[26].Trim());
                        k.SubItems.Add(mres[27].Trim());
                        k.SubItems.Add(mres[28].Trim());
                        k.SubItems.Add(mres[29].Trim());
                        k.SubItems.Add(mres[30].Trim());
                        k.SubItems.Add(mres[31].Trim());

                        this.MyListView.Items.Add(k);

                    }
                    else
                    {
                        k = new ListViewItem(mres[0].Trim());
                        k.BackColor = Color.Tomato;
                        k.SubItems.Add("IS_LOCK");
                        k.SubItems.Add(mLUserID);
                        k.SubItems.Add(mLUserNamer);
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        k.SubItems.Add(" ");
                        this.MyListView.Items.Add(k);
                        //this.MyListView.Refresh();
                        xlock++;
                        LblTotalLock.Text = xlock.ToString().Trim();
                        LblTotalLock.Refresh();
                    }
                    xtotal++;
                    LblTotalRecords.Text = xtotal.ToString().Trim();
                    LblTotalRecords.Refresh();

                    x++;
                    for (z = 0; z < 32; z++)
                    {
                        mres[z] = "";
                    }
                    Application.DoEvents();
                }

                LblTotalInList.Text = LblTotalRecords.Text.Trim();
                LblTotalInList.Refresh();
            }
            catch(Exception erx)
                {
                    MessageBox.Show("SQL_ERROR : \r\n"+erx.Message.Trim());
                }
        MYEND:
            try
            {
                this.MyListView.EndUpdate();
                this.MyListView.Refresh();
            }
            catch { GC.Collect(); }
            try
            {
                dataread.Close();
            }
            catch { GC.Collect(); }
            mcmd = null;
            try
            {
                MyGlobal.MY_SCALA_CON.Close();
            }
            finally
            {
                GC.Collect();
            }
            this.CmbImpConditionat.Text = "";
            this.txtSCriteria.Text = "";
            this.LblDescOption.Text = "";
            this.Cursor = Cursors.Default;
            return mret;
        }
        string PrepareStatement(string MyLng,string mOption)
        {
            string s=null;
            string mAddStatement = "";

            if (mOption.Trim() == "")
            {
                s = "SELECT SC01001, SC01002,SC01003,SC01004,SC01010,SC01011,SC01012,SC01013,SC01014,SC01015,SC01016," +
                    "SC01017,SC01018,SC01019,SC01020,SC01021," +
                    "SC01037,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01037 AND dbo.SY240100.SY24001='IB') as MyCapitol," +
                    "SC01023,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01023 AND dbo.SY240100.SY24001='IK') as MySubCapitol,SC01042,SC01043,SC01044,SC01045," +
                    "SC01026,(select dbo.SYPD0100.SYPD003 from dbo.SYPD0100 where " +
                    "LTRIM(RTRIM(dbo.SYPD0100.SYPD001))=LTRIM(RTRIM(dbo.SC010100.SC01026))) as PurchaserName," +
                    "SC01066,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01066 AND dbo.SY240100.SY24001='IC') as StatusArticol," +
                    "SC01067,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01067 AND dbo.SY240100.SY24001='BM') as OrigContry," +
                    "SC01091 as ShipRule," +
                    "CASE dbo.SC010100.SC01133 WHEN 0 THEN (SELECT dbo.SC090100.SC09002 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 1 THEN (SELECT dbo.SC090100.SC09003 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 2 THEN (SELECT dbo.SC090100.SC09004 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 3 THEN (SELECT dbo.SC090100.SC09005 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 4 THEN (SELECT dbo.SC090100.SC09006 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 5 THEN (SELECT dbo.SC090100.SC09007 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 6 THEN (SELECT dbo.SC090100.SC09008 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 7 THEN (SELECT dbo.SC090100.SC09009 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 8 THEN (SELECT dbo.SC090100.SC09010 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 9 THEN (SELECT dbo.SC090100.SC09011 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 10 THEN (SELECT dbo.SC090100.SC09012 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 11 THEN (SELECT dbo.SC090100.SC09013 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 12 THEN (SELECT dbo.SC090100.SC09014 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 13 THEN (SELECT dbo.SC090100.SC09015 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 14 THEN (SELECT dbo.SC090100.SC09016 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 15 THEN (SELECT dbo.SC090100.SC09017 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 16 THEN (SELECT dbo.SC090100.SC09018 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 17 THEN (SELECT dbo.SC090100.SC09019 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 18 THEN (SELECT dbo.SC090100.SC09020 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 19 THEN (SELECT dbo.SC090100.SC09021 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 20 THEN (SELECT dbo.SC090100.SC09022 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 21 THEN (SELECT dbo.SC090100.SC09023 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 22 THEN (SELECT dbo.SC090100.SC09024 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 23 THEN (SELECT dbo.SC090100.SC09025 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 24 THEN (SELECT dbo.SC090100.SC09026 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 25 THEN (SELECT dbo.SC090100.SC09027 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 26 THEN (SELECT dbo.SC090100.SC09028 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 27 THEN (SELECT dbo.SC090100.SC09029 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 28 THEN (SELECT dbo.SC090100.SC09030 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 29 THEN (SELECT dbo.SC090100.SC09031 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 30 THEN (SELECT dbo.SC090100.SC09032 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 31 THEN (SELECT dbo.SC090100.SC09033 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 32 THEN (SELECT dbo.SC090100.SC09034 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 33 THEN (SELECT dbo.SC090100.SC09035 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 34 THEN (SELECT dbo.SC090100.SC09036 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 35 THEN (SELECT dbo.SC090100.SC09037 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 36 THEN (SELECT dbo.SC090100.SC09038 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 37 THEN (SELECT dbo.SC090100.SC09039 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 38 THEN (SELECT dbo.SC090100.SC09040 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 39 THEN (SELECT dbo.SC090100.SC09041 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 40 THEN (SELECT dbo.SC090100.SC09042 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "ELSE 'UNKNOWN' END AS UOM " +
                    "FROM dbo.SC010100;";
            }
            else
            {
                mAddStatement += this.CmbImpConditionat.Text.Trim() +" "+ mOption.Trim();
                s = "SELECT SC01001, SC01002,SC01003,SC01004,SC01010,SC01011,SC01012,SC01013,SC01014,SC01015,SC01016," +
                    "SC01017,SC01018,SC01019,SC01020,SC01021," +
                    "SC01037,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01037 AND dbo.SY240100.SY24001='IB') as MyCapitol," +
                    "SC01023,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01023 AND dbo.SY240100.SY24001='IK') as MySubCapitol,SC01042,SC01043,SC01044,SC01045," +
                    "SC01026,(select dbo.SYPD0100.SYPD003 from dbo.SYPD0100 where " +
                    "LTRIM(RTRIM(dbo.SYPD0100.SYPD001))=LTRIM(RTRIM(dbo.SC010100.SC01026))) as PurchaserName," +
                    "SC01066,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01066 AND dbo.SY240100.SY24001='IC') as StatusArticol," +
                    "SC01067,(select dbo.SY240100.SY24003 from dbo.SY240100 where " +
                    "dbo.SY240100.SY24002=dbo.SC010100.SC01067 AND dbo.SY240100.SY24001='BM') as OrigContry," +
                    "SC01091 as ShipRule," +
                    "CASE dbo.SC010100.SC01133 WHEN 0 THEN (SELECT dbo.SC090100.SC09002 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 1 THEN (SELECT dbo.SC090100.SC09003 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 2 THEN (SELECT dbo.SC090100.SC09004 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 3 THEN (SELECT dbo.SC090100.SC09005 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 4 THEN (SELECT dbo.SC090100.SC09006 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 5 THEN (SELECT dbo.SC090100.SC09007 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 6 THEN (SELECT dbo.SC090100.SC09008 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 7 THEN (SELECT dbo.SC090100.SC09009 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 8 THEN (SELECT dbo.SC090100.SC09010 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 9 THEN (SELECT dbo.SC090100.SC09011 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 10 THEN (SELECT dbo.SC090100.SC09012 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 11 THEN (SELECT dbo.SC090100.SC09013 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 12 THEN (SELECT dbo.SC090100.SC09014 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 13 THEN (SELECT dbo.SC090100.SC09015 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 14 THEN (SELECT dbo.SC090100.SC09016 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 15 THEN (SELECT dbo.SC090100.SC09017 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 16 THEN (SELECT dbo.SC090100.SC09018 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 17 THEN (SELECT dbo.SC090100.SC09019 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 18 THEN (SELECT dbo.SC090100.SC09020 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 19 THEN (SELECT dbo.SC090100.SC09021 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 20 THEN (SELECT dbo.SC090100.SC09022 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 21 THEN (SELECT dbo.SC090100.SC09023 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 22 THEN (SELECT dbo.SC090100.SC09024 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 23 THEN (SELECT dbo.SC090100.SC09025 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 24 THEN (SELECT dbo.SC090100.SC09026 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 25 THEN (SELECT dbo.SC090100.SC09027 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 26 THEN (SELECT dbo.SC090100.SC09028 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 27 THEN (SELECT dbo.SC090100.SC09029 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 28 THEN (SELECT dbo.SC090100.SC09030 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 29 THEN (SELECT dbo.SC090100.SC09031 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 30 THEN (SELECT dbo.SC090100.SC09032 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 31 THEN (SELECT dbo.SC090100.SC09033 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 32 THEN (SELECT dbo.SC090100.SC09034 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 33 THEN (SELECT dbo.SC090100.SC09035 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 34 THEN (SELECT dbo.SC090100.SC09036 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 35 THEN (SELECT dbo.SC090100.SC09037 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 36 THEN (SELECT dbo.SC090100.SC09038 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 37 THEN (SELECT dbo.SC090100.SC09039 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 38 THEN (SELECT dbo.SC090100.SC09040 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 39 THEN (SELECT dbo.SC090100.SC09041 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "WHEN 40 THEN (SELECT dbo.SC090100.SC09042 FROM dbo.SC090100 WHERE dbo.SC090100.SC09001 = '" + MyLng.Trim() + "')" +
                    "ELSE 'UNKNOWN' END AS UOM " +
                    "FROM dbo.SC010100 WHERE " + mAddStatement.Trim() + " order by " + this.CmbImpConditionat.Text.Trim() + ";";
            }
            return s;
        }
        int ImportInMasterData(string[] mData,bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                mq = "insert into dbo.go_article_masterdata(StockCode,Description1,Description2,LocalCurrency,USRDef1,USRDef2,USRDef3,USRDef4,USRDef5,USRDef6,USRDef7,USRDef8,USRDef9,USRDef10,"+
                    "AllowNegStock,TestSNqty,ExtProdGroup,Purchaser,ProductGroup,StockBalance,ReservedQty,BackOrdeQty,SCQtyOrder,ArticlStatus,CountOfOrgin,ShipmRoule,UnitCodeStoc,GoWHClass,mUser,InDate,UpToDate) " +
                    "VALUES('" + mData[0].Trim() + "','" + mData[1].Trim() + "','" + mData[2].Trim() + "',"+
                    "" + mData[3].Trim() + ",'" + mData[4].Trim() + "','" + mData[5].Trim() + "','" + mData[6].Trim() + "',"+
                    "'" + mData[7].Trim() + "','" + mData[8].Trim() + "','" + mData[9].Trim() + "','" + mData[10].Trim() + "',"+
                    "'" + mData[11].Trim() + "','" + mData[12].Trim() + "','" + mData[13].Trim() + "','" + mData[14].Trim() + "',"+
                    "'"+mData[15].Trim()+"','"+mData[18].Trim()+"','"+mData[24].Trim()+"','"+mData[16].Trim()+"',"+mData[20].Trim()+","+
                    "" + mData[21].Trim() + "," + mData[22].Trim() + "," + mData[23].Trim() + "," + mData[26].Trim() + ",'" + mData[28].Trim() + "'," + mData[30].Trim() + ",'" + mData[31].Trim() + "','','"+ MyGlobal.MyUserInfo.MyUser.Trim() +"',getdate(),NULL);";

            }
            else
            {
                mq = "update dbo.go_article_masterdata set Description1='" + mData[1].Trim() + "',Description2='" + mData[2].Trim() + "',"+
                    "LocalCurrency=" + mData[3].Trim() + ",USRDef1='" + mData[4].Trim() + "',USRDef2='" + mData[5].Trim() + "',USRDef3='" + mData[6].Trim() + "',"+
                    "USRDef4='" + mData[7].Trim() + "',USRDef5='" + mData[8].Trim() + "',USRDef6='" + mData[9].Trim() + "',USRDef7='" + mData[10].Trim() + "',"+
                    "USRDef8='" + mData[11].Trim() + "',USRDef9='" + mData[12].Trim() + "',USRDef10='" + mData[13].Trim() + "'," +
                    "AllowNegStock='" + mData[14].Trim() + "',TestSNqty='" + mData[15].Trim() + "',ExtProdGroup='" + mData[18].Trim() + "',"+
                    "Purchaser='" + mData[24].Trim() + "',ProductGroup='" + mData[16].Trim() + "',StockBalance=" + mData[20].Trim() + ","+
                    "ReservedQty=" + mData[21].Trim() + ",BackOrdeQty=" + mData[22].Trim() + ",SCQtyOrder=" + mData[23].Trim() + ",ArticlStatus=" + mData[26].Trim() + ","+
                    "CountOfOrgin='" + mData[28].Trim() + "',ShipmRoule=" + mData[30].Trim() + ",UnitCodeStoc='" + mData[31].Trim() + "',mUser='"+MyGlobal.MyUserInfo.MyUser.Trim()+"',UpToDate=getdate() " +
                    " where StockCode='" + mData[0].Trim() + "';"; 
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch(Exception emsg)
            {
                MessageBox.Show("ERROR : "+emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
            }
            mcmd = null;
            return ret;
        }
        int ImportGroupAndExGroup(string[] mData,bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate==false)
            {
                mq ="insert into dbo.go_article_sc_group(ArtCode,GroupSymbol,GroupDescription,ExGroupSymbol,ExGroupDescription,mUser,InDate,UpToDate) "+
                    "VALUES('" + mData[0].Trim() + "','" + mData[16].Trim() + "','" + mData[17].Trim() + "','" + mData[18].Trim() + "','" + mData[19].Trim() + "','"+MyGlobal.MyUserInfo.MyUser.Trim()+"',getdate(),NULL);";
            }
            else
            {
                mq = "update dbo.go_article_sc_group set GroupSymbol='" + mData[16].Trim() + "',GroupDescription='" + mData[17].Trim() + "',ExGroupSymbol='" + mData[18].Trim() + "',ExGroupDescription='" + mData[19].Trim() + "',mUser='"+MyGlobal.MyUserInfo.MyUser.Trim()+"',UpToDate=getdate() where ArtCode='" + mData[0].Trim() + "';";
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
        int ImportCountryOrig(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
              
                //mq = "insert into dbo.go_article_country(ArtCode,CountrySymbol,Description,mUser,InDate,UpToDate) " +
                //    "VALUES('" + mData[0].Trim() + "','" + mData[28].Trim() + "','" + mData[29].Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
                mq = "insert into dbo.go_article_country(ArtCode,CountrySymbol,Description,mUser,InDate,UpToDate) " +
                    "VALUES('" + MyGlobal.Srch2Escape(mData[0].Trim(), "'") + "','" + MyGlobal.Srch2Escape(mData[28].Trim(), "'") + "','" + MyGlobal.Srch2Escape(mData[29].Trim(), "'") + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
            }
            else
            {
                mq = "update dbo.go_article_country set CountrySymbol='" + MyGlobal.Srch2Escape(mData[28].Trim(), "'") + "',Description='" + MyGlobal.Srch2Escape(mData[29].Trim(), "'") + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where ArtCode='" + MyGlobal.Srch2Escape(mData[0].Trim(), "'") + "';";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim()+"\r\nQ: "+mq, "GoWHManagementAdmin");
                ret = -1;
            }
            mcmd = null;
            return ret;
        }
        int ImportPurchaser(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                mq = "insert into dbo.go_article_purchaser(ArtCode,PurchSymbol,PurchDescription,mUser,InDate,UpToDate) " +
                    "VALUES('" + mData[0].Trim() + "','" + mData[24].Trim() + "','" + mData[25].Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
            }
            else
            {
                mq = "update dbo.go_article_purchaser set PurchSymbol='" + mData[24].Trim() + "',PurchDescription='" + mData[25].Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where ArtCode='" + mData[0].Trim() + "';";
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
        int ImportStatus(string[] mData, bool IsUpdate)
        {
            string mq = "";
            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsUpdate == false)
            {
                mq = "insert into dbo.go_article_sc_status(ArtCode,ArtStatus,StatusDescription,mUser,InDate,UpToDate) " +
                    "VALUES('" + mData[0].Trim() + "','" + mData[26].Trim() + "','" + mData[27].Trim() + "','" + MyGlobal.MyUserInfo.MyUser.Trim() + "',getdate(),NULL);";
            }
            else
            {
                mq = "update dbo.go_article_sc_status set ArtStatus='" + mData[26].Trim() + "',StatusDescription='" + mData[27].Trim() + "',mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',UpToDate=getdate() where ArtCode='" + mData[0].Trim() + "';";
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
        bool IsForUpdate(string mCriteria,ref bool IsLock,ref string mUserID,ref string mUserName)
        {
            long x = 0;
            string mq = "";
            bool ret = false;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            //mq = "SELECT StockCode FROM dbo.go_article_masterdata where StockCode='"+mCriteria.Trim()+"';";
            mq = "SELECT "+
                "(select go_users_def.UserID from go_users_def where ID=go_sys_lock.IDUser)," +
                "(select go_users_def.RealName from go_users_def where ID=go_sys_lock.IDUser)," +
                "(select go_users_def.RealSurname from go_users_def where ID=go_sys_lock.IDUser) " +
                "FROM  go_article_masterdata "+
                "LEFT JOIN "+
                "go_sys_lock ON go_sys_lock.ArtCode = go_article_masterdata.StockCode "+
                "where go_article_masterdata.StockCode='" + mCriteria.Trim() + "';";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                mUserID=dataread[1].ToString().Trim();
                if (mUserID.Trim() == "")
                {
                    IsLock = false;
                }
                else
                {
                    IsLock = true;
                    mUserName = dataread[1].ToString().Trim() + " " + dataread[2].ToString().Trim();
                }

                x++;
            }
            if (x>0)
            {
               ret = true; 
            }
            else
            {
                ret = false; 
            }
            dataread.Close();
            mcmd = null;
            return ret;
        }
        private void LoadFromMasterData(int mOption,string mCriteria)
        {
            string mq = "";
            long x = 0;
            ListViewItem k = null;
            SetListColumns4View();
            this.LblTotalInsert.Text = "0";
            this.LblTotalLock.Text = "0";
            this.LblTotalRecords.Text = "0";
            this.LblTotalUpdate.Text = "0";
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            System.Data.SqlClient.SqlDataReader dataread = null;
            if (mCriteria.Trim() == "")
            {
                mq = "select * from go_article_masterdata order by StockCode;";
            }
            else
            {
                if (mOption == 1)   //Cod Articol
                {
                    mq = "select * from go_article_masterdata where StockCode like '" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if(mOption==2) //Descriere1
                {
                    mq = "select * from go_article_masterdata where Description1 like '%" + mCriteria.Trim() + "%' order by StockCode;";
                }
                else if (mOption == 3) //Gruoup
                {
                    mq = "select * from go_article_masterdata where ProductGroup='" + mCriteria.Trim() + "' order by StockCode;";
                }
                else if (mOption == 4) //Gruoup Extended
                {
                    mq = "select * from go_article_masterdata where ExtProdGroup='" + mCriteria.Trim() + "' order by StockCode;";
                }
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
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

                if (MY_CANCEL == true)
                {
                    goto MYEND;
                }
                k = new ListViewItem(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[20].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[21].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[22].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[23].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[24].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[25].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[26].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[27].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[28].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[29].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[30].ToString().Trim(), "'"));
                //k.SubItems.Add(MyGlobal.Srch2Escape(dataread[31].ToString().Trim(), "'"));

                this.MyListView.Items.Add(k);
                
                Application.DoEvents();
                x++;

            }
        MYEND:
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            MY_CANCEL = false;
            LblTotalInList.Text = x.ToString().Trim();
            LblTotalInList.Refresh();
            try
            {
                dataread.Close();
            }
            catch { };
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            
            
                if (txtCauta.Text.Trim() == "")
                {
                    LoadFromMasterData(0, "");
                }
                else
                {
                
                    if (rbCodArticol.Checked == true)
                    {
                        LoadFromMasterData(1, txtCauta.Text.Trim());
                    }
                    else if(rbDenumireArticol.Checked==true)
                    {
                        LoadFromMasterData(2, txtCauta.Text.Trim());
                    }
                    else if(rbGroup.Checked==true)
                    {
                        LoadFromMasterData(3, txtCauta.Text.Trim());
                    }
                    else if (rbExtendGroup.Checked == true)
                    {
                        LoadFromMasterData(4, txtCauta.Text.Trim());
                    }
                }
        }

        private void CkLock_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            int x = 0;
            int z = 0;
            if (CkLock.Checked == true)
            {
                CkLock.Refresh();
                
                x = int.Parse(this.LblTotalLock.Text.Trim());
                if (x == 0)
                {
                    CkLock.Checked = false;
                    CkLock.Refresh();
                    return; //nu are nici un sens sa continui
                }
                for (z = 0; z < MyListView.Columns.Count; z++)
                {
                    MyListView.Columns[z].Text = "";
                }
                MyListView.Columns[0].Text = "ArtCode";
                MyListView.Columns[1].Text = "Status";
                MyListView.Columns[2].Text = "User";
                MyListView.Columns[3].Text = "Nume";

                do
                {
                    if (CkLock.Checked == true)
                    {
                        for (i = 0; i < MyListView.Items.Count; i++)
                        {
                            if (MyListView.Items[i].SubItems[1].Text.Trim() != "IS_LOCK")
                            {
                                MyListView.Items[i].Remove();
                            }
                            MyListView.Refresh();
                        }

                    }
                } while (MyListView.Items.Count != x);
                CkLock.Checked = false;
                CkLock.Refresh();
            }
        }
        private void SetListColumns()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ArtCode";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr2";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "PriceLocCurr";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef1";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef2";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef4";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef5";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef6";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef7";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef8";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef9";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef10";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AllowNegQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "IsSerial";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Group";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "GroupDescr";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);
            
            colHead = new ColumnHeader();
            colHead.Text = "ExtGroup";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ExtGroupDescr";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "StockBalance";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ReservedQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "BackOrdeQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "SCQtyOrder";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Purchaser";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "PurchaserDescr";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "StatusArt";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "StatusDescr";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "OrigCountry";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "OrigCountryDescr";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ShipmRule";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UnitCodeStock";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }

        private void MyListView_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                
                LVMenu.Show(MyListView,new Point(e.X+15,e.Y));
                
            }
        }

        private void MyListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void copiazaInClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            int z = 0;
            string s = "";
            i = MyListView.SelectedIndices.Count;
            //if (MessageBox.Show("Vrei sa copiezi ce este selectat ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                this.Cursor = Cursors.WaitCursor;
                Clipboard.Clear();
                for (i = 0; i < MyListView.Items.Count; i++)
                {
                    if (MyListView.Items[i].Selected == true)
                    {
                        s += MyListView.Items[i].Text.Trim() + "\t";
                        for (z = 1; z < MyListView.Columns.Count - 1; z++)
                        {
                            if (MyListView.Items[i].SubItems[z].Text.Trim() != "" || MyListView.Items[i].SubItems[z].Text.Trim() != null)
                            {
                                s += MyListView.Items[i].SubItems[z].Text.Trim() + "\t";
                            }
                        }
                        s += "\r\n";
                    }
                }
                Clipboard.SetDataObject(s);
                this.Cursor = Cursors.Default;
                GC.Collect();
            //}
        }
        private void SetListColumns4View()
        {
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ArtCode";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr1";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descr2";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "PriceLocCurr";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef1";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef2";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef3";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef4";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef5";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef6";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef7";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef8";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef9";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UsrDef10";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "AllowNegQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "IsSerial";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

                                   
            colHead = new ColumnHeader();
            colHead.Text = "ExtGroup";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);
                   
            
            colHead = new ColumnHeader();
            colHead.Text = "Purchaser";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);
            
            colHead = new ColumnHeader();
            colHead.Text = "Group";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "StockBalance";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ReservedQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "BackOrdeQty";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "SCQtyOrder";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "StatusArt";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);
                        
            colHead = new ColumnHeader();
            colHead.Text = "OrigCountry";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);
                        
            colHead = new ColumnHeader();
            colHead.Text = "ShipmRule";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UnitCodeStock";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "GoWHClass";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inregistrat";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
        }
        private void SetComboBoxConditionat()
        {
            
            DataTable dataTable = new DataTable("MasterData");
            dataTable.Columns.Add("Camp", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));

            this.CmbImpConditionat.Text = "";
            this.CmbImpConditionat.DataSource = null;
            this.CmbImpConditionat.Items.Clear();
            dataTable.Rows.Add(new String[] { "SC01001", "Cod Articol" });
            dataTable.Rows.Add(new String[] { "SC01002", "Descriere 1" });
            dataTable.Rows.Add(new String[] { "SC01003", "Descriere 2" });
            dataTable.Rows.Add(new String[] { "SC01004", "Moneda Locala" });
            dataTable.Rows.Add(new String[] { "SC01010", "Definit Utilizator 1" });
            dataTable.Rows.Add(new String[] { "SC01011", "Definit Utilizator 2" });
            dataTable.Rows.Add(new String[] { "SC01012", "Definit Utilizator 3" });
            dataTable.Rows.Add(new String[] { "SC01013", "Definit Utilizator 4" });
            dataTable.Rows.Add(new String[] { "SC01014", "Definit Utilizator 5" });
            dataTable.Rows.Add(new String[] { "SC01015", "Definit Utilizator 6" });
            dataTable.Rows.Add(new String[] { "SC01016", "Definit Utilizator 7" });
            dataTable.Rows.Add(new String[] { "SC01017", "Definit Utilizator 8" });
            dataTable.Rows.Add(new String[] { "SC01018", "Definit Utilizator 9" });
            dataTable.Rows.Add(new String[] { "SC01019", "Definit Utilizator 10" });
            dataTable.Rows.Add(new String[] { "SC01020", "Permit Stoc Negativ" });
            dataTable.Rows.Add(new String[] { "SC01021", "Daca este Articol cu Serie Individuala" });
            dataTable.Rows.Add(new String[] { "SC01023", "Grupa Extinsa Produs" });
            dataTable.Rows.Add(new String[] { "SC01026", "Agent Cumparari" });
            dataTable.Rows.Add(new String[] { "SC01037", "Grupa Produs" });
            dataTable.Rows.Add(new String[] { "SC01042", "Cantitate in Stoc" });
            dataTable.Rows.Add(new String[] { "SC01043", "Cantitate Rezervata in Stoc" });
            dataTable.Rows.Add(new String[] { "SC01044", "Cantitate pe comenzi restante" });
            dataTable.Rows.Add(new String[] { "SC01045", "Cantitate comandata la furnizor" });
            dataTable.Rows.Add(new String[] { "SC01066", "Status Articol" });
            dataTable.Rows.Add(new String[] { "SC01067", "Tara de Origine" });
            dataTable.Rows.Add(new String[] { "SC01091", "Regula de achizitie" });
            dataTable.Rows.Add(new String[] { "SC01091", "Regula de livrare" });    
            dataTable.Rows.Add(new String[] { "SC01133", "Unitate de Masura Implicita" });
            
            CmbImpConditionat.DataSource = dataTable;
            CmbImpConditionat.DisplayMember = "Camp";
            CmbImpConditionat.ValueMember = "Descriere";
            CmbImpConditionat.Text = "";           
            this.Cursor = Cursors.Default;
        }

        private void CmbImpConditionat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbImpConditionat.SelectedItem).Row.ItemArray[1].ToString();
                this.LblDescOption.ForeColor = System.Drawing.Color.DarkBlue;
                this.LblDescOption.Text = ms.Trim();
            }
            catch { }
        }

        private void txtCauta_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbCodArticol_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbDenumireArticol_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbExtendGroup_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27)
            {
                MY_CANCEL = true;
            }
        }

        
    }
}