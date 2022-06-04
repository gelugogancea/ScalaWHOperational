using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;





namespace GoWHMgmAdmin
{
    public partial class frmViewInventory : Form
    {
        public long ID_INVENTORY = 0;
        private bool GRID_IS_ENTER = false;
        private bool GRID_IS_FOCUS = false;
        public string CK_PASSWD = "";
        public frmViewInventory()
        {
            InitializeComponent();
        }

        private void frmViewInventory_Resize(object sender, EventArgs e)
        {
            gridControl1.Size = new Size(this.Size.Width - 30, this.Size.Height - 150);
            gridControl1.Location = new Point(9, 100);
        }

        private void frmViewInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            CK_PASSWD = "";
            try
            {
                MyGlobal.mFrmViewInventory  = null;
            }
            catch { }
        }

        private void frmViewInventory_Load(object sender, EventArgs e)
        {
            rbCountArticle.Checked = true;
            rbExpPrint.Checked = true;

            DevExpress.XtraGrid.StyleFormatCondition cd = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Less, gridView1.Columns[8], null, "0");
            cd.Appearance.ForeColor = Color.Red;
            cd.ApplyToRow = true;
            gridView1.FormatConditions.Add(cd);

            DevExpress.XtraGrid.StyleFormatCondition cz = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Greater, gridView1.Columns[8], null, "0");
            cz.Appearance.ForeColor = Color.Blue;
            cz.ApplyToRow = true;
            gridView1.FormatConditions.Add(cz);

            DevExpress.XtraGrid.StyleFormatCondition gz = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns[6], null, "DA");
            gz.Appearance.ForeColor = Color.Blue;
            gz.ApplyToRow = true;
            gridView2.FormatConditions.Add(gz);

            gridView1.BestFitColumns();
            gridView2.BestFitColumns();
            LoadDeliveryOrder("", 0);
        }
        public void LoadDeliveryOrder(string SrchItem, int myScope)
        {
            string mq = "";
            string LastArticle = "";
            string LastWH = "";
            decimal inventqty = 0;
            decimal scriptqty = 0;
            decimal cplus = 0;
            decimal cminus = 0;
            decimal qtydiff = 0;
            decimal valdiff = 0;
            decimal valcmp = 0;
            decimal cqty = 0;
            decimal countno = 0;

            dataSetInventory.tblWork.Clear();
            dataSetInventory.tblWorkD.Clear();
            dataSetInventory.Clear();
            

            this.Cursor = Cursors.WaitCursor;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (myScope == 0)
            {

                if (SrchItem.Trim() == "")
                {
                    /*
                    mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND " +
                    "go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "LEFT JOIN go_article_masterdata ON  go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                     */
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock,"+ 
                        "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' "+
                        "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END,"+
                        "go_invent_work.InventReportQty, go_invent_import.StockBalance,"+ 
                        "go_invent_work.CompensPlus, go_invent_work.CompensMinus,"+
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty,"+
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost,"+
                        //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty,"+
                        //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost,"+
                        "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode,"+
                        "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                        "FROM go_invent_import "+
                        "INNER JOIN go_invent_work ON go_invent_import.InventoryID="+ID_INVENTORY.ToString()+" AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND "+
                        "go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE AND go_invent_work.InventReportQty<>0 "+
                        "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock "+
                        "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID "+
                        "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID "+
                        "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode "+
                        "order by go_invent_work.KeyArticleStock;";
                }
                else
                {
                    /*
                    mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND " +
                    "go_invent_work.KeyArticleStock='"+SrchItem.Trim()+"' AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "LEFT JOIN go_article_masterdata ON  go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                     */
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                        "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                        "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                        "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                        "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                        //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                        //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                        "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                        "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                        "FROM go_invent_import " +
                        "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                        "go_invent_import.KeyArticleStockCode='"+SrchItem.Trim()+"' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE AND go_invent_work.InventReportQty<>0 " +
                        "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                        "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                        "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                        "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                        "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 1) 
            {
                /*
                mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND " +
                    "go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "LEFT JOIN go_article_masterdata ON  go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                 */
                if (SrchItem.Trim() == "")
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                    "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                    "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                    "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                    "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_import " +
                    "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                    "go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE AND go_invent_work.InventReportQty=0 " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                    "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                    "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
                else
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                    "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                    "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                    "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                    "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_import " +
                    "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                    "go_invent_import.KeyArticleStockCode='" + SrchItem.Trim() + "' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE AND go_invent_work.InventReportQty=0 " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                    "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                    "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 2) 
            {
                if (SrchItem.Trim() == "")
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                        "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                        "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                        "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                        "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                        //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                        //"go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                        "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                        "FROM go_invent_import " +
                        "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                        "(go_invent_work.CompensPlus<>0 OR go_invent_work.CompensMinus<>0) AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                        "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                        "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                        "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                        "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                        "order by go_invent_work.KeyArticleStock;";   
                }
                else
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                    "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                    "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                    "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty,"+
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost,"+
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                    "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_import " +
                    "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                    "(go_invent_work.CompensPlus<>0 OR go_invent_work.CompensMinus<>0) AND go_invent_import.KeyArticleStockCode='" + SrchItem.Trim() + "' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                    "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                    "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 3)
            {
                if (SrchItem.Trim() == "")
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                        "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                        "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                        "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                        "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                        //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                        //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                        "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                        "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                        "FROM go_invent_import " +
                        "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                        "go_invent_work.CompensPlus=0 AND go_invent_work.CompensMinus=0 AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                        "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                        "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                        "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                        "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                        "order by go_invent_work.KeyArticleStock;";
                }
                else
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                    "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                    "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                    "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                    "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_import " +
                    "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                    "go_invent_work.CompensPlus=0 AND go_invent_work.CompensMinus=0 AND go_invent_import.KeyArticleStockCode='" + SrchItem.Trim() + "' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                    "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                    "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 4)
            {
                if(SrchItem.Trim()=="")
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                        "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                        "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                        "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                        "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                        "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                        //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                        //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                        "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                        "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                        "FROM go_invent_import " +
                        "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                        "go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                        "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                        "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                        "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                        "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                        "order by go_invent_work.KeyArticleStock;";
                }
                else
                {
                    mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                    "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                    "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                    "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                    "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_import " +
                    "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                    "go_invent_import.KeyArticleStockCode='" + SrchItem.Trim() + "' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                    "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                    "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 5)
            {
                if (SrchItem.Trim() == "")
                {
                    mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2,go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus,go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty,(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost,go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main " +
                    "INNER JOIN go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY " +
                    "AND go_invent_work.InventReportQty=0 " +
                    "INNER JOIN go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode " +
                    "INNER JOIN go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK " +
                    "INNER JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                    "INNER JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                }
                else
                {
                    mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2,go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus,go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty,(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost,go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                   "FROM go_invent_main " +
                   "INNER JOIN go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY " +
                   "AND go_invent_work.InventReportQty=0 " +
                   "INNER JOIN go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode " +
                   "INNER JOIN go_invent_work_d ON go_invent_work.KeyArticleStock='" + SrchItem.Trim() + "' AND go_invent_work.ID = go_invent_work_d.ID_WORK " +
                   "INNER JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                   "INNER JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                   "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                   "order by go_invent_work.KeyArticleStock;";
                }
            }
            else if (myScope == 6)
            {
                mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                "FROM go_invent_import " +
                "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                "go_invent_import.KeyArticleStockCode LIKE '" + SrchItem.Trim() + "%' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                "order by go_invent_work.KeyArticleStock;";
            }
            else if (myScope == 7)
            {
                mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                "FROM go_invent_import " +
                "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                "go_invent_import.KeyArticleStockCode LIKE '%" + SrchItem.Trim() + "%' AND go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                "LEFT JOIN go_article_masterdata ON go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                "order by go_invent_work.KeyArticleStock;";
            }
            else if (myScope == 8)
            {
                /*
                mq="SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID " +
                    "AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "INNER JOIN go_article_masterdata ON (go_article_masterdata.Description1 like '" + SrchItem.Trim() + "%' OR go_article_masterdata.Description2 like '" + SrchItem.Trim() + "%') " +
                    "AND go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                */
                mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                "FROM go_invent_import " +
                "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                "go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                "INNER JOIN go_article_masterdata ON (go_article_masterdata.Description1 like '" + SrchItem.Trim() + "%' OR go_article_masterdata.Description2 like '" + SrchItem.Trim() + "%') "+
                "AND go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                "order by go_invent_work.KeyArticleStock;";
            }
            else if (myScope == 9)
            {
                /*
                mq="SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID " +
                    "AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "INNER JOIN go_article_masterdata ON (go_article_masterdata.Description1 like '%" + SrchItem.Trim() + "%' OR go_article_masterdata.Description2 like '" + SrchItem.Trim() + "%') "+
                    "AND go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
                 */
                mq = "SELECT go_invent_work.ID, go_invent_work.WHCODE, go_invent_work.KeyArticleStock," +
                "CASE WHEN go_article_masterdata.Description1+' '+go_article_masterdata.Description2 IS NULL THEN 'NEIMPORTAT IN WMS' " +
                "ELSE go_article_masterdata.Description1+' '+go_article_masterdata.Description2 END," +
                "go_invent_work.InventReportQty, go_invent_import.StockBalance," +
                "go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo,go_locator_def.LocatorSymbol,go_area_def.AreaCode," +
                "go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                "FROM go_invent_import " +
                "INNER JOIN go_invent_work ON go_invent_import.InventoryID=" + ID_INVENTORY.ToString() + " AND go_invent_import.InventoryID = go_invent_work.ID_INVENTORY AND " +
                "go_invent_import.KeyArticleStockCode = go_invent_work.KeyArticleStock AND go_invent_import.WH = go_invent_work.WHCODE " +
                "INNER JOIN go_article_masterdata ON (go_article_masterdata.Description1 like '%" + SrchItem.Trim() + "%' OR go_article_masterdata.Description2 like '%" + SrchItem.Trim() + "%') " +
                "AND go_article_masterdata.StockCode=go_invent_work.KeyArticleStock " +
                "LEFT JOIN go_invent_work_d ON go_invent_work_d.ID_WORK=go_invent_work.ID " +
                "LEFT JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                "LEFT JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                "order by go_invent_work.KeyArticleStock;";

            }
            else if (myScope == 10)
            {
                mq="SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_article_masterdata.Description1+' '+go_article_masterdata.Description2," +
                    "go_invent_work_d.CountQty, go_invent_import.StockBalance,go_invent_work.CompensPlus, go_invent_work.CompensMinus," +
                    "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                        "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty," +
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost," +
                    "go_invent_import.AvgCost,go_invent_work_d.CountQty,go_invent_work_d.CountNo," +
                    "go_locator_def.LocatorSymbol, go_area_def.AreaCode,go_invent_work_d.ListNo,go_invent_work_d.OperatorCode,go_invent_work_d.ThisQTYOK " +
                    "FROM go_invent_main INNER JOIN " +
                    "go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY INNER JOIN " +
                    "go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID " +
                    "AND go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode INNER JOIN " +
                    "go_invent_work_d ON go_invent_work_d.ListNo='" + SrchItem.Trim() + "' AND go_invent_work_d.ThisQTYOK=1 AND go_invent_work.ID = go_invent_work_d.ID_WORK INNER JOIN " +
                    "go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID INNER JOIN " +
                    "go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID AND go_invent_import.WH = go_area_def.WHCode " +
                    "LEFT JOIN go_article_masterdata ON  go_article_masterdata.StockCode=go_invent_import.KeyArticleStockCode " +
                    "order by go_invent_work.KeyArticleStock;";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            gridControl1.BeginUpdate();
            try
            {
                while (dataread.Read())
                {
                    if (LastArticle != MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") ||
                        (LastArticle == MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") && LastWH != MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'")))
                    {


                        try
                        {
                            inventqty=decimal.Parse(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                        }
                        catch { inventqty = 0; }
                        try
                        {
                            scriptqty = decimal.Parse(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                        }
                        catch
                        { scriptqty = 0; }
                        try
                        {
                            cplus = decimal.Parse(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                        }
                        catch { cplus = 0; }
                        try
                        {
                            cminus = decimal.Parse(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                        }
                        catch { cminus = 0; }
                        try
                        {
                            qtydiff = decimal.Parse(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'")); 
                        }
                        catch { qtydiff = 0; }
                        try
                        {
                            valdiff = decimal.Parse(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'")); 
                        }
                        catch { valdiff = 0; }
                        try
                        {
                            valcmp = decimal.Parse(MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'")); 
                        }
                        catch { valcmp = 0; }
                        /*
                        dataSetInventory.tblWork.Rows.Add(new object[]{MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                            });
                          */
                        dataSetInventory.tblWork.Rows.Add(new object[]{MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                            MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                                                            String.Format("{0:0.##}", inventqty.ToString()),
                                                            String.Format("{0:0.##}", scriptqty.ToString()),
                                                            String.Format("{0:0.##}", cplus.ToString()),
                                                            String.Format("{0:0.##}", cminus.ToString()),
                                                            String.Format("{0:0.##}", qtydiff.ToString()),
                                                            String.Format("{0:0.##}", valdiff.ToString()),
                                                            String.Format("{0:0.##}", valcmp.ToString())
                                                            });
                        //String.Format("{0:0.##}", valcmp.ToString()); 
                    
                        
                    }
                    //if (myScope != 1)
                    //{
                                        try
                                        {
                                            cqty=decimal.Parse(MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'"));
                                        }
                                        catch { cqty=0;}
                                        try{
                                            countno=decimal.Parse(MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"));
                                        }
                                        catch{countno=0;}
                        if (MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'") == "0" || MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'") == "")
                        {
                            dataSetInventory.tblWorkD.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),  
                                                                        String.Format("{0:0.##}", cqty.ToString()),
                                                                         String.Format("{0:0.##}", countno.ToString()),
                                                                         MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"),
                                                                         "NU", });
                        }
                        else
                        {
                            dataSetInventory.tblWorkD.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),  
                                                                        String.Format("{0:0.##}", cqty.ToString()),
                                                                         String.Format("{0:0.##}", countno.ToString()),
                                                                         MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"),
                                                                         "DA", });
                        }
                    //}
                    LastArticle = MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'");
                    LastWH = MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'");
                }
        
            }
            catch (Exception mk)
            {
                string k;
                k = mk.ToString();
            }
            gridControl1.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            string mq = "";
            long cellValueID = 0;
            string cellValue = "";
            GridView myView = (GridView)sender;
            decimal alreadyval = 0;
            
            if (GRID_IS_FOCUS == true)
            {
                return;            
            }
            if (GRID_IS_ENTER == true)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                try
                {
                    cellValueID = long.Parse(row[0].ToString());
                }
                catch
                {
                    MessageBox.Show("SQL ERR\r\nInvalid ID_REC", "");
                    return;
                }
                if (e.Column.Caption == "C   +")
                {

                    cellValue = e.Value.ToString();
                    try
                    {
                        alreadyval = decimal.Parse(row[7].ToString());
                    }
                    catch { alreadyval = 0; }
                    if (alreadyval != 0)
                    {
                        //if (MessageBox.Show("Exista deja o compensare cu Minus pentru acest articol\r\nVrei sa continui ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        //{
                        GRID_IS_ENTER = false;
                        GRID_IS_FOCUS = false;
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[6], "0");
                        //MessageBox.Show("Exista deja o compensare cu Minus pentru acest articol", "", MessageBoxButtons.OK);    

                        return;
                        //}
                    }

                    mq = "UPDATE go_invent_work SET CompensPlus=" + cellValue.ToString() + " where ID=" + cellValueID.ToString() + ";";


                }
                else if (e.Column.Caption == "C   -")
                {
                    cellValue = e.Value.ToString();

                    try
                    {
                        alreadyval = decimal.Parse(row[6].ToString());
                    }
                    catch { alreadyval = 0; }

                    if (alreadyval != 0)
                    {
                        //if (MessageBox.Show("Exista deja o compensare cu Plus pentru acest articol\r\nVrei sa continui ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        //{
                        GRID_IS_ENTER = false;
                        GRID_IS_FOCUS = false;
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[7], "0");
                        //MessageBox.Show("Exista deja o compensare cu Plus pentru acest articol.", "", MessageBoxButtons.OK);

                        return;
                        //}
                    }
                    mq = "UPDATE go_invent_work SET CompensMinus=" + cellValue.ToString() + " where ID=" + cellValueID.ToString() + ";";

                }

                if (SaveData(mq) < 0)
                {
                    //MessageBox.Show("SQL ERR\r\nNu pot salva date.");      
                }
                else
                {
                    try
                    {
                        //SetCellOnGrid(cellValueID, e.RowHandle, IsAccessible , myView);
                    }
                    catch
                    {
                        GC.Collect();
                    }
                }
            }
            GRID_IS_ENTER = false;
            GRID_IS_FOCUS = false;
        }
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gridView1.IsGroupRow(e.FocusedRowHandle))
            {
                bool expanded = gridView1.GetRowExpanded(e.FocusedRowHandle);
                gridView1.SetRowExpanded(e.FocusedRowHandle, !expanded);
            }
        }


        private void gridView1_ShownEditor(object sender, System.EventArgs e)
        {
            double cellValue = 0;
            GridView view = sender as GridView;
            System.Data.DataRow row = view.GetDataRow(gridView1.FocusedRowHandle);
            if (view.FocusedColumn.FieldName == "CompPlus") // && view.ActiveEditor is LookUpEdit)
            {
                //gridView1.SetRowCellValue(row., gridView1.Columns[6], "0");
                try
                {
                    cellValue = double.Parse(row[6].ToString());
                }
                catch { }
                if (cellValue == 0)
                {
                    gridView1.EditingValue = "0";
                }
                else
                {
                    gridView1.EditingValue = String.Format("{0:0.###}", cellValue.ToString());
                }

            }
            else
            {
                try
                {
                    cellValue = double.Parse(row[7].ToString());
                }
                catch { }
                if (cellValue == 0)
                {
                    gridView1.EditingValue = "0";
                }
                else
                {
                    gridView1.EditingValue = String.Format("{0:0.###}", cellValue.ToString()); 
                }
            }

        }
        private void SetCellOnGrid(long idrow,int mRowHnd,decimal  IsZeroQty,GridView mView)
        {
            string mq = "";
            long x = 0;
            this.Cursor = Cursors.WaitCursor;
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (IsZeroQty != 0)
            {
                mq = "SELECT go_invent_work.ID,go_area_def.WHCode, go_invent_work.KeyArticleStock,go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus,go_invent_work.CompensMinus," +
                "go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty," +
                "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost," +
                    //"go_invent_work.CompensMinus,go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus) as DiffQty,"+
                    //"(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+go_invent_work.CompensMinus))*go_invent_import.AvgCost as DiffAvgCost,"+
                "go_invent_import.AvgCost " +
                "FROM go_invent_main INNER JOIN go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " " +
                "AND go_invent_main.ID = go_invent_work.ID_INVENTORY " +
                "INNER JOIN go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID " +
                "AND go_invent_work.ID=" + idrow.ToString() + " and go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode " +
                "INNER JOIN go_invent_work_d ON go_invent_work.ID = go_invent_work_d.ID_WORK " +
                "INNER JOIN go_locator_def ON go_invent_work_d.ID_3DLOC = go_locator_def.ID " +
                "INNER JOIN go_area_def ON go_locator_def.ID_STORAGE_AREA = go_area_def.ID " +
                "AND go_invent_import.WH = go_area_def.WHCode order by go_invent_work.KeyArticleStock;";
            }
            else
            {
                mq="SELECT go_invent_work.ID,go_invent_work.WHCODE, go_invent_work.KeyArticleStock,go_invent_work.InventReportQty, go_invent_import.StockBalance,go_invent_work.CompensPlus,go_invent_work.CompensMinus,go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)) as DiffQty,"+
                   "(go_invent_work.InventReportQty-go_invent_import.StockBalance-(go_invent_work.CompensPlus+(0-go_invent_work.CompensMinus)))*go_invent_import.AvgCost as DiffAvgCost,go_invent_import.AvgCost "+
                    "FROM go_invent_main INNER JOIN go_invent_work ON go_invent_main.ID=" + ID_INVENTORY.ToString() + " AND go_invent_main.ID = go_invent_work.ID_INVENTORY "+
                    "INNER JOIN go_invent_import ON go_invent_main.ID = go_invent_import.InventoryID AND go_invent_work.ID=" + idrow.ToString() + " and go_invent_work.KeyArticleStock = go_invent_import.KeyArticleStockCode "+
                    "order by go_invent_work.KeyArticleStock;";
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            mView.BeginUpdate();
            GRID_IS_FOCUS = true;
            while (dataread.Read())
            {
                mView.SetRowCellValue(mRowHnd, mView.Columns[6], MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                mView.SetRowCellValue(mRowHnd, mView.Columns[7], MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                mView.SetRowCellValue(mRowHnd, mView.Columns[8], MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                mView.SetRowCellValue(mRowHnd, mView.Columns[9], MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));

                /*
                MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"));
                */
                x++;
            }
            mView.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {

                GRID_IS_ENTER = true;
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string cellValueID = row[0].ToString();
                string cplus = row[4].ToString();
                string cminus = row[5].ToString();
                //MessageBox.Show(cellValueID + " - " + fieldName);
            }
        }
        
        private void gridView1_CustomRowCellEdit(object sender,CustomRowCellEditEventArgs e)
        {
            
            
            
            GridView gv = sender as GridView;
            
            string fieldName = gv.GetRowCellValue(e.RowHandle, gv.Columns[5]).ToString();
            try
            {
                fieldName = gv.GetFocusedDisplayText();
            }
            catch { }
            /*
            switch (fieldName)
            {
                case "CompensPlus":
                    //e.RepositoryItem = repositoryItemSpinEdit1;
                    MessageBox.Show("C+");
                    break;
                case "CompensMinus":
                    //e.RepositoryItem = repositoryItemComboBox1;
                    MessageBox.Show("C+");
                    break;
                
            }
            */
        }
        
        private void gridView1_ValidateRow(object sender,DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) 
        {

            //CellValueChangedEventArgs erg=new CellValueChangedEventArgs(e.RowHandle,
            string mq = "";
            long cellValueID = 0;
            string cellValue = "";
            GridView myView = (GridView)sender;
            decimal alreadyval = 0;
            decimal IsZero = 0;
            

            System.Data.DataRow row = myView.GetDataRow(gridView1.FocusedRowHandle);
            try
            {
                cellValueID = long.Parse(row[0].ToString());
            }
            catch
            {
                MessageBox.Show("SQL ERR\r\nInvalid ID_REC", "");
                return;
            }
            try
            {
                IsZero = decimal.Parse(row[4].ToString());
            }
            catch
            {
                IsZero = -1; 
            }
            if (myView.FocusedColumn.FieldName == "CompPlus") // && view.ActiveEditor is LookUpEdit)
            {
                cellValue = row[6].ToString();
                
                try
                {
                    alreadyval = decimal.Parse(row[7].ToString());
                }
                catch { alreadyval = 0; }
                if (alreadyval != 0)
                {
                    
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[6], "0");
                    return;
                }

                mq = "UPDATE go_invent_work SET CompensPlus=" + cellValue.ToString() + " where ID=" + cellValueID.ToString() + ";";

            }
            else
            {
                cellValue = row[7].ToString();
                try
                {
                    alreadyval = decimal.Parse(row[6].ToString());
                }
                catch { alreadyval = 0; }

                if (alreadyval != 0)
                {
                     gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[7], "0");
                     return;
                }
                mq = "UPDATE go_invent_work SET CompensMinus=" + cellValue.ToString() + " where ID=" + cellValueID.ToString() + ";";

            }
            this.Cursor = Cursors.WaitCursor ;
            if (SaveData(mq) < 0)
            {
                //MessageBox.Show("SQL ERR\r\nNu pot salva date.");      
            }
            else
            {
                try
                {
                    SetCellOnGrid(cellValueID, e.RowHandle,IsZero, myView);
                }
                catch
                {
                    GC.Collect();
                }
            }
            this.Cursor = Cursors.Default;
            //e.Valid = true;
            /*
            GridView view = gridView1;
            bool cpluserr = false;
            bool cminuserr = false;
            decimal compplus = 0;
            decimal compminus = 0;
           
            GridColumn column1 = view.Columns[5];
            GridColumn column2 = view.Columns[6];

            try
            {
                compplus = (decimal)view.GetRowCellValue(e.RowHandle, column1);
            }
            catch
            {
                cpluserr = true;
                goto MY_END;
            }
            try
            {
                compminus = (decimal)view.GetRowCellValue(e.RowHandle, column2);
            }
            catch
            {
                cminuserr = false;
                goto MY_END;
            }
MY_END:            
            if(cpluserr==true)
            {
                e.Valid = false;
                view.SetColumnError(column1, "C+ este numeric");
            }
            if(cminuserr==true)
            {
                e.Valid=false;
                view.SetColumnError(column2, "C- este numeric");
            }
            if (compplus >0 && compminus >0)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                view.SetColumnError(column1, "Este deja ");
                view.SetColumnError(column2, "The value must be greater than StartTime");
            }
            */
        }
        private int SaveData(string mq)
        {

            int ret = 0;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.CommandType = System.Data.CommandType.Text;

            mcmd.CommandText = mq;
            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch (Exception emsg)
            {
                MessageBox.Show("ERROR : " + emsg.Message.Trim(), "GoWHManagementAdmin");
                ret = -1;
                goto MYEND;
            }
        MYEND:
            mcmd = null;

            return ret;
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            string s = "";
            s = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (rbExpPrint.Checked == true)
            {
                //gridControl1.Print();
                gridControl1.ShowPrintPreview();
                //MessageBox.Show("Operatie executata cu succes.");
            }
            else if(rbExpXls.Checked==true)
            {

                //gridControl1.ExportToXls(Application.StartupPath+"\\Inventory_"+ID_INVENTORY.ToString()+"_"+DateTime.Now.TimeOfDay.ToString());
                //gridControl1.ExportToXls(Application.StartupPath + "\\Inventory_" + ID_INVENTORY.ToString()+"_"+DateTime.Now.Second.ToString()+".xls");
                gridControl1.ExportToXls(s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".xls");
                MessageBox.Show("Operatie executata cu succes in folder\r\n" + s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".xls");
            }
            else if(rbExpPDF.Checked==true)
            {
                gridControl1.ExportToPdf(s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".pdf");
                MessageBox.Show("Operatie executata cu succes in folder\r\n" + s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".pdf");
            }
            else if (rbExpHTML.Checked == true)
            {
                gridControl1.ExportToHtml(s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".html");
                MessageBox.Show("Operatie executata cu succes in folder\r\n" + s + "\\Inventory_" + ID_INVENTORY.ToString() + "_" + DateTime.Now.Second.ToString() + ".html");
            }
            
        }

        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (CmdCauta.Text == "Inchid Inventar")
            {
                if (ID_INVENTORY <= 0)
                {
                    MessageBox.Show("ERROR\r\nID Inventar invalid");
                    return;
                }
                CkCloseInventory.Checked = false;
                CloseInventory(CryptorEngine.Encrypt(CK_PASSWD.Trim(), true));
                
            }
            if(rbCountArticle.Checked==true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 0);
            }
            else if (rbUnCountArticle.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 1);
            }
            else if (rbArticleCompensation.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 2);
            }
            else if(rbArticleUnCompensation.Checked==true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 3);
            }
            else if (rbAllArticle.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 4);
            }
            else if(rbUnValidateArticle.Checked==true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 5);
            }
            else if (rbArticleCodeLikeFirst.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 6);
            }
            else if (rbArticleCodeLikeAll.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 7);
            }
            else if (rbArticleNameLikeFirst.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 8);
            }
            else if (rbArticleNameLikeAll.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 9);
            }
            else if (rbListNo.Checked == true)
            {
                LoadDeliveryOrder(txtSrch.Text.Trim(), 10);
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rbCountArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCountArticle.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbArticleCompensation.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbUnCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbUnCountArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnCountArticle.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbArticleCompensation.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbValidateArticle.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleCompensation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleCompensation.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleUnCompensation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleUnCompensation.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbValidateArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValidateArticle.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbUnValidateArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnValidateArticle.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleCodeLikeFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleCodeLikeFirst.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleCodeLikeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleCodeLikeAll.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeFirst.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleNameLikeFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleNameLikeFirst.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeFirst.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleCodeLikeAll.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbArticleNameLikeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticleNameLikeAll.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeFirst.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbArticleCodeLikeAll.Checked = false;
                rbListNo.Checked = false;
            }
        }

        private void rbListNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbListNo.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeFirst.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbUnCountArticle.Checked = false;
                rbArticleCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbAllArticle.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbArticleCodeLikeAll.Checked = false;
                rbArticleNameLikeAll.Checked = false;
            }
        }

        private void CkCloseInventory_CheckedChanged(object sender, EventArgs e)
        {
            if (CkCloseInventory.Checked == true)
            {
                CmdCauta.Text = "Inchid Inventar";
                frmCkPasswd mfrm = new frmCkPasswd();
                mfrm.Show();
                mfrm.BringToFront();
            }
            else
            {
                CmdCauta.Text = "Cauta";
            }
        }

        private void rbAllArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllArticle.Checked == true)
            {
                txtSrch.Text = "";
                rbArticleCodeLikeAll.Checked = false;
                rbArticleCodeLikeFirst.Checked = false;
                rbArticleCompensation.Checked = false;
                rbArticleUnCompensation.Checked = false;
                rbCountArticle.Checked = false;
                rbUnValidateArticle.Checked = false;
                rbValidateArticle.Checked = false;
                rbArticleNameLikeAll.Checked = false;
                rbArticleNameLikeFirst.Checked = false;
                rbListNo.Checked = false;
            }
        }
        private long CloseInventory(string mpass)
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

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("FinishInventoryQty");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDINVENTORY", SqlDbType.BigInt));
            mcmd.Parameters["@IDINVENTORY"].Value = ID_INVENTORY;
                        
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CKPASSWD", SqlDbType.NVarChar, mpass.Length));
            mcmd.Parameters["@CKPASSWD"].Value = mpass;
                        
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
                MyErr = (int)mcmd.Parameters["@MERR"].Value;
            }
            catch { MyErr = -100; }

            if (MyErr == -100)
            {
                MessageBox.Show("SQL ERROR\r\nNu se pot salva date", "");
            }
            else if (MyErr == -1)
            {
                MessageBox.Show("SQL ERROR\r\nTranzactia nu s-a incheiat cu succes");
            }
            else if (MyErr == -2)
            {
                MessageBox.Show("Nu regasesc SYS_LOCK pentru Inventar Nr : " + ID_INVENTORY.ToString());
            }
            else if (MyErr == -3)
            {
                MessageBox.Show("Inventar Nr " +ID_INVENTORY.ToString() +" este deja Inchis");
            }
            else if (MyErr == -4)
            {
                MessageBox.Show("Parola pentru inchiderea inventarului este gresita\r\nsau nu apartine inventarului cu numarul : " + ID_INVENTORY.ToString());
            }
            else if (MyErr == -6)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work");
            }
            else if (MyErr == -7)
            {
                MessageBox.Show("SQL CRITICAL ERR\r\nInvalid ID pentru go_invent work_d");
            }
            else if (MyErr == 0)
            {
                mRegistry mreg = new mRegistry();
                if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "INVENT_CL_COUNT_" + ID_INVENTORY.ToString(), "1") == false)
                {
                    MessageBox.Show("Nu pot salva CloseCounting in registry.", "GoWHManagamenetAdmin");

                }
                mreg = null;
                MessageBox.Show("Datele au fost salvate cu succes\r\nProcedura de Inventar a fost inchisa cu succes");
            }
            dataread.Close();
            mcmd = null;
            return MyErr;
        }

    }
}