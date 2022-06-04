using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;


namespace GoWHMgmAdmin
{
    public partial class frmMonitor : Form
    {
        private int DELIVERY_INIT_STATUS = 0;
        private int DELIVERY_INTERMEDIATE_STATUS = 0;
        private int DELIVERY_START_STATUS = 0;
        private int DELIVERY_FINISH_STATUS = 0;
        private int RECEIPT_INIT_STATUS = 0;
        private int RECEIPT_START_STATUS = 0;
        private int RECEIPT_FINISH_STATUS = 0;
        private int OPER_TYPE = 0;
        public frmMonitor()
        {
            InitializeComponent();
            this.gridView2.KeyDown += new KeyEventHandler(gridView2_KeyDown);
            this.gridView1.KeyDown += new KeyEventHandler(gridView1_KeyDown);
        }
        public void LoadDeliveryOrder(string SrchItem,int myScope)
        {
            string mq = "";
            string LastOrder = "";
            int MyCountRemain=0;
            string MyUser="";
            System.Data.SqlClient.SqlDataReader dataread=null;
            dataSetMonitor.Clear();
            this.Cursor = Cursors.WaitCursor;
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (myScope == 0)
            {
                /*
                mq = "SELECT     iScalaDB.dbo.OR010100.OR01001, iScalaDB.dbo.OR010100.OR01003, iScalaDB.dbo.SL010100.SL01002, t.MyCount, z.RemainQty, "+
                        "iScalaDB.dbo.OR010100.OR01056, iScalaDB.dbo.OR010100.OR01017, z.mUser, iScalaDB.dbo.OR010100.OR01050, "+
                        "iScalaDB.dbo.OR010100.OR01015, iScalaDB.dbo.OR010100.OR01091, "+
                        "CASE [iScalaDB].[dbo].[OR010100].OR01009 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 ELSE '' END AS Expr1, "+
                        "CASE [iScalaDB].[dbo].[OR010100].OR01010 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 ELSE '' END AS Expr2, "+
                        "iScalaDB.dbo.OR030100.OR03002, iScalaDB.dbo.OR030100.OR03005, ISNULL(iScalaDB.dbo.OR030100.OR03006, N'') "+
                        "+ ISNULL(iScalaDB.dbo.OR030100.OR03007, N'') AS DescriptioArticle, iScalaDB.dbo.OR030100.OR03011, iScalaDB.dbo.OR030100.OR03033, "+
                        "ISNULL(go_article_stock.QtyOUT, 0) AS DelQty, ISNULL(iScalaDB.dbo.OR030100.OR03012,0) - ISNULL(go_article_stock.QtyOUT,0) AS DiffQty,"+ 
                        "go_article_masterdata.UnitCodeStoc, go_article_masterdata.GoWHClass, iScalaDB.dbo.OR030100.OR03046 "+
                        "FROM [iScalaDB].[dbo].OR010100 with(NOLOCK) "+
                        " join [iScalaDB].[dbo].OR030100 with(NOLOCK) on OR01001=OR03001 and OR01091 BETWEEN "+ DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() +
                        " join [iScalaDB].[dbo].SL010100 with(NOLOCK) on OR01003=SL01001 "+
                        "left join GoWH.dbo.go_article_stock on OR03001=GoWH.dbo.go_article_stock.PC03001Ref COLLATe Romanian_BIN and "+
                        " OR03002=GoWH.dbo.go_article_stock.PC03003Ref COLLATe Romanian_BIN "+	
                        "left join 	GoWH.dbo.go_article_masterdata on OR03005= "+
                        "GoWH.dbo.go_article_masterdata.StockCode COLLATE Romanian_BIN "+	
                        "join (select COUNT(OR03005) as MyCount,OR03001 as OrderNo "+
                        "from [iScalaDB].[dbo].OR030100 with(NOLOCK) group by OR03001) t "+
                        "on OR01001=t.OrderNo "+
                        "left join (select COUNT(QtyOut)as RemainQty,PC03001Ref ,PC03003Ref,mUser "+
                        "from GoWH.dbo.go_article_stock with(NOLOCK) group by PC03001Ref,PC03003Ref,mUser) z "+
                        "on OR03001=z.PC03001Ref COLLATe Romanian_BIN and OR03002=z.PC03003Ref COLLATe Romanian_BIN;";
                    */
                if (this.CkDescarcaStoc.Checked == false)
                {
                    mq = "select [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                   "[iScalaDB].[dbo].[SL010100].SL01002,t.MyCount,z.RemainQty," +
                   "CASE WHEN SUM(ISNULL(GoWH.dbo.go_article_stock.QtyOUT,0))>0 THEN " +
                   "(CASE WHEN iScalaDB.dbo.OR030100.OR03012-SUM(ISNULL(GoWH.dbo.go_article_stock.QtyOUT,0))=0 THEN 0 " +
                   " ELSE COUNT(1) END) " +
                   " ELSE 0 END  DiffItems," +
                   "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017,z.mUser," +
                   "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                   "[iScalaDB].[dbo].[OR010100].OR01091," +
                   "CASE [iScalaDB].[dbo].[OR010100].OR01009 " +
                   "    WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 " +
                   "    ELSE '' END," +
                   "CASE [iScalaDB].[dbo].[OR010100].OR01010 " +
                   "    WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 " +
                   "    ELSE '' END," +
                   "iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005," +
                   "ISNULL(OR030100.OR03006,'')+ISNULL(iScalaDB.dbo.OR030100.OR03007,'') as DescriptioArticle," +
                   "iScalaDB.dbo.OR030100.OR03012,iScalaDB.dbo.OR030100.OR03033," +
                   "SUM(ISNULL(GoWH.dbo.go_article_stock.QtyOUT,0)) as DelQty," +
                   "iScalaDB.dbo.OR030100.OR03012-SUM(ISNULL(GoWH.dbo.go_article_stock.QtyOUT,0)) as DiffQty," +
                   "GoWH.dbo.go_article_masterdata.UnitCodeStoc,GoWH.dbo.go_article_masterdata.GoWHClass," +
                   "iScalaDB.dbo.OR030100.OR03046 " +
                   "FROM " +
                   "(select COUNT([iScalaDB].[dbo].[OR030100].OR03005) as MyCount," +
                   "[iScalaDB].[dbo].[OR030100].OR03001 as OrderNo " +
                   "from [iScalaDB].[dbo].[OR030100] group by [iScalaDB].[dbo].[OR030100].OR03001) t," +
                   "(select COUNT(b.QtyOut)as RemainQty,a.mUser,a.KeyDocCmdScala " +
                   "from GoWH.dbo.go_docs_records a," +
                   "GoWH.dbo.go_article_stock b WHERE a.ID=b.ID_DOC_REC " +
                   "group by a.mUser,a.KeyDocCmdScala) z," +
                   "iScalaDB.dbo.OR010100,GoWH.dbo.go_article_masterdata,[iScalaDB].[dbo].[SL010100]," +
                   "iScalaDB.dbo.OR030100 " +
                   "LEFT JOIN GoWH.dbo.go_article_stock ON " +
                   "(GoWH.dbo.go_article_stock.PC03001Ref COLLATE SQL_Latin1_General_CP1_CI_AS =" +
                   "iScalaDB.dbo.OR030100.OR03001 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                   "AND GoWH.dbo.go_article_stock.PC03002Ref COLLATE SQL_Latin1_General_CP1_CI_AS =" +
                   "iScalaDB.dbo.OR030100.OR03002 COLLATE SQL_Latin1_General_CP1_CI_AS AND " +
                   "GoWH.dbo.go_article_stock.PC03003Ref COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                   "iScalaDB.dbo.OR030100.OR03003 COLLATE SQL_Latin1_General_CP1_CI_AS) " +
                   "where iScalaDB.dbo.OR010100.OR01001 COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                   "z.KeyDocCmdScala AND " +
                   "iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() + " AND iScalaDB.dbo.OR010100.OR01001 = " +
                        //"iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND 7 AND iScalaDB.dbo.OR010100.OR01001 = " +
                   "iScalaDB.dbo.OR030100.OR03001 AND iScalaDB.dbo.OR030100.OR03005 " +
                   "COLLATE SQL_Latin1_General_CP1_CI_AS=GoWH.dbo.go_article_masterdata.StockCode " +
                   "COLLATE SQL_Latin1_General_CP1_CI_AS AND " +
                   "[iScalaDB].[dbo].[SL010100].SL01001= [iScalaDB].[dbo].[OR010100].OR01003 " +
                   "COLLATE SQL_Latin1_General_CP1_CI_AS AND t.OrderNo=iScalaDB.dbo.OR010100.OR01001 " +
                   "group by iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005," +
                   "iScalaDB.dbo.OR030100.OR03006,iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03012," +
                   "iScalaDB.dbo.OR030100.OR03033,GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                   "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046," +
                   "[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                   "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                   "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                   "[iScalaDB].[dbo].[OR010100].OR01091,[iScalaDB].[dbo].[OR010100].OR01009," +
                   "[iScalaDB].[dbo].[OR010100].OR01010,[iScalaDB].[dbo].[OR010100].OR01021," +
                   "[iScalaDB].[dbo].[OR010100].OR01023,z.mUser,z.RemainQty," +
                   "t.MyCount,[iScalaDB].[dbo].[SL010100].SL01002 " +
                        //"HAVING iScalaDB.dbo.OR010100.OR01091<>6 " +
                   "order by [iScalaDB].[dbo].[OR010100].OR01001,DiffItems DESC";
                }
                else
                {
                    mq = "select [iScalaDB].[dbo].[OR010100].OR01001,"+
			        "[iScalaDB].[dbo].[OR010100].OR01003,[iScalaDB].[dbo].[SL010100].SL01002,"+
			        "COUNT(*) as MyRemainCount,[iScalaDB].[dbo].[OR030100].OR03012 as DiffItems,"+
			        "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017,COUNT([iScalaDB].[dbo].[OR030100].OR03001),"+
			        "'Manual Picking' as mUser,[iScalaDB].[dbo].[OR010100].OR01050,"+
                    "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01091," +
			        "CASE [iScalaDB].[dbo].[OR010100].OR01009 "+ 
                    "WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 "+
                    "   ELSE '' END,"+
                    "CASE [iScalaDB].[dbo].[OR010100].OR01010 "+ 
                    "   WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 "+
                    "   ELSE '' END,[iScalaDB].[dbo].[OR030100].OR03002,[iScalaDB].[dbo].[OR030100].OR03005,"+
			        "ISNULL(OR030100.OR03006,'')+ISNULL(iScalaDB.dbo.OR030100.OR03007,'') as DescriptioArticle,"+
                    "iScalaDB.dbo.OR030100.OR03012,iScalaDB.dbo.OR030100.OR03033,iScalaDB.dbo.OR030100.OR03012 as DelQty,0 as DiffQty," +
			        "GoWH.dbo.go_article_masterdata.UnitCodeStoc,GoWH.dbo.go_article_masterdata.GoWHClass,"+
			        "[iScalaDB].[dbo].[OR030100].OR03046 "+
			        "from [iScalaDB].[dbo].[OR010100] WITH(NOLOCK),"+
			        "[iScalaDB].[dbo].[SL010100] with(NOLOCK),"+
			        "[iScalaDB].[dbo].[OR030100] WITH(NOLOCK)"+
			        "LEFT JOIN GoWH.dbo.go_article_masterdata ON iScalaDB.dbo.OR030100.OR03005 "+
			        "COLLATE SQL_Latin1_General_CP1_CI_AS=GoWH.dbo.go_article_masterdata.StockCode "+
			        "where [iScalaDB].[dbo].[OR010100].OR01001=[iScalaDB].[dbo].[OR030100].OR03001 "+
			        "AND [iScalaDB].[dbo].[OR010100].OR01003=[iScalaDB].[dbo].SL010100.SL01001 "+
                    " AND [iScalaDB].[dbo].[OR010100].OR01091=" + DELIVERY_INTERMEDIATE_STATUS.ToString()  + " " +
			        "group by [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003,"+
			        "[iScalaDB].[dbo].[OR010100].OR01004,[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017,"+
			        "[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[SL010100].SL01002,"+
                    "[iScalaDB].[dbo].[OR030100].OR03012,[iScalaDB].[dbo].[OR010100].OR01009,iScalaDB.dbo.OR010100.OR01023,"+
			        "iScalaDB.dbo.OR010100.OR01021,iScalaDB.dbo.OR010100.OR01010,[iScalaDB].[dbo].[OR030100].OR03002,[iScalaDB].[dbo].[OR030100].OR03005,"+
			        "OR030100.OR03006,iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03012,iScalaDB.dbo.OR030100.OR03033,"+
			        "GoWH.dbo.go_article_masterdata.UnitCodeStoc,GoWH.dbo.go_article_masterdata.GoWHClass,"+
                    "[iScalaDB].[dbo].[OR030100].OR03046,[iScalaDB].[dbo].[OR010100].OR01091 " +
			        "order by [iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01001;";
                }
                /*
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01091," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01009 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 ELSE '' END,"+
                "CASE [iScalaDB].[dbo].[OR010100].OR01010 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 ELSE '' END,"+
                "iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "SUM(GoWH.dbo.go_article_stock.QtyOUT) as DelQty," +
                "iScalaDB.dbo.OR030100.OR03011-SUM(GoWH.dbo.go_article_stock.QtyOUT) as DiffQty," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046 " +
                "FROM " +
                "iScalaDB.dbo.OR010100,GoWH.dbo.go_article_masterdata,iScalaDB.dbo.OR030100 " +
                "LEFT JOIN GoWH.dbo.go_article_stock ON " +
                "GoWH.dbo.go_article_stock.PC03001Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03001 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03002Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03002 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03003Ref COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                "iScalaDB.dbo.OR030100.OR03003 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "where " +
                " iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() + "" +
                "AND iScalaDB.dbo.OR010100.OR01001 = iScalaDB.dbo.OR030100.OR03001 " +
                "AND iScalaDB.dbo.OR030100.OR03005 COLLATE SQL_Latin1_General_CP1_CI_AS" +
                "=GoWH.dbo.go_article_masterdata.StockCode " +
                "COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "group by iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, iScalaDB.dbo.OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046," +
                "[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                "[iScalaDB].[dbo].[OR010100].OR01091," +
                "[iScalaDB].[dbo].[OR010100].OR01009,[iScalaDB].[dbo].[OR010100].OR01010,[iScalaDB].[dbo].[OR010100].OR01021,[iScalaDB].[dbo].[OR010100].OR01023 " +
                "order by [iScalaDB].[dbo].[OR010100].OR01001;";
                 */ 
            }
            else if (myScope == 1) //Caut o comanda anume
            {
                /*
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01091," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01009 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 ELSE '' END," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01010 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 ELSE '' END," +
                "iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "SUM(GoWH.dbo.go_article_stock.QtyOUT) as DelQty," +
                "iScalaDB.dbo.OR030100.OR03011-SUM(GoWH.dbo.go_article_stock.QtyOUT) as DiffQty," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046 " +
                "FROM " +
                "iScalaDB.dbo.OR010100,GoWH.dbo.go_article_masterdata,iScalaDB.dbo.OR030100 " +
                "LEFT JOIN GoWH.dbo.go_article_stock ON " +
                "GoWH.dbo.go_article_stock.PC03001Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03001 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03002Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03002 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03003Ref COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                "iScalaDB.dbo.OR030100.OR03003 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "where " +
                "iScalaDB.dbo.OR010100.OR01001  COLLATE SQL_Latin1_General_CP1_CI_AS='"+SrchItem.Trim()+"'" +
                "AND iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() + "" +
                "AND iScalaDB.dbo.OR010100.OR01001 = iScalaDB.dbo.OR030100.OR03001 " +
                "AND iScalaDB.dbo.OR030100.OR03005 COLLATE SQL_Latin1_General_CP1_CI_AS" +
                "=GoWH.dbo.go_article_masterdata.StockCode " +
                "COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "group by iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, iScalaDB.dbo.OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046," +
                "[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                "[iScalaDB].[dbo].[OR010100].OR01091," +
                "[iScalaDB].[dbo].[OR010100].OR01009,[iScalaDB].[dbo].[OR010100].OR01010,[iScalaDB].[dbo].[OR010100].OR01021,[iScalaDB].[dbo].[OR010100].OR01023 " +
                "order by [iScalaDB].[dbo].[OR010100].OR01001;";
                 */
            }
            else if (myScope == 2)  //Caut comenzi dupa un anumit articol
            {
                /*
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01091," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01009 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 ELSE '' END," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01010 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 ELSE '' END," +
                "iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "SUM(GoWH.dbo.go_article_stock.QtyOUT) as DelQty," +
                "iScalaDB.dbo.OR030100.OR03011-SUM(GoWH.dbo.go_article_stock.QtyOUT) as DiffQty," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046 " +
                "FROM " +
                "iScalaDB.dbo.OR010100,GoWH.dbo.go_article_masterdata,iScalaDB.dbo.OR030100 " +
                "LEFT JOIN GoWH.dbo.go_article_stock ON " +
                "GoWH.dbo.go_article_stock.PC03001Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03001 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03002Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03002 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03003Ref COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                "iScalaDB.dbo.OR030100.OR03003 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "where " +
                " iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() + "" +
                "AND iScalaDB.dbo.OR010100.OR01001 = iScalaDB.dbo.OR030100.OR03001 " +
                "AND iScalaDB.dbo.OR030100.OR03005 COLLATE SQL_Latin1_General_CP1_CI_AS='"+SrchItem.Trim()+"' " +
                "AND iScalaDB.dbo.OR030100.OR03005 COLLATE SQL_Latin1_General_CP1_CI_AS" +
                "=GoWH.dbo.go_article_masterdata.StockCode " +
                "COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "group by iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, iScalaDB.dbo.OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046," +
                "[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                "[iScalaDB].[dbo].[OR010100].OR01091," +
                "[iScalaDB].[dbo].[OR010100].OR01009,[iScalaDB].[dbo].[OR010100].OR01010,[iScalaDB].[dbo].[OR010100].OR01021,[iScalaDB].[dbo].[OR010100].OR01023 " +
                "order by [iScalaDB].[dbo].[OR010100].OR01001;";
                 */ 
            }
            else if (myScope == 3)
            {
                /*
                mq = "select [iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015,[iScalaDB].[dbo].[OR010100].OR01091," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01009 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01023 ELSE '' END," +
                "CASE [iScalaDB].[dbo].[OR010100].OR01010 WHEN 2 THEN [iScalaDB].[dbo].[OR010100].OR01021 ELSE '' END," +
                "iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "SUM(GoWH.dbo.go_article_stock.QtyOUT) as DelQty," +
                "iScalaDB.dbo.OR030100.OR03011-SUM(GoWH.dbo.go_article_stock.QtyOUT) as DiffQty," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046 " +
                "FROM " +
                "iScalaDB.dbo.OR010100,GoWH.dbo.go_article_masterdata,iScalaDB.dbo.OR030100 " +
                "LEFT JOIN GoWH.dbo.go_article_stock ON " +
                "GoWH.dbo.go_article_stock.PC03001Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03001 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03002Ref COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "=iScalaDB.dbo.OR030100.OR03002 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "AND GoWH.dbo.go_article_stock.PC03003Ref COLLATE SQL_Latin1_General_CP1_CI_AS=" +
                "iScalaDB.dbo.OR030100.OR03003 COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "where " +
                "[iScalaDB].[dbo].[OR010100].OR01003 COLLATE SQL_Latin1_General_CP1_CI_AS='" + SrchItem.Trim() + "'" +
                "AND iScalaDB.dbo.OR010100.OR01091 BETWEEN " + DELIVERY_INIT_STATUS.ToString() + " AND " + DELIVERY_FINISH_STATUS.ToString() + "" +
                "AND iScalaDB.dbo.OR010100.OR01001 = iScalaDB.dbo.OR030100.OR03001 " +
                "AND iScalaDB.dbo.OR030100.OR03005 COLLATE SQL_Latin1_General_CP1_CI_AS" +
                "=GoWH.dbo.go_article_masterdata.StockCode " +
                "COLLATE SQL_Latin1_General_CP1_CI_AS " +
                "group by iScalaDB.dbo.OR030100.OR03002,iScalaDB.dbo.OR030100.OR03005, iScalaDB.dbo.OR030100.OR03006," +
                "iScalaDB.dbo.OR030100.OR03007,iScalaDB.dbo.OR030100.OR03011,iScalaDB.dbo.OR030100.OR03033," +
                "GoWH.dbo.go_article_masterdata.UnitCodeStoc," +
                "GoWH.dbo.go_article_masterdata.GoWHClass,iScalaDB.dbo.OR030100.OR03046," +
                "[iScalaDB].[dbo].[OR010100].OR01001,[iScalaDB].[dbo].[OR010100].OR01003," +
                "[iScalaDB].[dbo].[OR010100].OR01056,[iScalaDB].[dbo].[OR010100].OR01017," +
                "[iScalaDB].[dbo].[OR010100].OR01050,[iScalaDB].[dbo].[OR010100].OR01015," +
                "[iScalaDB].[dbo].[OR010100].OR01091," +
                "[iScalaDB].[dbo].[OR010100].OR01009,[iScalaDB].[dbo].[OR010100].OR01010,[iScalaDB].[dbo].[OR010100].OR01021,[iScalaDB].[dbo].[OR010100].OR01023 " +
                "order by [iScalaDB].[dbo].[OR010100].OR01001;";
                 */
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            try
            {
                dataread = mcmd.ExecuteReader();

            }
            catch {
                MessageBox.Show("SQL_SERVER TIME OUT");
                return;
            }
            gridControl1.BeginUpdate();
            try
            {
                while (dataread.Read())
                {
                    if (LastOrder != MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"))
                    {
                        string DiffItems = "";

                        if (MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'") == "0")
                        {
                            DiffItems = "No";
                        }
                        else
                        {
                            DiffItems = "Yes";
                        }
                        if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_INIT_STATUS.ToString())
                        {
                            
                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems ,
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "INIT("+DELIVERY_INIT_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_START_STATUS.ToString())
                        {
                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "PROGRESS("+DELIVERY_START_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});




                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_FINISH_STATUS.ToString())
                        {

                            
                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "FINISH("+DELIVERY_FINISH_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_INTERMEDIATE_STATUS.ToString() )
                        {


                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                //MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                0,
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "PICKING("+DELIVERY_INTERMEDIATE_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                    }
                    MyCountRemain = 0;
                    MyUser = "";

                    //#endregion

                    double zzzz = 0;
                    try
                    {
                        zzzz = double.Parse(dataread[18].ToString().Trim());
                    }
                    catch { }
                    if (zzzz > 0)
                    {
                        MyCountRemain++;
                    }
                    if (MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'") != "")
                    {
                        MyUser = MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'");
                    }
                    dataSetMonitor.tblDeliveryDetail.Rows.Add(new object[] {MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),  
                                                                         MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[20].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[21].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[23].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[22].ToString().Trim(), "'")});
                    if (MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'") == MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"))
                    {
                        //gridView1.SetRowCellValue();  
                    }
                    LastOrder = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
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
        private void LoadStatusOper()
        {
            string mq = "";
            
            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mq = "SELECT DelInitStatus, DelStartStatus, DelFinishStatus, RecInitStatus, RecStartStatus, RecFinishStatus,KeyDelIntermediateStatus " +
                 "FROM go_scala_status " +
                 "WHERE (GETDATE() BETWEEN DelValidFrom AND DelValidTo);";

            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            
            try
            {
                while (dataread.Read())
                {
                    try
                    {
                        DELIVERY_INIT_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"));
                    }
                    catch { DELIVERY_INIT_STATUS = -1; }
                    try
                    {
                        DELIVERY_START_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        DELIVERY_START_STATUS = -1;
                    }
                    try
                    {
                        DELIVERY_FINISH_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        DELIVERY_FINISH_STATUS = -1;
                    }
                    try
                    {
                        RECEIPT_INIT_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        RECEIPT_INIT_STATUS = -1;
                    }
                    try
                    {
                        RECEIPT_START_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        RECEIPT_START_STATUS = -1;
                    }
                    try
                    {
                        RECEIPT_FINISH_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"));
                    }
                    catch
                    {
                        RECEIPT_FINISH_STATUS = -1;
                    }
                    try
                    {
                        DELIVERY_INTERMEDIATE_STATUS = int.Parse(MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'")); 
                    }
                    catch
                    {
                        DELIVERY_INTERMEDIATE_STATUS = -1;
                    }
                }
            }
            catch (Exception mk)
            {
                string k;
                k = mk.ToString();
            }
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.StyleFormatCondition cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["OrderNo"], null, "INIT");
            cn.Appearance.ForeColor = Color.RosyBrown;
            cn.ApplyToRow = true;
            gridView1.FormatConditions.Add(cn);
            
            DevExpress.XtraGrid.StyleFormatCondition cd = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.GreaterOrEqual, gridView1.Columns["OrderStatus"], null, "PROGRESS");
            cd.Appearance.ForeColor = Color.Red;
            cd.ApplyToRow = true;
            gridView1.FormatConditions.Add(cd);

            DevExpress.XtraGrid.StyleFormatCondition cz = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal , gridView1.Columns["OrderStatus"], null, "FINISH");
            cz.Appearance.ForeColor = Color.Blue;
            cz.ApplyToRow = true;
            gridView1.FormatConditions.Add(cz);

            /*
            DevExpress.XtraGrid.StyleFormatCondition ct = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, gridView2.Columns["RemainQty"], null, "");
            ct.Appearance.ForeColor = Color.Brown ;
            ct.ApplyToRow = true;
            gridView1.FormatConditions.Add(ct);
             */
            DevExpress.XtraGrid.StyleFormatCondition css = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["DeliverQty"], null, "0.000000");
            css.Appearance.ForeColor = Color.RosyBrown;
            css.ApplyToRow = true;
            gridView2.FormatConditions.Add(css);

            DevExpress.XtraGrid.StyleFormatCondition cs = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, gridView2.Columns["RemainQty"], null, "0.000000");
            cs.Appearance.ForeColor = Color.Red;
            cs.ApplyToRow = true;
            gridView2.FormatConditions.Add(cs);
           
            gridView1.BestFitColumns();
           
            rbOrder.Checked = true;
            //CkMonitor.Checked = true; 
            LoadStatusOper();
            if (DELIVERY_INIT_STATUS == -1 || DELIVERY_INIT_STATUS == 0)
            {
                MessageBox.Show("Nu se pot monitoriza livrarile atata timp cat DELIVERY STATUS nu este setat.","");
                this.Close();
            }
            LoadDeliveryOrder01("",0);
        }

        private void frmMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyGlobal.mFrmMonitor = null;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadDeliveryOrder("",0);
        }
        private void frmMonitor_Resize(object sender, EventArgs e)
        {
            gridControl1.Size = new Size(this.Size.Width-30, this.Size.Height - 100);
            gridControl1.Location = new Point(9, 50);
        }
        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (CkDescarcaStoc.Checked == false)
            {
                if (txtSrch.Text.Trim() == "")
                {
                    MessageBox.Show("Nu exista un criteriu de cautare", "STOP");
                    return;
                }
                timer1.Enabled = false;
                if (rbOrder.Checked == true)
                {
                    LoadDeliveryOrder(txtSrch.Text.Trim(), 1);
                }
                else if (rbArticle.Checked == true)
                {
                    LoadDeliveryOrder(txtSrch.Text.Trim(), 2);
                }
                else if (rbCustomer.Checked == true)
                {
                    LoadDeliveryOrder(txtSrch.Text.Trim(), 3);
                }
                if (CkMonitor.Checked == true)
                {
                    timer2.Enabled = true;
                }
            }
            else
            {
                
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CkMonitor.Checked == true)
            {
                txtSrch.Text = "";
                rbOrder.Checked = true;
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false; 
            }
            
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
        private void tblDeliveryOrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void CkMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (CkMonitor.Checked == true)
            {
                timer1.Enabled = true;
                timer2.Enabled = false;

            }
            else
            {
                timer2.Enabled = true; 
            }
        }
        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                if (CkDescarcaStoc.Checked == true)
                {
                    OPER_TYPE++;
                    CkMonitor.Checked = false;
                    GridView View = gridControl1.FocusedView as GridView;
                    /*
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView2.Columns)
                    {
                        gridView2.SelectCell(gridView2.FocusedRowHandle, gc);
                        int xxHandle = View.FocusedRowHandle;
                    }
                    */
                    int rHandle = View.FocusedRowHandle;
                    View.SetMasterRowExpanded(rHandle, !View.GetMasterRowExpanded(rHandle));
                    System.Data.DataRow row = View.GetDataRow(View.FocusedRowHandle);
                    string OrderNo = row[0].ToString();
                    string ArtCode = row[2].ToString();
                    string LineNo = row[1].ToString();
                    double mqty=double.Parse(row[4].ToString());
                    SaveDataProc(OrderNo, ArtCode, LineNo, mqty);
                    LoadDeliveryOrder("", 0);
                    //MessageBox.Show(OrderNo + " " + ArtCode + " " + LineNo);
                    

                }
            }
             
        }
        private void gridView1_KeyDown(object sender,KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                if (CkDescarcaStoc.Checked == true)
                {
                    CkMonitor.Checked = false;  
                    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    string OrderNo = row[0].ToString();
                    if (OPER_TYPE == 0)
                    {
                        if (MessageBox.Show("Doresti sa descarci automat din GoWMS\r\n toate articolele din comanda " + OrderNo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SaveDataProc(OrderNo, "", "", 0);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Pentru comanda " + OrderNo+"\r\n s-au operat descarcari de gestiune partiale.Operatia posibila este schimbare status comanda.\r\nDoresti sa continui ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SaveDataProc(OrderNo, "_UPDATE_STATUS_", "", 0);
                        }
                    }
                    LoadDeliveryOrder("", 0);
                    OPER_TYPE = 0;

                }

            }
        }

        private void CkDescarcaStoc_Click(object sender, EventArgs e)
        {
            if (CkDescarcaStoc.Checked == false)
            {
                CkDescarcaStoc.Checked = false;
                CkDescarcaStoc.Text = "Terminal";
                gridView2.OptionsBehavior.Editable = false;   
                
            }
            else
            {
                CkDescarcaStoc.Checked = true;
                CkDescarcaStoc.Text = "Manual";
                gridView2.OptionsBehavior.Editable = true; 

            }
        }
        private long SaveDataProc(string OrderNo,string ArtCode,string LineNo,double mQty)
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
            System.Data.SqlClient.SqlCommand mcmd = null;
            mcmd = new System.Data.SqlClient.SqlCommand("SaveOrderManual");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ORDERNo", SqlDbType.NVarChar,OrderNo.Length  ));
            mcmd.Parameters["@ORDERNo"].Value = OrderNo ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ARTCODE", SqlDbType.NVarChar, ArtCode.Length  ));
            mcmd.Parameters["@ARTCODE"].Value = ArtCode ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LINENo", SqlDbType.NVarChar, LineNo.Length));
            mcmd.Parameters["@LINENo"].Value = LineNo ;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@QTY", SqlDbType.Decimal));
            mcmd.Parameters["@QTY"].Value = mQty;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MUSER", SqlDbType.NVarChar, MyGlobal.MyUserInfo.MyUser.Length));
            mcmd.Parameters["@MUSER"].Value = MyGlobal.MyUserInfo.MyUser;

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mErr", SqlDbType.Int));
            mcmd.Parameters["@mErr"].Direction = ParameterDirection.Output;
            
            mcmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                mcmd.ExecuteNonQuery();
            }
            catch { }


            try
            {
                MyErr = (int)mcmd.Parameters["@mErr"].Value;
            }
            catch {}

            if (MyErr == -100)
            {
                MessageBox.Show("SQL ERROR\r\nNu se pot salva date", "");
            }
            else if (MyErr == -101)
            {
                MessageBox.Show("SQL ERROR\r\nTranzactia nu s-a incheiat cu succes");
            }
            else if (MyErr == -204)
            {
                MessageBox.Show("Nu pot sa fac update in iScalaDB");
            }
            else if (MyErr == 1)
            {
                MessageBox.Show("Nu toate articolele au stoc in WMS\r\nPentru aceste articole nu s-au operat modificarid de stoc.");
            }
            
            else if (MyErr == 0)
            {
                MessageBox.Show("Datele au fost salvate cu succes\r\n");
            }
            //dataread.Close();

            return MyErr;
        }
        
        private void CkDescarcaStoc_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void LoadDeliveryOrder01(string SrchItem, int myScope)
        {
            string mq = "";
            string LastOrder = "";
            int MyCountRemain = 0;
            string MyUser = "";
            

            //DataRowBuilder rb=new DataRowBuilder();
            //DataSetMonitor.tblDeliveryOrderRow mIdxRow = new DataSetMonitor.tblDeliveryOrderRow(rb);

            dataSetMonitor.Clear();
            //dataSetMonitor.Reset();
            this.Cursor = Cursors.WaitCursor;

            System.Data.SqlClient.SqlDataReader dataread = null;

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("[Monitoring01]");
            mcmd.Connection = MyGlobal.MY_SQL_CON;

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                dataread = mcmd.ExecuteReader();
            }
            catch { }

            gridControl1.BeginUpdate();
            try
            {
                while (dataread.Read())
                {
                    if (LastOrder != MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"))
                    {
                        string DiffItems = "";

                        if (MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'") == "0")
                        {
                            DiffItems = "No";
                        }
                        else
                        {
                            DiffItems = "Yes";
                        }
                        if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_INIT_STATUS.ToString())
                        {

                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems ,
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "INIT("+DELIVERY_INIT_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_START_STATUS.ToString())
                        {
                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "PROGRESS("+DELIVERY_START_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});




                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_FINISH_STATUS.ToString())
                        {


                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "FINISH("+DELIVERY_FINISH_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                        else if (MyGlobal.Srch2Escape(dataread[11].ToString().Trim(), "'") == DELIVERY_INTERMEDIATE_STATUS.ToString())
                        {


                            dataSetMonitor.tblDeliveryOrder.Rows.Add(new object[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                                                                //MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'")+"("+ MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")+")",
                                                                                0,
                                                                                DiffItems, 
                                                                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                                                                //MyUser.Trim(),
                                                                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[10].ToString().Trim(), "'"),
                                                                                "PICKING("+DELIVERY_INTERMEDIATE_STATUS.ToString()+")" ,
                                                                                MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'"),
                                                                                MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'")});

                        }
                    }
                    MyCountRemain = 0;
                    MyUser = "";

                    //#endregion

                    double zzzz = 0;
                    try
                    {
                        zzzz = double.Parse(dataread[18].ToString().Trim());
                    }
                    catch { }
                    if (zzzz > 0)
                    {
                        MyCountRemain++;
                    }
                    if (MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'") != "")
                    {
                        MyUser = MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'");
                    }
                    dataSetMonitor.tblDeliveryDetail.Rows.Add(new object[] {MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),  
                                                                         MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[20].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[21].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[23].ToString().Trim(), "'"),
                                                                         MyGlobal.Srch2Escape(dataread[22].ToString().Trim(), "'")});
                    if (MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'") == MyGlobal.Srch2Escape(dataread[19].ToString().Trim(), "'"))
                    {
                        //gridView1.SetRowCellValue();  
                    }
                    LastOrder = MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'");
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
    }
}