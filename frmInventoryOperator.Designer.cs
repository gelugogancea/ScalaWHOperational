namespace GoWHMgmAdmin
{
    partial class frmInventoryOperator
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
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblInventoryListOperatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInventoryList = new GoWHMgmAdmin.DataSet.dsInventoryList();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CmbCountOper = new GoWHMgmAdmin.MultiColumnComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtListNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmdCauta = new System.Windows.Forms.Button();
            this.CmdExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryListOperatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInventoryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.gridControl1.DataSource = this.tblInventoryListOperatorBindingSource;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(12, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(804, 470);
            this.gridControl1.TabIndex = 23;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.gridControl1.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EditorKeyDown);
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // tblInventoryListOperatorBindingSource
            // 
            this.tblInventoryListOperatorBindingSource.DataMember = "tblInventoryListOperator";
            this.tblInventoryListOperatorBindingSource.DataSource = this.dsInventoryList;
            // 
            // dsInventoryList
            // 
            this.dsInventoryList.DataSetName = "dsInventoryList";
            this.dsInventoryList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyStock,
            this.colDescription,
            this.colQty,
            this.colLocator,
            this.colValidQty});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ArticleCode", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InventoryQty", null, "{0:0.###}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            // 
            // colKeyStock
            // 
            this.colKeyStock.Caption = "KeyStock";
            this.colKeyStock.FieldName = "KeyStock";
            this.colKeyStock.MinWidth = 100;
            this.colKeyStock.Name = "colKeyStock";
            this.colKeyStock.OptionsColumn.AllowEdit = false;
            this.colKeyStock.Visible = true;
            this.colKeyStock.VisibleIndex = 0;
            this.colKeyStock.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colQty
            // 
            this.colQty.Caption = "Qty";
            this.colQty.FieldName = "Qty";
            this.colQty.MinWidth = 10;
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            // 
            // colLocator
            // 
            this.colLocator.Caption = "Locator";
            this.colLocator.FieldName = "Locator";
            this.colLocator.Name = "colLocator";
            this.colLocator.OptionsColumn.AllowEdit = false;
            this.colLocator.Visible = true;
            this.colLocator.VisibleIndex = 3;
            // 
            // colValidQty
            // 
            this.colValidQty.Caption = "ValidQty";
            this.colValidQty.FieldName = "ValidQty";
            this.colValidQty.Name = "colValidQty";
            this.colValidQty.OptionsColumn.AllowEdit = false;
            this.colValidQty.Visible = true;
            this.colValidQty.VisibleIndex = 4;
            // 
            // CmbCountOper
            // 
            this.CmbCountOper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCountOper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CmbCountOper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbCountOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbCountOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbCountOper.FormattingEnabled = true;
            this.CmbCountOper.Location = new System.Drawing.Point(192, 12);
            this.CmbCountOper.Name = "CmbCountOper";
            this.CmbCountOper.Size = new System.Drawing.Size(168, 21);
            this.CmbCountOper.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Operator";
            // 
            // txtListNo
            // 
            this.txtListNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtListNo.Location = new System.Drawing.Point(65, 12);
            this.txtListNo.Name = "txtListNo";
            this.txtListNo.Size = new System.Drawing.Size(43, 20);
            this.txtListNo.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Nr.Lista";
            // 
            // CmdCauta
            // 
            this.CmdCauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCauta.Location = new System.Drawing.Point(725, 10);
            this.CmdCauta.Name = "CmdCauta";
            this.CmdCauta.Size = new System.Drawing.Size(91, 25);
            this.CmdCauta.TabIndex = 62;
            this.CmdCauta.Text = "&Cauta";
            this.CmdCauta.UseVisualStyleBackColor = true;
            this.CmdCauta.Click += new System.EventHandler(this.CmdCauta_Click);
            // 
            // CmdExit
            // 
            this.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdExit.Location = new System.Drawing.Point(701, 517);
            this.CmdExit.Name = "CmdExit";
            this.CmdExit.Size = new System.Drawing.Size(115, 23);
            this.CmdExit.TabIndex = 87;
            this.CmdExit.Text = "Exit";
            this.CmdExit.UseVisualStyleBackColor = true;
            this.CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
            // 
            // frmInventoryOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 552);
            this.Controls.Add(this.CmdExit);
            this.Controls.Add(this.CmdCauta);
            this.Controls.Add(this.txtListNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbCountOper);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.Name = "frmInventoryOperator";
            this.ShowIcon = false;
            this.Text = "Inventory - Report Qty";
            this.Load += new System.EventHandler(this.frmInventoryOperator_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryOperator_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInventoryListOperatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInventoryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource tblInventoryListOperatorBindingSource;
        private GoWHMgmAdmin.DataSet.dsInventoryList dsInventoryList;
        private MultiColumnComboBox CmbCountOper;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtListNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CmdCauta;
        private System.Windows.Forms.Button CmdExit;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyStock;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colLocator;
        private DevExpress.XtraGrid.Columns.GridColumn colValidQty;
    }
}