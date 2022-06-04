using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmPresentationFom : Form
    {
        private long ID_REC= 0;
        private string OLD_CODE = "";
        public frmPresentationFom()
        {
            InitializeComponent();
        }

        private void CkPartType_CheckedChanged(object sender, EventArgs e)
        {
            if (CkPartType.Checked == true)
            {
                CkPartType.Text = "Client";
                LoadPartener(true);
            }
            else
            {
                CkPartType.Text = "Furnizor";
                LoadPartener(false);
            }
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

        private void frmPresentationFom_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmPresentationForm = null; 
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmPresentationFom_Load(object sender, EventArgs e)
        {
            
            ColumnHeader colHead;
            this.MyListView.Clear();
            this.MyListView.Columns.Clear();

            colHead = new ColumnHeader();
            colHead.Text = "ID";
            colHead.Width = 60;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "CodArticol";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "DescriereArticol";
            colHead.Width = 180;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "COD/Simbol";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Descriere";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "CantitateFP";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "TipMiscare";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);


            colHead = new ColumnHeader();
            colHead.Text = "CodPartener";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "NumePartener";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "TipPartener";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "ParamFizic";
            colHead.Width = 120;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Proprietate";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "OperatieConversie";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Coeficient";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "UMEchivalent";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Use4Pack";
            colHead.Width = 100;
            this.MyListView.Columns.Add(colHead);


            colHead = new ColumnHeader();
            colHead.Text = "User";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Inregistrat";
            colHead.Width = 160;
            this.MyListView.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Modificat";
            colHead.Width = 80;
            this.MyListView.Columns.Add(colHead);
                        
            this.MyListView.GridLines = true;
            this.MyListView.FullRowSelect = true;
            this.MyListView.View = View.Details;
                        
            LoadPresentForm("");
                        
            LoadMasterData();
            LoadPartener(true);
            LoadConvertUOM();
            LoadPhisicalProperties();
            LoadMoveType();
            rbCodArticol.Checked = true;
        }
        private void LoadPresentForm(string mCriteria)
        {
            ListViewItem k = null;
            string mq = "";
            this.Cursor = Cursors.WaitCursor;
            this.MyListView.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if (mCriteria.Trim() == "")
            {
                /*
                mq = "SELECT go_article_forms.ID,go_article_forms.KeyArticle,go_article_masterdata.Description1,"+
                "go_article_forms.CodeForm,go_article_forms.Description,go_article_forms.QtyOnForm,go_article_forms.KeyMoveType,"+
                "go_area_def.WHCode,go_area_def.AreaCode,go_locator_def.LocatorSymbol,go_article_forms.KeyPartner,"+ 
                "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN "+
                "(SELECT SupplierName FROM go_supplier_def WHERE SupplierCode = go_article_forms.KeyPartner) "+
                "ELSE "+
                "(SELECT CustomerName FROM go_customer_def WHERE CustomerCode = go_article_forms.KeyPartner) END AS Expr1,"+
                "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN "+
                "'FURNIZOR' ELSE 'CLIENT' END as TypePart,go_article_forms.KeyPhisicProp,"+
                "go_article_forms.PhisicPropVal,go_article_forms.ConvertMultiply,go_article_forms.Coeficient,"+
                "go_article_forms.KeyUOM,go_article_forms.mUser,go_article_forms.InDate,go_article_forms.UpToDate "+
                "FROM dbo.go_article_forms,dbo.go_article_masterdata,dbo.go_locator_def,dbo.go_area_def "+
                "where go_article_forms.KeyArticle=go_article_masterdata.StockCode "+
                "AND go_article_forms.Key3DLoc=go_locator_def.ID "+
                "and go_locator_def.ID_STORAGE_AREA=go_area_def.ID;";
                 */
                mq = "SELECT go_article_forms.ID,go_article_forms.KeyArticle,go_article_masterdata.Description1," +
                "go_article_forms.CodeForm,go_article_forms.Description,go_article_forms.QtyOnForm,go_article_forms.KeyMoveType," +
                "go_article_forms.KeyPartner," +
                "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                "(SELECT SupplierName FROM go_supplier_def WHERE SupplierCode = go_article_forms.KeyPartner) " +
                "ELSE " +
                "(SELECT CustomerName FROM go_customer_def WHERE CustomerCode = go_article_forms.KeyPartner) END AS Expr1," +
                "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                "'FURNIZOR' ELSE 'CLIENT' END as TypePart,go_article_forms.KeyPhisicProp," +
                "go_article_forms.PhisicPropVal,go_article_forms.ConvertMultiply,go_article_forms.Coeficient," +
                "go_article_forms.KeyUOM,go_article_forms.Use4SplitPack,go_article_forms.mUser,go_article_forms.InDate,go_article_forms.UpToDate " +
                "FROM dbo.go_article_forms,dbo.go_article_masterdata " +
                "where go_article_forms.KeyArticle=go_article_masterdata.StockCode;";
            }
            else
            {
                if (rbCodArticol.Checked == true)
                {
                    mq = "SELECT go_article_forms.ID,go_article_forms.KeyArticle,go_article_masterdata.Description1," +
                    "go_article_forms.CodeForm,go_article_forms.Description,go_article_forms.QtyOnForm,go_article_forms.KeyMoveType," +
                    "go_article_forms.KeyPartner," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "(SELECT SupplierName FROM go_supplier_def WHERE SupplierCode = go_article_forms.KeyPartner) " +
                    "ELSE " +
                    "(SELECT CustomerName FROM go_customer_def WHERE CustomerCode = go_article_forms.KeyPartner) END AS Expr1," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "'FURNIZOR' ELSE 'CLIENT' END as TypePart,go_article_forms.KeyPhisicProp," +
                    "go_article_forms.PhisicPropVal,go_article_forms.ConvertMultiply,go_article_forms.Coeficient," +
                    "go_article_forms.KeyUOM,go_article_forms.Use4SplitPack,go_article_forms.mUser,go_article_forms.InDate,go_article_forms.UpToDate " +
                    "FROM dbo.go_article_forms,dbo.go_article_masterdata " +
                    "where go_article_forms.KeyArticle=go_article_masterdata.StockCode AND go_article_masterdata.StockCode like '" + mCriteria.Trim() + "%' order by go_article_masterdata.StockCode;";
                }
                else if (rbCodBare.Checked == true)
                {
                    mq = "SELECT go_article_forms.ID,go_article_forms.KeyArticle,go_article_masterdata.Description1," +
                    "go_article_forms.CodeForm,go_article_forms.Description,go_article_forms.QtyOnForm,go_article_forms.KeyMoveType," +
                    "go_article_forms.KeyPartner," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "(SELECT SupplierName FROM go_supplier_def WHERE SupplierCode = go_article_forms.KeyPartner) " +
                    "ELSE " +
                    "(SELECT CustomerName FROM go_customer_def WHERE CustomerCode = go_article_forms.KeyPartner) END AS Expr1," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "'FURNIZOR' ELSE 'CLIENT' END as TypePart,go_article_forms.KeyPhisicProp," +
                    "go_article_forms.PhisicPropVal,go_article_forms.ConvertMultiply,go_article_forms.Coeficient," +
                    "go_article_forms.KeyUOM,go_article_forms.Use4SplitPack,go_article_forms.mUser,go_article_forms.InDate,go_article_forms.UpToDate " +
                    "FROM dbo.go_article_forms,dbo.go_article_masterdata " +
                    "where go_article_forms.KeyArticle=go_article_masterdata.StockCode AND go_article_forms.CodeForm like '" + mCriteria.Trim() + "%' order by go_article_forms.CodeForm;";
                }
                else if (rbCodPartener.Checked == true)
                {
                    mq = "SELECT go_article_forms.ID,go_article_forms.KeyArticle,go_article_masterdata.Description1," +
                    "go_article_forms.CodeForm,go_article_forms.Description,go_article_forms.QtyOnForm,go_article_forms.KeyMoveType," +
                    "go_article_forms.KeyPartner," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "(SELECT SupplierName FROM go_supplier_def WHERE SupplierCode = go_article_forms.KeyPartner) " +
                    "ELSE " +
                    "(SELECT CustomerName FROM go_customer_def WHERE CustomerCode = go_article_forms.KeyPartner) END AS Expr1," +
                    "CASE go_article_forms.SupplOrCustomer WHEN 'True' THEN " +
                    "'FURNIZOR' ELSE 'CLIENT' END as TypePart,go_article_forms.KeyPhisicProp," +
                    "go_article_forms.PhisicPropVal,go_article_forms.ConvertMultiply,go_article_forms.Coeficient," +
                    "go_article_forms.KeyUOM,go_article_forms.Use4SplitPack,go_article_forms.mUser,go_article_forms.InDate,go_article_forms.UpToDate " +
                    "FROM dbo.go_article_forms,dbo.go_article_masterdata " +
                    "where go_article_forms.KeyArticle=go_article_masterdata.StockCode AND go_article_forms.KeyPartner like '" + mCriteria.Trim() + "%' order by go_article_forms.KeyPartner;";
                }
            }
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            this.MyListView.BeginUpdate();
            while (dataread.Read())
            {

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
                if (MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'") == "0")
                {
                    k.SubItems.Add("NONE");
                }
                else if (MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'") == "1")
                {
                    k.SubItems.Add("MUL");
                }
                else if (MyGlobal.Srch2Escape(dataread[12].ToString().Trim(), "'") == "2")
                {
                    k.SubItems.Add("DIV");
                }
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[13].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[14].ToString().Trim(), "'"));
                if (MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'") == "False" || MyGlobal.Srch2Escape(dataread[15].ToString().Trim(), "'") =="")
                {
                    k.SubItems.Add("No");
                }
                else
                {
                    k.SubItems.Add("Yes");
                }
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[16].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[17].ToString().Trim(), "'"));
                k.SubItems.Add(MyGlobal.Srch2Escape(dataread[18].ToString().Trim(), "'"));
                                
                
                this.MyListView.Items.Add(k);
                
            }
            this.MyListView.EndUpdate();
            this.MyListView.Refresh();
            dataread.Close();

            try
            {
                dataread = null;
            }
            catch { }
            mcmd = null;
            this.Cursor = Cursors.Default;

        }
        
        private void LoadMasterData()
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
            mq = "SELECT StockCode,Description1 FROM dbo.go_article_masterdata order by StockCode;";
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
            LblARDescrieri.Text = "";
            this.CmbArticol.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadPartener(bool IsSupplier)
        {
            string mq = "";
            DataTable dataTable = new DataTable("Parteneri");
            dataTable.Columns.Add("CODPART", typeof(String));
            dataTable.Columns.Add("Nume", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbPartener.Text = "";
            CmbPartener.DataSource = null;
            this.CmbPartener.Items.Clear();
            this.CmbPartener.BeginUpdate();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            if(IsSupplier==true)
            {
                mq = "SELECT SupplierCode,SupplierName FROM dbo.go_supplier_def order by SupplierCode;";
            }
            else
            {
                mq = "SELECT CustomerCode,CustomerName FROM dbo.go_customer_def order by CustomerCode;";
            }
            
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbPartener.DataSource = dataTable;
            CmbPartener.DisplayMember = "CODPART";
            CmbPartener.ValueMember = "Nume";
            CmbPartener.Text = "";
            LblDPartener.Text="";
            this.CmbPartener.EndUpdate();
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadConvertUOM()
        {
            string mq = "";
            DataTable dataTable = new DataTable("UOM");
            dataTable.Columns.Add("Simbol", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbUOM.Text = "";
            this.CmbUOM.DataSource = null;
            this.CmbUOM.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT UOMSymbol,Description FROM dbo.go_article_UOM order by UOMSymbol;";
            
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            CmbUOM.DataSource = dataTable;
            CmbUOM.DisplayMember = "Simbol";
            CmbUOM.ValueMember = "Descriere";
            CmbUOM.Text = "";
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadPhisicalProperties()
        {
            string mq = "";
            DataTable dataTable = new DataTable("PhisProp");
            dataTable.Columns.Add("Simbol", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbTipProprietate.Text = "";
            this.CmbTipProprietate.DataSource = null;
            this.CmbTipProprietate.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT KeyPhisProp,Description FROM dbo.go_article_phis_prop order by KeyPhisProp;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'") });
            }
            this.CmbTipProprietate.DataSource = dataTable;
            this.CmbTipProprietate.DisplayMember = "Simbol";
            this.CmbTipProprietate.ValueMember = "Descriere";
            this.CmbTipProprietate.Text = "";
            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        private void LoadMoveType()
        {
            string mq = "";
            DataTable dataTable = new DataTable("MovType");
            dataTable.Columns.Add("Tip", typeof(String));
            dataTable.Columns.Add("Descriere", typeof(String));
            dataTable.Columns.Add("Actiune", typeof(String));

            this.Cursor = Cursors.WaitCursor;
            this.CmbTipMiscare.Text = "";
            this.CmbTipMiscare.DataSource = null;
            this.CmbTipMiscare.Items.Clear();
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mq = "SELECT MoveSymb,Description,Action FROM dbo.go_move_type order by MoveSymb;";
            mcmd.CommandText = mq;
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            while (dataread.Read())
            {
                dataTable.Rows.Add(new String[] { MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"), MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'") });
            }
            this.CmbTipMiscare.DataSource = dataTable;
            this.CmbTipMiscare.DisplayMember = "Tip";
            this.CmbTipMiscare.ValueMember = "Descriere";
            this.CmbTipMiscare.Text = "";

            dataread.Close();
            mcmd = null;
            this.Cursor = Cursors.Default;
        }
        
        private void CmbWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void CmbSTArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MyListLocator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CmbArticol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbArticol.SelectedItem).Row.ItemArray[1].ToString();
                this.LblARDescrieri.ForeColor= System.Drawing.Color.DarkBlue;
                this.LblARDescrieri.Text = ms.Trim();
            }
            catch { }
        }

        private void CmbPartener_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ms = "";
            try
            {
                ms = ((DataRowView)CmbPartener.SelectedItem).Row.ItemArray[1].ToString();
                this.LblDPartener.ForeColor = System.Drawing.Color.DarkBlue;
                this.LblDPartener.Text = ms.Trim();
            }
            catch { }
        }

        private void CmdSalvez_Click(object sender, EventArgs e)
        {
            double Qty = 0;
            double Coef = 0;
            string PartType = "";
            int MathMultiplyOperator = 0;
            string mq = "";
            string IfPacking = "";

            if(this.CkInmultire.Checked==false && this.CkImpartire.Checked==false)
            {
                MathMultiplyOperator = 0;
                CkInmultire.Checked = false;
                CkImpartire.Checked = false;
                CmbUOM.Text = "";
                txtCoeficient.Text = "";
            }
            else if (this.CkInmultire.Checked == true && this.CkImpartire.Checked == false)
            {
                MathMultiplyOperator = 1;
            }
            else if (this.CkInmultire.Checked == false && this.CkImpartire.Checked == true)
            {
                MathMultiplyOperator = 2;
            }
            else
            {
                CkInmultire.Checked = false;
                CkImpartire.Checked = false;
                CmbUOM.Text = "";
                txtCoeficient.Text = "";
            }

            if (CkAmbalaj.Checked == false)
            {
                IfPacking = "False";
            }
            else
            {
                IfPacking = "True";
            }

            if (CkPartType.Checked==false)
            {
                PartType = "False";
            }
            else
            {
                PartType = "True";
            }

            if (CmbArticol.Text.Trim() == "")
            {
                MessageBox.Show("Nu este setat Cod Articol.");
                return;
            }
            if (CmbPartener.Text.Trim()=="")
            {
                MessageBox.Show("Nu este selectat nici un partener.");
                return;
            }
            if (txtBarCode.Text.Trim() == "")
            {
                MessageBox.Show("Nu este setat nici un Cod Alternativ pentru Articolul " + CmbArticol.Text.Trim());
                return;
            }
            try
            {
                Qty = double.Parse(txtCantitate.Text.Trim());
            }
            catch { MessageBox.Show("Cantitatea este reprezentata numeric."); return; }
            if (txtDescriere.Text.Trim()=="")
            {
                MessageBox.Show("Nu este completata Descrierea.");
                return;
            }
            if(this.CmbTipMiscare.Text.Trim()=="")
            {
                MessageBox.Show("Trebuie asociat un Tip de Miscare.");
                return;
            }
            if (this.txtCoeficient.Text.Trim() != "")
            {
                try
                {
                    Coef = double.Parse(this.txtCoeficient.Text.Trim());
                }
                catch { MessageBox.Show("Coeficientul este reprezentat numeric."); return; }
            }
            if (ID_REC == 0)
            {
                
                string mp="";
                string[] mfunc = new string[4];
                if (MyGlobal.IsForUpdate("SELECT Description,KeyArticle,KeyPartner,SupplOrCustomer FROM go_article_forms where CodeForm='"+this.txtBarCode.Text.Trim()+"' order by CodeForm;", 4, ref mfunc) == true)
                {
                    if(mfunc[3].Trim()=="False")
                    {
                        mp="Furnizor";
                    }
                    else
                    {
                        mp="Client";
                    }
                    MessageBox.Show("Codul Echivalent "+this.txtBarCode.Text.Trim()+" este deja setat pentru\r\nArticol : "+mfunc[1].Trim()+"\r\nPartener : "+mfunc[2].Trim()+" Tip : "+mp+"\r\nDescriere : "+mfunc[0].Trim());
                    mfunc = null;
                    return;
                }
                mfunc = null; 
                
                mq = "INSERT INTO go_article_forms(KeyArticle,KeyPartner,SupplOrCustomer"+
                    ",CodeForm,Description,KeyPhisicProp,PhisicPropVal,QtyOnForm"+
                    ",KeyMoveType,ConvertMultiply,Coeficient,KeyUOM,Use4SplitPack"+
		            ",mUser,InDate,UpToDate) "+
			        "VALUES ('"+this.CmbArticol.Text.Trim()+"',"+
                    "'"+this.CmbPartener.Text.Trim()+"',"+
                    "'"+PartType.Trim()+"',"+
                    "'"+this.txtBarCode.Text.Trim()+"',"+
                    "'"+this.txtDescriere.Text.Trim()+"',"+
                    "'"+this.CmbTipProprietate.Text.Trim()+"',"+
                    "'"+this.txtProprietate.Text.Trim()+"',"+
                    ""+Qty+","+
                    "'"+CmbTipMiscare.Text.Trim()+"',"+
                    ""+MathMultiplyOperator.ToString().Trim()+","+
                    ""+Coef.ToString().Trim()+","+
                    "'"+CmbUOM.Text.Trim()+"',"+
                    "'"+ IfPacking.Trim() +"',"+
                    "'"+MyGlobal.MyUserInfo.MyUser.Trim()+"',"+
                    "getdate(),NULL);";                   
            }
            else
            {
                
                if(OLD_CODE.Trim()!=this.txtBarCode.Text.Trim())
                {
                    string mp = "";
                    string[] mfunc = new string[4];
                    if (MyGlobal.IsForUpdate("SELECT Description,KeyArticle,KeyPartner,SupplOrCustomer FROM go_article_forms where CodeForm='" + this.txtBarCode.Text.Trim() + "' order by CodeForm;", 4, ref mfunc) == true)
                    {
                        if (mfunc[3].Trim() == "False")
                        {
                            mp = "Furnizor";
                        }
                        else
                        {
                            mp = "Client";
                        }
                        MessageBox.Show("Codul Echivalent " + this.txtBarCode.Text.Trim() + " este deja setat pentru\r\nArticol : " + mfunc[1].Trim() + "\r\nPartener : " + mfunc[2].Trim() + " Tip : " + mp + "\r\nDescriere : " + mfunc[0].Trim());
                        mfunc = null;
                        return;
                    }
                    mfunc = null; 
                }
                
                mq = "update go_article_forms set KeyArticle='" + this.CmbArticol.Text.Trim() + "',"+
                    "KeyPartner='" + this.CmbPartener.Text.Trim() + "',"+
                    "SupplOrCustomer='" + PartType.Trim() + "'," +
                    "CodeForm='" + this.txtBarCode.Text.Trim() + "',"+
                    "Description='" + this.txtDescriere.Text.Trim() + "',"+
                    "KeyPhisicProp='" + this.CmbTipProprietate.Text.Trim() + "',"+
                    "PhisicPropVal='" + this.txtProprietate.Text.Trim() + "',"+
                    "QtyOnForm=" + Qty + "," +
                    "KeyMoveType='" + CmbTipMiscare.Text.Trim() + "',"+
                    "ConvertMultiply=" + MathMultiplyOperator.ToString().Trim() + ","+
                    "Coeficient=" + Coef.ToString().Trim() + ","+
                    "KeyUOM='" + CmbUOM.Text.Trim() + "'," +
                    "Use4SplitPack='"+ IfPacking.Trim() +"',"+
                    "mUser='" + MyGlobal.MyUserInfo.MyUser.Trim() + "',"+
                    "UpToDate=getdate() where ID=" + ID_REC.ToString().Trim() + ";";
            }
            if (this.SaveData(mq) == 0)
            {
                MessageBox.Show("Datele au fost salvate cu succes.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.DoEvents();  
                this.LoadPresentForm("");
                ResetCtrl();
            }   
            else
            {
                MessageBox.Show("Nu pot salva date.");
            }
            
            
        }
        private void ResetCtrl()
        {
            ID_REC = 0;
            OLD_CODE = "";
            txtCauta.Text = "";
            this.CmbArticol.Text = "";
            LblARDescrieri.Text = "";
            this.CmbPartener.Text = "";
            LblDPartener.Text = "";
            txtBarCode.Text = "";
            txtCantitate.Text = "";
            txtDescriere.Text = "";
            CmbUOM.Text = "";
            CkPartType.Checked = false;
            CkImpartire.Checked = false;
            CkInmultire.Checked = false;
            CkAmbalaj.Checked = false;   
            txtCoeficient.Text = "";
            CmbTipProprietate.Text = "";
            txtProprietate.Text = "";
            CmbTipMiscare.Text = "";
            this.CmbArticol.Focus();
        }
        private void CmdCauta_Click(object sender, EventArgs e)
        {
            if (txtCauta.Text.Trim() == "")
            {
                LoadPresentForm("");
            }
            else
            {
                LoadPresentForm(txtCauta.Text.Trim());
            }
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

        private void CkInmultire_CheckedChanged(object sender, EventArgs e)
        {
            if (CkInmultire.Checked==true && CkImpartire.Checked==false)
            {
                CkImpartire.Checked = false;
            }
            else if (CkInmultire.Checked == false && CkImpartire.Checked == true)
            {
                CkImpartire.Checked = true;
            }
            else
            {
                CkInmultire.Checked = false;
                CkImpartire.Checked = false;
            }
        }

        private void CkImpartire_CheckedChanged(object sender, EventArgs e)
        {

            if (CkImpartire.Checked == true && CkInmultire.Checked == false)
            {
                CkInmultire.Checked = false;    
            }
            else if (CkImpartire.Checked == false && CkInmultire.Checked == true)
            {
                CkInmultire.Checked = true;
            }
            else
            {
                CkInmultire.Checked = false;
                CkImpartire.Checked = false;
            }
        }

        private void copiazaInClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            int z = 0;
            string s = "";
            i = MyListView.SelectedIndices.Count;

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
        }

        private void MyListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LVMenu.Show(MyListView, new Point(e.X + 15, e.Y));
            }
        }

        private void MyListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            try
            {
                ID_REC = long.Parse(MyListView.SelectedItems[0].Text.Trim());
            }
            catch
            {
                MessageBox.Show("CRITIC_ERR ! Invalid ID_REC");
                return;
            }
            this.CmbArticol.Text=MyListView.SelectedItems[0].SubItems[1].Text.Trim();
            this.CmbTipMiscare.Text = MyListView.SelectedItems[0].SubItems[6].Text.Trim();
            
            
            this.txtBarCode.Text = MyListView.SelectedItems[0].SubItems[3].Text.Trim();
            OLD_CODE = txtBarCode.Text.Trim();
            this.txtDescriere.Text = MyListView.SelectedItems[0].SubItems[4].Text.Trim();
            this.txtCantitate.Text = MyListView.SelectedItems[0].SubItems[5].Text.Trim();
            if (MyListView.SelectedItems[0].SubItems[9].Text.Trim()=="Furnizor")
            {
                this.CkPartType.Checked = false;
            }
            else
            {
                this.CkPartType.Checked = true;
            }
            this.CmbPartener.Text = MyListView.SelectedItems[0].SubItems[7].Text.Trim();
            this.LblDPartener.Text = MyListView.SelectedItems[0].SubItems[8].Text.Trim();
            this.CmbTipProprietate.Text = MyListView.SelectedItems[0].SubItems[10].Text.Trim();
            this.txtProprietate.Text = MyListView.SelectedItems[0].SubItems[11].Text.Trim();
            
            if (MyListView.SelectedItems[0].SubItems[12].Text.Trim() == "NONE")
            {
                this.CkInmultire.Checked = false;
                this.CkImpartire.Checked = false;
            }
            else if (MyListView.SelectedItems[0].SubItems[12].Text.Trim()=="MUL")
            {
                this.CkInmultire.Checked = true;
                this.CkImpartire.Checked = false;
            }
            else if (MyListView.SelectedItems[0].SubItems[12].Text.Trim()=="DIV")
            {
                this.CkInmultire.Checked = false;
                this.CkImpartire.Checked = true;
            }
            else
            {
                this.CkInmultire.Checked = false;
                this.CkImpartire.Checked = false;
            }
            this.txtCoeficient.Text = MyListView.SelectedItems[0].SubItems[13].Text.Trim();
            this.CmbUOM.Text = MyListView.SelectedItems[0].SubItems[14].Text.Trim();
            if (MyListView.SelectedItems[0].SubItems[15].Text.Trim()=="Yes")
            {
                CkAmbalaj.Checked = true; 
            }
            else
            {
                CkAmbalaj.Checked = false ; 
            }
            
            MessageBox.Show("Ai selectat " + MyListView.SelectedItems[0].SubItems[1].Text.Trim() + " " + MyListView.SelectedItems[0].SubItems[2].Text.Trim());
        }

        private void MyListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27)
            {
                ResetCtrl();
            }
        }

        private void CmbArticol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbPartener_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtCantitate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtDescriere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbUOM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CkInmultire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CkImpartire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtCoeficient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbTipProprietate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtProprietate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void CmbTipMiscare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }

        private void txtCauta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                ResetCtrl();
            }
        }
                
        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            if (OLD_CODE.Trim()!="" && OLD_CODE.Trim() != this.txtBarCode.Text.Trim())
            {
                if (MessageBox.Show("Esti sigur ca doresti sa schimbi \r\nCodul Echivalent " + OLD_CODE.Trim() + " cu " + txtBarCode.Text.Trim() + " ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    txtBarCode.Text = OLD_CODE;
                    
                }
                else
                {
                    EventArgs erg = new EventArgs();
                    CmdSalvez_Click(CmdSalvez, erg);
                    erg = null;
                }

            }
        }

    }
}