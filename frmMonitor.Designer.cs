namespace GoWHMgmAdmin
{
    partial class frmMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitor));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArticleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArticleDesc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReservedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliverQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCodeStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoWHClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblDeliveryOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetMonitor = new GoWHMgmAdmin.DataSetMonitor();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMyCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffItems = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryRoute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWareHouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvizNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CmdCauta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.rbOrder = new System.Windows.Forms.RadioButton();
            this.rbArticle = new System.Windows.Forms.RadioButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.CkMonitor = new System.Windows.Forms.CheckBox();
            this.CkDescarcaStoc = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colOrderLineNo,
            this.colArticleCode,
            this.colArticleDesc1,
            this.colOrderQty,
            this.colReservedQty,
            this.colDeliverQty,
            this.colRemainQty,
            this.colUnitCodeStock,
            this.colWH,
            this.colGoWHClass});
            this.gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOrderLineNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colOrderLineNo
            // 
            this.colOrderLineNo.Caption = "OrderLineNo";
            this.colOrderLineNo.FieldName = "OrderLineNo";
            this.colOrderLineNo.Name = "colOrderLineNo";
            this.colOrderLineNo.Visible = true;
            this.colOrderLineNo.VisibleIndex = 0;
            // 
            // colArticleCode
            // 
            this.colArticleCode.Caption = "ArticleCode";
            this.colArticleCode.FieldName = "ArticleCode";
            this.colArticleCode.Name = "colArticleCode";
            this.colArticleCode.Visible = true;
            this.colArticleCode.VisibleIndex = 1;
            // 
            // colArticleDesc1
            // 
            this.colArticleDesc1.Caption = "ArticleDesc1";
            this.colArticleDesc1.FieldName = "ArticleDesc1";
            this.colArticleDesc1.Name = "colArticleDesc1";
            this.colArticleDesc1.Visible = true;
            this.colArticleDesc1.VisibleIndex = 2;
            // 
            // colOrderQty
            // 
            this.colOrderQty.Caption = "OrderQty";
            this.colOrderQty.FieldName = "OrderQty";
            this.colOrderQty.Name = "colOrderQty";
            this.colOrderQty.Visible = true;
            this.colOrderQty.VisibleIndex = 3;
            // 
            // colReservedQty
            // 
            this.colReservedQty.Caption = "ReservedQty";
            this.colReservedQty.FieldName = "ReservedQty";
            this.colReservedQty.Name = "colReservedQty";
            this.colReservedQty.Visible = true;
            this.colReservedQty.VisibleIndex = 4;
            // 
            // colDeliverQty
            // 
            this.colDeliverQty.Caption = "DeliverQty";
            this.colDeliverQty.FieldName = "DeliverQty";
            this.colDeliverQty.Name = "colDeliverQty";
            this.colDeliverQty.Visible = true;
            this.colDeliverQty.VisibleIndex = 5;
            // 
            // colRemainQty
            // 
            this.colRemainQty.Caption = "RemainQty";
            this.colRemainQty.FieldName = "RemainQty";
            this.colRemainQty.Name = "colRemainQty";
            this.colRemainQty.Visible = true;
            this.colRemainQty.VisibleIndex = 6;
            // 
            // colUnitCodeStock
            // 
            this.colUnitCodeStock.Caption = "UnitCodeStock";
            this.colUnitCodeStock.FieldName = "UnitCodeStock";
            this.colUnitCodeStock.Name = "colUnitCodeStock";
            this.colUnitCodeStock.Visible = true;
            this.colUnitCodeStock.VisibleIndex = 7;
            // 
            // colWH
            // 
            this.colWH.Caption = "WH";
            this.colWH.FieldName = "WHDel";
            this.colWH.Name = "colWH";
            this.colWH.Visible = true;
            this.colWH.VisibleIndex = 9;
            // 
            // colGoWHClass
            // 
            this.colGoWHClass.Caption = "GoWHClass";
            this.colGoWHClass.FieldName = "GoWHClass";
            this.colGoWHClass.Name = "colGoWHClass";
            this.colGoWHClass.Visible = true;
            this.colGoWHClass.VisibleIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblDeliveryOrderBindingSource;
            this.gridControl1.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "DeliveryOrderDetail";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(11, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(898, 426);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // tblDeliveryOrderBindingSource
            // 
            this.tblDeliveryOrderBindingSource.DataMember = "tblDeliveryOrder";
            this.tblDeliveryOrderBindingSource.DataSource = this.dataSetMonitor;
            this.tblDeliveryOrderBindingSource.CurrentChanged += new System.EventHandler(this.tblDeliveryOrderBindingSource_CurrentChanged);
            // 
            // dataSetMonitor
            // 
            this.dataSetMonitor.DataSetName = "DataSetMonitor";
            this.dataSetMonitor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNo,
            this.colCustomerCode,
            this.colCustomerName,
            this.colMyCount,
            this.colDiffItems,
            this.colDeliveryRoute,
            this.colSalesResponsable,
            this.colPOperator,
            this.colWareHouse,
            this.colOrderDate,
            this.colOrderStatus,
            this.colAvizNo,
            this.colInvoiceNo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderNo", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsPrint.PrintDetails = true;
            this.gridView1.OptionsPrint.PrintFilterInfo = true;
            this.gridView1.OptionsPrint.PrintPreview = true;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "OrderNo";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 0;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "CustomerCode";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 1;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "CustomerName";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 2;
            // 
            // colMyCount
            // 
            this.colMyCount.Caption = "CountRemain";
            this.colMyCount.FieldName = "MyCount";
            this.colMyCount.Name = "colMyCount";
            this.colMyCount.Visible = true;
            this.colMyCount.VisibleIndex = 3;
            // 
            // colDiffItems
            // 
            this.colDiffItems.Caption = "DiffItems";
            this.colDiffItems.FieldName = "DiffItems";
            this.colDiffItems.Name = "colDiffItems";
            this.colDiffItems.Visible = true;
            this.colDiffItems.VisibleIndex = 4;
            // 
            // colDeliveryRoute
            // 
            this.colDeliveryRoute.Caption = "DeliveryRoute";
            this.colDeliveryRoute.FieldName = "DeliveryRoute";
            this.colDeliveryRoute.Name = "colDeliveryRoute";
            this.colDeliveryRoute.Visible = true;
            this.colDeliveryRoute.VisibleIndex = 5;
            // 
            // colSalesResponsable
            // 
            this.colSalesResponsable.Caption = "SalesResponsable";
            this.colSalesResponsable.FieldName = "SalesResponsable";
            this.colSalesResponsable.Name = "colSalesResponsable";
            this.colSalesResponsable.Visible = true;
            this.colSalesResponsable.VisibleIndex = 6;
            // 
            // colPOperator
            // 
            this.colPOperator.Caption = "Operator";
            this.colPOperator.FieldName = "POperator";
            this.colPOperator.Name = "colPOperator";
            this.colPOperator.Visible = true;
            this.colPOperator.VisibleIndex = 7;
            // 
            // colWareHouse
            // 
            this.colWareHouse.Caption = "WareHouse";
            this.colWareHouse.FieldName = "WareHouse";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.Visible = true;
            this.colWareHouse.VisibleIndex = 8;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "OrderDate";
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 9;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.Caption = "OrderStatus";
            this.colOrderStatus.FieldName = "OrderStatus";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.Visible = true;
            this.colOrderStatus.VisibleIndex = 10;
            // 
            // colAvizNo
            // 
            this.colAvizNo.Caption = "Aviz";
            this.colAvizNo.FieldName = "AvizNo";
            this.colAvizNo.Name = "colAvizNo";
            this.colAvizNo.Visible = true;
            this.colAvizNo.VisibleIndex = 11;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Caption = "Factura";
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CmdCauta
            // 
            this.CmdCauta.Location = new System.Drawing.Point(636, 1);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(140, 28);
            this.CmdCauta.TabIndex = 1;
            this.CmdCauta.Text = "Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Criteriu";
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(71, 6);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(242, 20);
            this.txtSrch.TabIndex = 3;
            // 
            // rbOrder
            // 
            this.rbOrder.AutoSize = true;
            this.rbOrder.Location = new System.Drawing.Point(320, 7);
            this.rbOrder.Name = "rbOrder";
            this.rbOrder.Size = new System.Drawing.Size(70, 17);
            this.rbOrder.TabIndex = 4;
            this.rbOrder.TabStop = true;
            this.rbOrder.Text = "Comanda";
            this.rbOrder.UseVisualStyleBackColor = true;
            // 
            // rbArticle
            // 
            this.rbArticle.AutoSize = true;
            this.rbArticle.Location = new System.Drawing.Point(411, 7);
            this.rbArticle.Name = "rbArticle";
            this.rbArticle.Size = new System.Drawing.Size(54, 17);
            this.rbArticle.TabIndex = 5;
            this.rbArticle.TabStop = true;
            this.rbArticle.Text = "Articol";
            this.rbArticle.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(480, 7);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(87, 17);
            this.rbCustomer.TabIndex = 6;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Cod Partener";
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // CkMonitor
            // 
            this.CkMonitor.AutoSize = true;
            this.CkMonitor.Location = new System.Drawing.Point(72, 30);
            this.CkMonitor.Name = "CkMonitor";
            this.CkMonitor.Size = new System.Drawing.Size(61, 17);
            this.CkMonitor.TabIndex = 7;
            this.CkMonitor.Text = "Monitor";
            this.CkMonitor.UseVisualStyleBackColor = true;
            this.CkMonitor.CheckedChanged += new System.EventHandler(this.CkMonitor_CheckedChanged);
            // 
            // CkDescarcaStoc
            // 
            this.CkDescarcaStoc.AutoSize = true;
            this.CkDescarcaStoc.Location = new System.Drawing.Point(320, 30);
            this.CkDescarcaStoc.Name = "CkDescarcaStoc";
            this.CkDescarcaStoc.Size = new System.Drawing.Size(66, 17);
            this.CkDescarcaStoc.TabIndex = 8;
            this.CkDescarcaStoc.Text = "Terminal";
            this.CkDescarcaStoc.UseVisualStyleBackColor = true;
            this.CkDescarcaStoc.Click += new System.EventHandler(this.CkDescarcaStoc_Click);
            this.CkDescarcaStoc.CheckedChanged += new System.EventHandler(this.CkDescarcaStoc_CheckedChanged);
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 500);
            this.Controls.Add(this.CkDescarcaStoc);
            this.Controls.Add(this.CkMonitor);
            this.Controls.Add(this.rbCustomer);
            this.Controls.Add(this.rbArticle);
            this.Controls.Add(this.rbOrder);
            this.Controls.Add(this.txtSrch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMonitor";
            this.Text = "Monitoring";
            this.Load += new System.EventHandler(this.frmMonitor_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMonitor_FormClosed);
            this.Resize += new System.EventHandler(this.frmMonitor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblDeliveryOrderBindingSource;
        private DataSetMonitor dataSetMonitor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryRoute;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colWareHouse;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderStatus;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.RadioButton rbOrder;
        private System.Windows.Forms.RadioButton rbArticle;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RadioButton rbCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colAvizNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private System.Windows.Forms.CheckBox CkMonitor;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colMyCount;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn colArticleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colArticleDesc1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn colReservedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliverQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCodeStock;
        private DevExpress.XtraGrid.Columns.GridColumn colGoWHClass;
        private DevExpress.XtraGrid.Columns.GridColumn colPOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffItems;
        private DevExpress.XtraGrid.Columns.GridColumn colWH;
        private System.Windows.Forms.CheckBox CkDescarcaStoc;


    }
}