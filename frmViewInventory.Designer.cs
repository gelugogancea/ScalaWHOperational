namespace GoWHMgmAdmin
{
    partial class frmViewInventory
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblWorkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInventory = new GoWHMgmAdmin.DataSetInventory();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArticleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArticleDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompPlus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompMinus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffAvgCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAVGCostPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.CmdPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAllArticle = new System.Windows.Forms.RadioButton();
            this.rbUnCountArticle = new System.Windows.Forms.RadioButton();
            this.rbCountArticle = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbArticleUnCompensation = new System.Windows.Forms.RadioButton();
            this.rbArticleCompensation = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbValidateArticle = new System.Windows.Forms.RadioButton();
            this.rbUnValidateArticle = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbArticleCodeLikeAll = new System.Windows.Forms.RadioButton();
            this.rbArticleCodeLikeFirst = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbArticleNameLikeAll = new System.Windows.Forms.RadioButton();
            this.rbArticleNameLikeFirst = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbListNo = new System.Windows.Forms.RadioButton();
            this.CkCloseInventory = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbExpHTML = new System.Windows.Forms.RadioButton();
            this.rbExpPDF = new System.Windows.Forms.RadioButton();
            this.rbExpXls = new System.Windows.Forms.RadioButton();
            this.rbExpPrint = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblWorkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CountQty", null, "{0:0.###}")});
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cant.Inventar";
            this.gridColumn1.DisplayFormat.FormatString = "{0:0.###}";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "CountQty";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Numarat";
            this.gridColumn2.DisplayFormat.FormatString = "{0:0.#}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "CountNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Locator";
            this.gridColumn3.FieldName = "Locator";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Zona";
            this.gridColumn4.FieldName = "AreaCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ListNumber";
            this.gridColumn7.FieldName = "ListNumber";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Operator";
            this.gridColumn5.FieldName = "Operator";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Validat";
            this.gridColumn6.FieldName = "IsValidate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblWorkBindingSource;
            this.gridControl1.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "tblWorkDetail";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(25, 113);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(717, 251);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridControl1.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EditorKeyDown);
            // 
            // tblWorkBindingSource
            // 
            this.tblWorkBindingSource.DataMember = "tblWork";
            this.tblWorkBindingSource.DataSource = this.dataSetInventory;
            // 
            // dataSetInventory
            // 
            this.dataSetInventory.DataSetName = "DataSetInventory";
            this.dataSetInventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colWHCode,
            this.colArticleCode,
            this.colArticleDescription,
            this.colInventoryQty,
            this.colStockBalance,
            this.colCompPlus,
            this.colCompMinus,
            this.colDiffQty,
            this.colDiffAvgCost,
            this.colAVGCostPU});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ArticleCode", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InventoryQty", this.colInventoryQty, "{0:0.###}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 63;
            // 
            // colWHCode
            // 
            this.colWHCode.Caption = "Depozit";
            this.colWHCode.FieldName = "WHCode";
            this.colWHCode.Name = "colWHCode";
            this.colWHCode.OptionsColumn.AllowEdit = false;
            this.colWHCode.Visible = true;
            this.colWHCode.VisibleIndex = 1;
            this.colWHCode.Width = 63;
            // 
            // colArticleCode
            // 
            this.colArticleCode.Caption = "Cod Articol";
            this.colArticleCode.FieldName = "ArticleCode";
            this.colArticleCode.Name = "colArticleCode";
            this.colArticleCode.OptionsColumn.AllowEdit = false;
            this.colArticleCode.Visible = true;
            this.colArticleCode.VisibleIndex = 2;
            this.colArticleCode.Width = 88;
            // 
            // colArticleDescription
            // 
            this.colArticleDescription.Caption = "Descriere";
            this.colArticleDescription.FieldName = "ArticleDescription";
            this.colArticleDescription.Name = "colArticleDescription";
            this.colArticleDescription.OptionsColumn.AllowEdit = false;
            this.colArticleDescription.Visible = true;
            this.colArticleDescription.VisibleIndex = 3;
            this.colArticleDescription.Width = 67;
            // 
            // colInventoryQty
            // 
            this.colInventoryQty.Caption = "Cant.Inventar";
            this.colInventoryQty.DisplayFormat.FormatString = "{0:0.###}";
            this.colInventoryQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInventoryQty.FieldName = "InventoryQty";
            this.colInventoryQty.Name = "colInventoryQty";
            this.colInventoryQty.OptionsColumn.AllowEdit = false;
            this.colInventoryQty.Visible = true;
            this.colInventoryQty.VisibleIndex = 4;
            this.colInventoryQty.Width = 57;
            // 
            // colStockBalance
            // 
            this.colStockBalance.Caption = "Stoc.Script";
            this.colStockBalance.DisplayFormat.FormatString = "{0:0.###}";
            this.colStockBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockBalance.FieldName = "StockBalance";
            this.colStockBalance.Name = "colStockBalance";
            this.colStockBalance.OptionsColumn.AllowEdit = false;
            this.colStockBalance.Visible = true;
            this.colStockBalance.VisibleIndex = 5;
            this.colStockBalance.Width = 57;
            // 
            // colCompPlus
            // 
            this.colCompPlus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompPlus.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.colCompPlus.Caption = "C   +";
            this.colCompPlus.DisplayFormat.FormatString = "{0:0.###}";
            this.colCompPlus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCompPlus.FieldName = "CompPlus";
            this.colCompPlus.Name = "colCompPlus";
            this.colCompPlus.OptionsColumn.AllowEdit = false;
            this.colCompPlus.Visible = true;
            this.colCompPlus.VisibleIndex = 6;
            this.colCompPlus.Width = 57;
            // 
            // colCompMinus
            // 
            this.colCompMinus.Caption = "C   -";
            this.colCompMinus.DisplayFormat.FormatString = "{0:0.###}";
            this.colCompMinus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCompMinus.FieldName = "CompMinus";
            this.colCompMinus.Name = "colCompMinus";
            this.colCompMinus.OptionsColumn.AllowEdit = false;
            this.colCompMinus.Visible = true;
            this.colCompMinus.VisibleIndex = 7;
            this.colCompMinus.Width = 57;
            // 
            // colDiffQty
            // 
            this.colDiffQty.Caption = "Cant.Diferenta";
            this.colDiffQty.DisplayFormat.FormatString = "{0:0.###}";
            this.colDiffQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiffQty.FieldName = "DiffQty";
            this.colDiffQty.Name = "colDiffQty";
            this.colDiffQty.OptionsColumn.AllowEdit = false;
            this.colDiffQty.Visible = true;
            this.colDiffQty.VisibleIndex = 8;
            this.colDiffQty.Width = 60;
            // 
            // colDiffAvgCost
            // 
            this.colDiffAvgCost.Caption = "CMP";
            this.colDiffAvgCost.DisplayFormat.FormatString = "{0:0.###}";
            this.colDiffAvgCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiffAvgCost.FieldName = "DiffAvgCost";
            this.colDiffAvgCost.Name = "colDiffAvgCost";
            this.colDiffAvgCost.OptionsColumn.AllowEdit = false;
            this.colDiffAvgCost.Visible = true;
            this.colDiffAvgCost.VisibleIndex = 9;
            this.colDiffAvgCost.Width = 54;
            // 
            // colAVGCostPU
            // 
            this.colAVGCostPU.Caption = "CMP/PU";
            this.colAVGCostPU.DisplayFormat.FormatString = "{0:0.###}";
            this.colAVGCostPU.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAVGCostPU.FieldName = "AVGCostPU";
            this.colAVGCostPU.Name = "colAVGCostPU";
            this.colAVGCostPU.OptionsColumn.AllowEdit = false;
            this.colAVGCostPU.Visible = true;
            this.colAVGCostPU.VisibleIndex = 10;
            this.colAVGCostPU.Width = 73;
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(52, 19);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(132, 20);
            this.txtSrch.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Criteriu";
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(502, 17);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(126, 22);
            this.CmdCauta.TabIndex = 6;
            this.CmdCauta.Text = "Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // CmdPrint
            // 
            this.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPrint.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.CmdPrint.Location = new System.Drawing.Point(634, 17);
            this.CmdPrint.Name = "CmdPrint";
            this.CmdPrint.Size = new System.Drawing.Size(108, 22);
            this.CmdPrint.TabIndex = 13;
            this.CmdPrint.Text = "Export";
            this.CmdPrint.UseVisualStyleBackColor = true;
            this.CmdPrint.Click += new System.EventHandler(this.CmdPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAllArticle);
            this.groupBox1.Controls.Add(this.rbUnCountArticle);
            this.groupBox1.Controls.Add(this.rbCountArticle);
            this.groupBox1.Location = new System.Drawing.Point(190, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 37);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numarate";
            // 
            // rbAllArticle
            // 
            this.rbAllArticle.AutoSize = true;
            this.rbAllArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAllArticle.Location = new System.Drawing.Point(98, 13);
            this.rbAllArticle.Name = "rbAllArticle";
            this.rbAllArticle.Size = new System.Drawing.Size(52, 17);
            this.rbAllArticle.TabIndex = 16;
            this.rbAllArticle.TabStop = true;
            this.rbAllArticle.Text = "Toate";
            this.rbAllArticle.UseVisualStyleBackColor = true;
            this.rbAllArticle.CheckedChanged += new System.EventHandler(this.rbAllArticle_CheckedChanged);
            // 
            // rbUnCountArticle
            // 
            this.rbUnCountArticle.AutoSize = true;
            this.rbUnCountArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbUnCountArticle.Location = new System.Drawing.Point(54, 14);
            this.rbUnCountArticle.Name = "rbUnCountArticle";
            this.rbUnCountArticle.Size = new System.Drawing.Size(38, 17);
            this.rbUnCountArticle.TabIndex = 15;
            this.rbUnCountArticle.TabStop = true;
            this.rbUnCountArticle.Text = "Nu";
            this.rbUnCountArticle.UseVisualStyleBackColor = true;
            this.rbUnCountArticle.CheckedChanged += new System.EventHandler(this.rbUnCountArticle_CheckedChanged);
            // 
            // rbCountArticle
            // 
            this.rbCountArticle.AutoSize = true;
            this.rbCountArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCountArticle.Location = new System.Drawing.Point(10, 14);
            this.rbCountArticle.Name = "rbCountArticle";
            this.rbCountArticle.Size = new System.Drawing.Size(38, 17);
            this.rbCountArticle.TabIndex = 10;
            this.rbCountArticle.TabStop = true;
            this.rbCountArticle.Text = "Da";
            this.rbCountArticle.UseVisualStyleBackColor = true;
            this.rbCountArticle.CheckedChanged += new System.EventHandler(this.rbCountArticle_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbArticleUnCompensation);
            this.groupBox2.Controls.Add(this.rbArticleCompensation);
            this.groupBox2.Location = new System.Drawing.Point(361, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 37);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compensate";
            // 
            // rbArticleUnCompensation
            // 
            this.rbArticleUnCompensation.AutoSize = true;
            this.rbArticleUnCompensation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleUnCompensation.Location = new System.Drawing.Point(51, 15);
            this.rbArticleUnCompensation.Name = "rbArticleUnCompensation";
            this.rbArticleUnCompensation.Size = new System.Drawing.Size(38, 17);
            this.rbArticleUnCompensation.TabIndex = 16;
            this.rbArticleUnCompensation.TabStop = true;
            this.rbArticleUnCompensation.Text = "Nu";
            this.rbArticleUnCompensation.UseVisualStyleBackColor = true;
            this.rbArticleUnCompensation.CheckedChanged += new System.EventHandler(this.rbArticleUnCompensation_CheckedChanged);
            // 
            // rbArticleCompensation
            // 
            this.rbArticleCompensation.AutoSize = true;
            this.rbArticleCompensation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleCompensation.Location = new System.Drawing.Point(6, 15);
            this.rbArticleCompensation.Name = "rbArticleCompensation";
            this.rbArticleCompensation.Size = new System.Drawing.Size(38, 17);
            this.rbArticleCompensation.TabIndex = 12;
            this.rbArticleCompensation.TabStop = true;
            this.rbArticleCompensation.Text = "Da";
            this.rbArticleCompensation.UseVisualStyleBackColor = true;
            this.rbArticleCompensation.CheckedChanged += new System.EventHandler(this.rbArticleCompensation_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbValidateArticle);
            this.groupBox3.Controls.Add(this.rbUnValidateArticle);
            this.groupBox3.Location = new System.Drawing.Point(25, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(98, 37);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Validate";
            this.groupBox3.Visible = false;
            // 
            // rbValidateArticle
            // 
            this.rbValidateArticle.AutoSize = true;
            this.rbValidateArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbValidateArticle.Location = new System.Drawing.Point(6, 15);
            this.rbValidateArticle.Name = "rbValidateArticle";
            this.rbValidateArticle.Size = new System.Drawing.Size(38, 17);
            this.rbValidateArticle.TabIndex = 17;
            this.rbValidateArticle.TabStop = true;
            this.rbValidateArticle.Text = "Da";
            this.rbValidateArticle.UseVisualStyleBackColor = true;
            this.rbValidateArticle.CheckedChanged += new System.EventHandler(this.rbValidateArticle_CheckedChanged);
            // 
            // rbUnValidateArticle
            // 
            this.rbUnValidateArticle.AutoSize = true;
            this.rbUnValidateArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbUnValidateArticle.Location = new System.Drawing.Point(51, 15);
            this.rbUnValidateArticle.Name = "rbUnValidateArticle";
            this.rbUnValidateArticle.Size = new System.Drawing.Size(38, 17);
            this.rbUnValidateArticle.TabIndex = 16;
            this.rbUnValidateArticle.TabStop = true;
            this.rbUnValidateArticle.Text = "Nu";
            this.rbUnValidateArticle.UseVisualStyleBackColor = true;
            this.rbUnValidateArticle.CheckedChanged += new System.EventHandler(this.rbUnValidateArticle_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbArticleCodeLikeAll);
            this.groupBox4.Controls.Add(this.rbArticleCodeLikeFirst);
            this.groupBox4.Location = new System.Drawing.Point(190, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(98, 37);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cod Articol";
            // 
            // rbArticleCodeLikeAll
            // 
            this.rbArticleCodeLikeAll.AutoSize = true;
            this.rbArticleCodeLikeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleCodeLikeAll.Location = new System.Drawing.Point(46, 14);
            this.rbArticleCodeLikeAll.Name = "rbArticleCodeLikeAll";
            this.rbArticleCodeLikeAll.Size = new System.Drawing.Size(45, 17);
            this.rbArticleCodeLikeAll.TabIndex = 15;
            this.rbArticleCodeLikeAll.TabStop = true;
            this.rbArticleCodeLikeAll.Text = "%x%";
            this.rbArticleCodeLikeAll.UseVisualStyleBackColor = true;
            this.rbArticleCodeLikeAll.CheckedChanged += new System.EventHandler(this.rbArticleCodeLikeAll_CheckedChanged);
            // 
            // rbArticleCodeLikeFirst
            // 
            this.rbArticleCodeLikeFirst.AutoSize = true;
            this.rbArticleCodeLikeFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleCodeLikeFirst.Location = new System.Drawing.Point(6, 14);
            this.rbArticleCodeLikeFirst.Name = "rbArticleCodeLikeFirst";
            this.rbArticleCodeLikeFirst.Size = new System.Drawing.Size(37, 17);
            this.rbArticleCodeLikeFirst.TabIndex = 10;
            this.rbArticleCodeLikeFirst.TabStop = true;
            this.rbArticleCodeLikeFirst.Text = "x%";
            this.rbArticleCodeLikeFirst.UseVisualStyleBackColor = true;
            this.rbArticleCodeLikeFirst.CheckedChanged += new System.EventHandler(this.rbArticleCodeLikeFirst_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbArticleNameLikeAll);
            this.groupBox5.Controls.Add(this.rbArticleNameLikeFirst);
            this.groupBox5.Location = new System.Drawing.Point(294, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(98, 37);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Denumire Articol";
            // 
            // rbArticleNameLikeAll
            // 
            this.rbArticleNameLikeAll.AutoSize = true;
            this.rbArticleNameLikeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleNameLikeAll.Location = new System.Drawing.Point(46, 14);
            this.rbArticleNameLikeAll.Name = "rbArticleNameLikeAll";
            this.rbArticleNameLikeAll.Size = new System.Drawing.Size(45, 17);
            this.rbArticleNameLikeAll.TabIndex = 15;
            this.rbArticleNameLikeAll.TabStop = true;
            this.rbArticleNameLikeAll.Text = "%x%";
            this.rbArticleNameLikeAll.UseVisualStyleBackColor = true;
            this.rbArticleNameLikeAll.CheckedChanged += new System.EventHandler(this.rbArticleNameLikeAll_CheckedChanged);
            // 
            // rbArticleNameLikeFirst
            // 
            this.rbArticleNameLikeFirst.AutoSize = true;
            this.rbArticleNameLikeFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbArticleNameLikeFirst.Location = new System.Drawing.Point(6, 14);
            this.rbArticleNameLikeFirst.Name = "rbArticleNameLikeFirst";
            this.rbArticleNameLikeFirst.Size = new System.Drawing.Size(37, 17);
            this.rbArticleNameLikeFirst.TabIndex = 10;
            this.rbArticleNameLikeFirst.TabStop = true;
            this.rbArticleNameLikeFirst.Text = "x%";
            this.rbArticleNameLikeFirst.UseVisualStyleBackColor = true;
            this.rbArticleNameLikeFirst.CheckedChanged += new System.EventHandler(this.rbArticleNameLikeFirst_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbListNo);
            this.groupBox6.Location = new System.Drawing.Point(398, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(98, 37);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Liste";
            // 
            // rbListNo
            // 
            this.rbListNo.AutoSize = true;
            this.rbListNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbListNo.Location = new System.Drawing.Point(6, 15);
            this.rbListNo.Name = "rbListNo";
            this.rbListNo.Size = new System.Drawing.Size(55, 17);
            this.rbListNo.TabIndex = 17;
            this.rbListNo.TabStop = true;
            this.rbListNo.Text = "Numar";
            this.rbListNo.UseVisualStyleBackColor = true;
            this.rbListNo.CheckedChanged += new System.EventHandler(this.rbListNo_CheckedChanged);
            // 
            // CkCloseInventory
            // 
            this.CkCloseInventory.AutoSize = true;
            this.CkCloseInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CkCloseInventory.Location = new System.Drawing.Point(52, 58);
            this.CkCloseInventory.Name = "CkCloseInventory";
            this.CkCloseInventory.Size = new System.Drawing.Size(94, 17);
            this.CkCloseInventory.TabIndex = 23;
            this.CkCloseInventory.Text = "Inchid Inventar";
            this.CkCloseInventory.UseVisualStyleBackColor = true;
            this.CkCloseInventory.Visible = false;
            this.CkCloseInventory.CheckedChanged += new System.EventHandler(this.CkCloseInventory_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbExpHTML);
            this.groupBox7.Controls.Add(this.rbExpPDF);
            this.groupBox7.Controls.Add(this.rbExpXls);
            this.groupBox7.Controls.Add(this.rbExpPrint);
            this.groupBox7.Location = new System.Drawing.Point(502, 45);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(240, 37);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Export Date";
            // 
            // rbExpHTML
            // 
            this.rbExpHTML.AutoSize = true;
            this.rbExpHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExpHTML.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbExpHTML.Location = new System.Drawing.Point(170, 15);
            this.rbExpHTML.Name = "rbExpHTML";
            this.rbExpHTML.Size = new System.Drawing.Size(54, 17);
            this.rbExpHTML.TabIndex = 20;
            this.rbExpHTML.TabStop = true;
            this.rbExpHTML.Text = "HTML";
            this.rbExpHTML.UseVisualStyleBackColor = true;
            // 
            // rbExpPDF
            // 
            this.rbExpPDF.AutoSize = true;
            this.rbExpPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExpPDF.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbExpPDF.Location = new System.Drawing.Point(119, 15);
            this.rbExpPDF.Name = "rbExpPDF";
            this.rbExpPDF.Size = new System.Drawing.Size(45, 17);
            this.rbExpPDF.TabIndex = 19;
            this.rbExpPDF.TabStop = true;
            this.rbExpPDF.Text = "PDF";
            this.rbExpPDF.UseVisualStyleBackColor = true;
            // 
            // rbExpXls
            // 
            this.rbExpXls.AutoSize = true;
            this.rbExpXls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExpXls.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbExpXls.Location = new System.Drawing.Point(63, 15);
            this.rbExpXls.Name = "rbExpXls";
            this.rbExpXls.Size = new System.Drawing.Size(50, 17);
            this.rbExpXls.TabIndex = 18;
            this.rbExpXls.TabStop = true;
            this.rbExpXls.Text = "Excel";
            this.rbExpXls.UseVisualStyleBackColor = true;
            // 
            // rbExpPrint
            // 
            this.rbExpPrint.AutoSize = true;
            this.rbExpPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExpPrint.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbExpPrint.Location = new System.Drawing.Point(6, 15);
            this.rbExpPrint.Name = "rbExpPrint";
            this.rbExpPrint.Size = new System.Drawing.Size(45, 17);
            this.rbExpPrint.TabIndex = 17;
            this.rbExpPrint.TabStop = true;
            this.rbExpPrint.Text = "Print";
            this.rbExpPrint.UseVisualStyleBackColor = true;
            // 
            // frmViewInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 386);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.CkCloseInventory);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmdPrint);
            this.Controls.Add(this.txtSrch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdCauta);
            this.MinimizeBox = false;
            this.Name = "frmViewInventory";
            this.ShowIcon = false;
            this.Text = "Vizualizare Inventar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmViewInventory_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewInventory_FormClosed);
            this.Resize += new System.EventHandler(this.frmViewInventory_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblWorkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdCauta;
        private DataSetInventory dataSetInventory;
        private System.Windows.Forms.Button CmdPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUnCountArticle;
        private System.Windows.Forms.RadioButton rbCountArticle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbArticleUnCompensation;
        private System.Windows.Forms.RadioButton rbArticleCompensation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbValidateArticle;
        private System.Windows.Forms.RadioButton rbUnValidateArticle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbArticleCodeLikeAll;
        private System.Windows.Forms.RadioButton rbArticleCodeLikeFirst;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbArticleNameLikeAll;
        private System.Windows.Forms.RadioButton rbArticleNameLikeFirst;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbListNo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colWHCode;
        private DevExpress.XtraGrid.Columns.GridColumn colArticleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colArticleDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryQty;
        private DevExpress.XtraGrid.Columns.GridColumn colStockBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colCompPlus;
        private DevExpress.XtraGrid.Columns.GridColumn colCompMinus;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffAvgCost;
        private DevExpress.XtraGrid.Columns.GridColumn colAVGCostPU;
        private System.Windows.Forms.BindingSource tblWorkBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.CheckBox CkCloseInventory;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbExpHTML;
        private System.Windows.Forms.RadioButton rbExpPDF;
        private System.Windows.Forms.RadioButton rbExpXls;
        private System.Windows.Forms.RadioButton rbExpPrint;
        private System.Windows.Forms.RadioButton rbAllArticle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}