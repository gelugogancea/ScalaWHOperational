using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        public void LoadTreeView(string[][] marr)
        {

            TreeNode mnode = null;
            TreeNode gnode = null;
            TreeNode fnode = null;
            int i = 0;

            string mmodule = "";
            string mgroup = "";
            string mfunc = "";


            for (i = 0; i < marr[0].GetUpperBound(0); i++)
            {
                if (mmodule != marr[0][i] && marr[0][i] != null)
                {
                    mnode = new TreeNode(marr[0][i]);
                    this.tvMenu.Nodes.Add(mnode);


                }
                mmodule = marr[0][i];
                marr[0][i] = null;

                if (mgroup != marr[1][i] && marr[1][i] != null)
                {
                    gnode = new TreeNode(marr[1][i]);
                    mnode.Nodes.Add(gnode);

                }
                mgroup = marr[1][i];
                marr[1][i] = null;
                if (mfunc != marr[2][i])
                {
                    fnode = new TreeNode(marr[2][i].Trim() + " - " + marr[3][i].Trim());
                    gnode.Nodes.Add(fnode);
                }
                mfunc = marr[2][i];
                marr[2][i] = null;
            }
            this.tvMenu.ExpandAll();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                MyGlobal.MY_SQL_CON.Close();
                MyGlobal.MY_SCALA_CON.Close();
                MyGlobal.mFrmLog.Close();
            }
            finally
            {
                GC.Collect();    
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.MY_SQL_CON.Close();
                MyGlobal.MY_SCALA_CON.Close();
                MyGlobal.mFrmLog.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void tvMenu_DoubleClick(object sender, EventArgs e)
        {
            
            int i = 0;
            string k = "";
            TreeNode m;
            try
            {

                m = this.tvMenu.SelectedNode;
                k = m.Text;
                i = k.IndexOf(" ");
                if (k.Substring(0, i) == "ADCNFUS01")
                {
                    this.Cursor = Cursors.No;
                    if(MyGlobal.mFrmSetUsers==null)
                    {
                        SetUsers msetuser=new SetUsers();
                        MyGlobal.mFrmSetUsers = msetuser;
                        msetuser.MdiParent=this;
                        msetuser.Show ();
                        msetuser.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "SRVPARAM")
                {

                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmSetSRVParam == null)
                    {
                        frmSetMainSVRParam msetparamsrv = new frmSetMainSVRParam();
                        MyGlobal.mFrmSetSRVParam=msetparamsrv;
                        msetparamsrv.MdiParent = this;
                        msetparamsrv.Show();
                        msetparamsrv.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if(k.Substring(0,i)=="IMPNOM01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmImpArt == null)
                    {
                        frmImportArticle mfrmimpa = new frmImportArticle();
                        MyGlobal.mFrmImpArt = mfrmimpa;
                        mfrmimpa.MdiParent = this;
                        mfrmimpa.Show();
                        mfrmimpa.BringToFront(); 
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "IMPPART01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmSupplCutom == null)
                    {
                        ImportSupplierAndCustomer mfrmsc = new ImportSupplierAndCustomer();
                        MyGlobal.mFrmSupplCutom = mfrmsc; 
                        mfrmsc.MdiParent = this;
                        mfrmsc.Show();
                        mfrmsc.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "IMPWH01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmImpWareHouse == null)
                    {
                        frmImportWareHouse mfrmwh = new frmImportWareHouse();
                        MyGlobal.mFrmImpWareHouse = mfrmwh;
                        mfrmwh.MdiParent = this;
                        mfrmwh.Show();
                        mfrmwh.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "ADCNFSTAR01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmAddConfAreaStorage == null)
                    {
                        
                        frmAddConfAreaStorage mfrmcsa = new frmAddConfAreaStorage();
                        MyGlobal.mFrmAddConfAreaStorage = mfrmcsa;
                        mfrmcsa.MdiParent = this;
                        mfrmcsa.Show();
                        mfrmcsa.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "ADCNFBIN01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmAddConf3DLoc == null)
                    {
                        frmAddConf3DLoc mfrmac3d = new frmAddConf3DLoc();
                        MyGlobal.mFrmAddConf3DLoc = mfrmac3d;
                        mfrmac3d.MdiParent = this;
                        mfrmac3d.Show();
                        mfrmac3d.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "SETCOD01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmPresentationForm == null)
                    {
                        frmPresentationFom mfrmpresf = new frmPresentationFom();
                        MyGlobal.mFrmPresentationForm = mfrmpresf;
                        mfrmpresf.MdiParent = this;
                        mfrmpresf.Show();
                        mfrmpresf.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "AUTHST01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmAuthorizationStArea == null)
                    {
                        frmAuthorizationStArea mAuthSTA = new frmAuthorizationStArea();
                        MyGlobal.mFrmAuthorizationStArea = mAuthSTA;
                        mAuthSTA.MdiParent = this;
                        mAuthSTA.Show();
                        mAuthSTA.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "AUTHINV01")
                {
                    /*this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmInventoryOrder == null)
                    {
                        frmInventoryOrder mInvOrder = new frmInventoryOrder();
                        MyGlobal.mFrmInventoryOrder = mInvOrder;
                        mInvOrder.MdiParent = this;
                        mInvOrder.Show();
                        mInvOrder.BringToFront();
                    }
                    this.Cursor = Cursors.Default;*/
                    MessageBox.Show("N E I M P L E M E N T A T", "N E I M P L E M E N T A T",MessageBoxButtons.OK,MessageBoxIcon.Error    ); 
                }
                else if (k.Substring(0, i) == "AUTHMOV01")
                {
                    /*this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmAuthorizationLocalMove == null)
                    {
                        frmAuthorizationLocalMove mLocMov = new frmAuthorizationLocalMove();
                        MyGlobal.mFrmAuthorizationLocalMove = mLocMov;
                        mLocMov.MdiParent = this;
                        mLocMov.Show();
                        mLocMov.BringToFront();
                    }
                    this.Cursor = Cursors.Default;*/
                    MessageBox.Show("N E I M P L E M E N T A T", "N E I M P L E M E N T A T", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
                else if (k.Substring(0, i) == "4CLASS01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmClassification == null)
                    {
                        frmClassification mClassification = new frmClassification();
                        MyGlobal.mFrmClassification = mClassification;
                        mClassification.MdiParent = this;
                        mClassification.Show();
                        mClassification.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (k.Substring(0, i) == "STPROP01")
                {
                    this.Cursor = Cursors.No;
                    if (MyGlobal.mFrmStorageProperties == null)
                    {
                        //frmClassification mClassification = new frmClassification();
                        frmStorageProperties mStProp = new frmStorageProperties();
                        MyGlobal.mFrmStorageProperties = mStProp;
                        mStProp.MdiParent = this;
                        mStProp.Show();
                        mStProp.BringToFront();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if(k.Substring(0,i)=="MON01")
                {
                    if(MyGlobal.mFrmMonitor==null)
                    {
                        frmMonitor mfrmmon = new frmMonitor();
                        MyGlobal.mFrmMonitor = mfrmmon;
                        mfrmmon.MdiParent = this;
                        mfrmmon.Show();
                        mfrmmon.BringToFront();

                    }
                }
                else if (k.Substring(0, i) == "INVENT01")
                {
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);
                    
                    if (IfExist == true)
                    {
                        
                        MessageBox.Show("Exista deja initializat inventarul cu numarul :" + mres[0].Trim());
                        mres = null;
                        return;
                    }

                    if(MyGlobal.mFrmInventoryInit==null)
                    {
                        frmInventoryInit minv = new frmInventoryInit();
                        MyGlobal.mFrmInventoryInit = minv;
                        minv.MdiParent = this;
                        minv.Show();
                        minv.BringToFront();
                    }
                    
                }
                else if (k.Substring(0, i) == "INVENT02")
                {
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);

                    if (IfExist == false)
                    {

                        MessageBox.Show("Nu exista Inventar Initializat");
                        mres = null;
                        return;
                    }
                    if (MyGlobal.mFrmInventoryTeam == null)
                    {
                        MyGlobal.mFrmInventoryTeam = new frmInventoryTeam();
                        MyGlobal.mFrmInventoryTeam.ID_INVENTAR = long.Parse(mres[0].Trim());
                        mres = null;
                        MyGlobal.mFrmInventoryTeam.MdiParent = this;
                        MyGlobal.mFrmInventoryTeam.Show();
                        MyGlobal.mFrmInventoryTeam.BringToFront();
                    }
                }
                else if (k.Substring(0, i) == "INVENT03")
                {
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);
                    if (IfExist == false)
                    {

                        MessageBox.Show("Nu exista Inventar Initializat");
                        mres = null;
                        return;
                    }
                    if(MyGlobal.mFrmInventoryAddCount==null)
                    {
                        this.Cursor = Cursors.No;
                        MyGlobal.mFrmInventoryAddCount = new frmInvenoryAddCount();
                        MyGlobal.mFrmInventoryAddCount.ID_INVENTORY = long.Parse(mres[0].Trim());
                        mres = null;
                        MyGlobal.mFrmInventoryAddCount.MdiParent = this;
                        MyGlobal.mFrmInventoryAddCount.Show();
                        MyGlobal.mFrmInventoryAddCount.BringToFront();
                        this.Cursor = Cursors.Default;
                    }
                }
                else if (k.Substring(0, i) == "INVENT04")
                {
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    //mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),112) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,112) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,112);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);
                    if (IfExist == false)
                    {

                        MessageBox.Show("Nu exista Inventar Initializat");
                        mres = null;
                        return;
                    }
                    if (MyGlobal.mFrmMonitorInventory == null)
                    {
                        this.Cursor = Cursors.No;
                        MyGlobal.mFrmMonitorInventory = new frmMonitorInventory();
                        try
                        {
                            MyGlobal.mFrmMonitorInventory.ID_INVENTORY = long.Parse(mres[0].Trim());
                        }
                        catch {
                            MessageBox.Show("Numarul de Inventar este invalid.");
                            MyGlobal.mFrmMonitorInventory = null;
                            return;
                        }
                        MyGlobal.mFrmMonitorInventory.MdiParent = this;
                        MyGlobal.mFrmMonitorInventory.BringToFront();
                        MyGlobal.mFrmMonitorInventory.Show();
                        this.Cursor = Cursors.Default;

                    }
                }
                else if (k.Substring(0, i) == "INVENT06")
                {


                    if (MyGlobal.mFrmInventorySetParam  == null)
                    {
                        MyGlobal.mFrmInventorySetParam = new frmViewInventorySetParam();
                        MyGlobal.mFrmInventorySetParam.MdiParent = this;
                        MyGlobal.mFrmInventorySetParam.BringToFront();
                        MyGlobal.mFrmInventorySetParam.Show();   
                    }
                }
                else if (k.Substring(0, i) == "INVENT07")
                {

                    if (MyGlobal.mFrmInventoryConfigBin == null)
                    {
                        MyGlobal.mFrmInventoryConfigBin = new frmInventoryConfigBin();
                        MyGlobal.mFrmInventoryConfigBin.MdiParent = this;
                        MyGlobal.mFrmInventoryConfigBin.BringToFront();
                        MyGlobal.mFrmInventoryConfigBin.Show();
                    }
                }
                else if (k.Substring(0, i) == "INVENT08")
                {
                   
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);

                    if (IfExist == false)
                    {

                        MessageBox.Show("Nu exista Inventar Initializat");
                        mres = null;
                        return;
                    }
                  
                    if(MyGlobal.mFrmInventoryGenerateList==null  )
                    {
                        MyGlobal.mFrmInventoryGenerateList = new frmInventoryGenerateList();
                        MyGlobal.mFrmInventoryGenerateList.MdiParent = this;
                        
                        try
                        {
                            MyGlobal.mFrmInventoryGenerateList.ID_INVENTAR =long.Parse(mres[0].Trim());  
                        }
                        catch
                        {
                            MessageBox.Show("Numar de Inventar este Invalid ", "ERROR");     
                        }
                        
                        MyGlobal.mFrmInventoryGenerateList.BringToFront();
                        MyGlobal.mFrmInventoryGenerateList.Show();   
                    }
                }
                else if (k.Substring(0, i) == "INVENT09")
                {
                    bool IfExist = false;
                    string mmm = "";
                    string[] mres = new string[1];

                    mmm = "select go_invent_main.ID FROM go_invent_main INNER JOIN go_sys_lock ON go_invent_main.ID = go_sys_lock.InventoryID AND CONVERT(VARCHAR,getdate(),101) between CONVERT(VARCHAR,go_invent_main.PeriodFrom,101) AND CONVERT(VARCHAR,go_invent_main.PeriodTo,101);";
                    IfExist = MyGlobal.IsForUpdate(mmm, 1, ref mres);

                    if (IfExist == false)
                    {

                        MessageBox.Show("Nu exista Inventar Initializat");
                        mres = null;
                        return;
                    }
                    if (MyGlobal.mFrmInventoryOperator == null)
                    {
                        MyGlobal.mFrmInventoryOperator = new frmInventoryOperator();
                        try
                        {
                            MyGlobal.mFrmInventoryOperator.ID_INVENTORY  = int.Parse(mres[0].Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Numar de Inventar este Invalid ", "ERROR");
                        }
                        MyGlobal.mFrmInventoryOperator.MdiParent = this;
                        MyGlobal.mFrmInventoryOperator.BringToFront();
                        MyGlobal.mFrmInventoryOperator.Show();   
                    }
                
                }
                else if (k.Substring(0, i) == "DISPC01")
                {
                    //MessageBox.Show("Nu exista task-uri inregistrate");
                    //this.Close();
                    this.Cursor = Cursors.No;
                    this.Refresh();
                    if (MyGlobal.mFrmDeliveryTransp == null)
                    {
                        MyGlobal.mFrmDeliveryTransp = new frmDeliveryTransp();
                        MyGlobal.mFrmDeliveryTransp.MdiParent = this;
                        MyGlobal.mFrmDeliveryTransp.BringToFront();
                        MyGlobal.mFrmDeliveryTransp.Show();
                    }
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                }
                else if (k.Substring(0, i) == "DISPC02")
                {
                    this.Cursor = Cursors.No;
                    this.Refresh();
                    if (MyGlobal.mFrmDeliveryStatus == null)
                    {
                        
                         
                        MyGlobal.mFrmDeliveryStatus = new frmDeliveryStatus();
                        MyGlobal.mFrmDeliveryStatus.MdiParent = this;
                        MyGlobal.mFrmDeliveryStatus.BringToFront();
                        MyGlobal.mFrmDeliveryStatus.Show();
                          
                    }
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                }
                else if (k.Substring(0, i) == "MOV02")
                {
                    this.Cursor = Cursors.No;
                    this.Refresh();
                    if (MyGlobal.mFrmRegisterMoveArticle == null)
                    {
                        MyGlobal.mFrmRegisterMoveArticle = new frmRegisterMoveArticle();
                        MyGlobal.mFrmRegisterMoveArticle.MdiParent = this;
                        MyGlobal.mFrmRegisterMoveArticle.IS_QTY_REGULATION = 0;
                        MyGlobal.mFrmRegisterMoveArticle.SetCtrl();
                        MyGlobal.mFrmRegisterMoveArticle.BringToFront();
                        MyGlobal.mFrmRegisterMoveArticle.Show();
                    }
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                }
                else if (k.Substring(0, i) == "RPMOV01")
                {
                    if (MyGlobal.mFrmReport == null)
                    {
                        MyGlobal.mFrmReport = new frmReport();
                        MyGlobal.mFrmReport.R_OPTION = 1;
                        MyGlobal.mFrmReport.MdiParent = this;
                        MyGlobal.mFrmReport.BringToFront();
                        MyGlobal.mFrmReport.Show();

                    }

                }
                else if (k.Substring(0, i) == "RPSTOCK01")
                {
                    this.Cursor = Cursors.No;
                    this.Refresh();
                    MyGlobal.mFrmReport = new frmReport();
                    MyGlobal.mFrmReport.R_OPTION = 2;
                    MyGlobal.mFrmReport.MdiParent = this;
                    MyGlobal.mFrmReport.BringToFront();
                    MyGlobal.mFrmReport.Show();
                    this.Cursor = Cursors.Default;
                    this.Refresh();

                }
                else if (k.Substring(0, i) == "QTYREGULATION")
                {
                    this.Cursor = Cursors.No;
                    this.Refresh();
                    if (MyGlobal.mFrmRegisterMoveArticle == null)
                    {
                        
                        MyGlobal.mFrmRegisterMoveArticle = new frmRegisterMoveArticle();
                        MyGlobal.mFrmRegisterMoveArticle.IS_QTY_REGULATION = 1;
                        MyGlobal.mFrmRegisterMoveArticle.SetCtrl();   
                        MyGlobal.mFrmRegisterMoveArticle.MdiParent = this;
                        MyGlobal.mFrmRegisterMoveArticle.BringToFront();
                        MyGlobal.mFrmRegisterMoveArticle.Show();
                    }
                    this.Cursor = Cursors.Default;
                    this.Refresh();


                }
            }   
            catch(Exception mex)
            {
                string h = "";
                h = mex.ToString();
                i = -1;   //invalid index
                MessageBox.Show("A aparut eroarea\r\n"+h,"SQL ENGINE ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);  


             
            }
            if (i < 0)
            {
             
                toolStripStatusLabel2.Text = "Functie Invalida";
            }
            else
            {
                toolStripStatusLabel2.Text = k.Substring(0, i);

            }
        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright 1991 GoNET Software Company\r\n    All right reserved \r\n    www.gonetsoftware.com\r\n\r\nVersion : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), "Versiunea Curenta");
        }

    }
}