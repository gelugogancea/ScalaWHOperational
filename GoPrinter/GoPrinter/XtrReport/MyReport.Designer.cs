namespace GoPrinter.XtrReport
{
    partial class MyReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.EAN128Generator eaN128Generator1 = new DevExpress.XtraPrinting.BarCode.EAN128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPC = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrTypePack = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalPack = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPackNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrOrderRoute = new DevExpress.XtraReports.UI.XRLabel();
            this.xrAddr3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrAddr2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrAddr1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.myDataSet1 = new GoPrinter.DataSet.MyDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrPC,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLine3,
            this.xrLabel4,
            this.xrLine2,
            this.xrPictureBox1,
            this.xrLabel1,
            this.xrLabel2,
            this.xrBarCode1,
            this.xrTypePack,
            this.xrTotalPack,
            this.xrPackNo,
            this.xrOrderRoute,
            this.xrAddr3,
            this.xrAddr2,
            this.xrAddr1,
            this.xrLabel8});
            this.Detail.Height = 404;
            this.Detail.Name = "Detail";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.eMSG", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.Location = new System.Drawing.Point(6, 100);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(406, 25);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrPC
            // 
            this.xrPC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.PC", "")});
            this.xrPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPC.Location = new System.Drawing.Point(12, 275);
            this.xrPC.Name = "xrPC";
            this.xrPC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPC.ParentStyleUsing.UseFont = false;
            this.xrPC.Size = new System.Drawing.Size(469, 25);
            this.xrPC.Text = "xrPC";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.UserName", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.Location = new System.Drawing.Point(438, 344);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(212, 25);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.OrderNo", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(350, 6);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(288, 56);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine3
            // 
            this.xrLine3.Location = new System.Drawing.Point(6, 369);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(642, 8);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Location = new System.Drawing.Point(6, 381);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(638, 19);
            this.xrLabel4.Text = "WareHouse Management System-GoNET Software   www.gonetsoftware.com ;   support@go" +
                "netsoftware.com";
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(0, 300);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(650, 6);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Location = new System.Drawing.Point(12, 6);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(325, 94);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(562, 188);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(25, 94);
            this.xrLabel1.Text = "/";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.CustomCode", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(412, 94);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(225, 31);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.PackSerial", "")});
            this.xrBarCode1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrBarCode1.Location = new System.Drawing.Point(6, 312);
            this.xrBarCode1.Module = 1F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.PaddingInfo = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.ParentStyleUsing.UseFont = false;
            this.xrBarCode1.Size = new System.Drawing.Size(431, 50);
            this.xrBarCode1.Symbology = eaN128Generator1;
            // 
            // xrTypePack
            // 
            this.xrTypePack.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.TypePack", "")});
            this.xrTypePack.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTypePack.Location = new System.Drawing.Point(438, 312);
            this.xrTypePack.Name = "xrTypePack";
            this.xrTypePack.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTypePack.ParentStyleUsing.UseFont = false;
            this.xrTypePack.Size = new System.Drawing.Size(206, 31);
            this.xrTypePack.Text = "xrTypePack";
            // 
            // xrTotalPack
            // 
            this.xrTotalPack.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.TotalPack", "")});
            this.xrTotalPack.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTotalPack.Location = new System.Drawing.Point(588, 188);
            this.xrTotalPack.Name = "xrTotalPack";
            this.xrTotalPack.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTotalPack.ParentStyleUsing.UseFont = false;
            this.xrTotalPack.Size = new System.Drawing.Size(62, 112);
            this.xrTotalPack.Text = "[1]";
            // 
            // xrPackNo
            // 
            this.xrPackNo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.PackNo", "")});
            this.xrPackNo.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPackNo.Location = new System.Drawing.Point(488, 188);
            this.xrPackNo.Name = "xrPackNo";
            this.xrPackNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPackNo.ParentStyleUsing.UseFont = false;
            this.xrPackNo.Size = new System.Drawing.Size(79, 112);
            this.xrPackNo.Text = "xrPackNo";
            // 
            // xrOrderRoute
            // 
            this.xrOrderRoute.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.OrderRoute", "")});
            this.xrOrderRoute.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrOrderRoute.Location = new System.Drawing.Point(350, 62);
            this.xrOrderRoute.Name = "xrOrderRoute";
            this.xrOrderRoute.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrOrderRoute.ParentStyleUsing.UseFont = false;
            this.xrOrderRoute.Size = new System.Drawing.Size(294, 25);
            this.xrOrderRoute.Text = "xrOrderRoute";
            this.xrOrderRoute.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrAddr3
            // 
            this.xrAddr3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.ADDR3", "{0}")});
            this.xrAddr3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrAddr3.Location = new System.Drawing.Point(6, 244);
            this.xrAddr3.Name = "xrAddr3";
            this.xrAddr3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrAddr3.ParentStyleUsing.UseFont = false;
            this.xrAddr3.Size = new System.Drawing.Size(475, 25);
            this.xrAddr3.Text = "xrAddr3";
            // 
            // xrAddr2
            // 
            this.xrAddr2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.ADDR2", "{0}")});
            this.xrAddr2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrAddr2.Location = new System.Drawing.Point(6, 213);
            this.xrAddr2.Name = "xrAddr2";
            this.xrAddr2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrAddr2.ParentStyleUsing.UseFont = false;
            this.xrAddr2.Size = new System.Drawing.Size(475, 25);
            this.xrAddr2.Text = "xrAddr2";
            // 
            // xrAddr1
            // 
            this.xrAddr1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.ADDR1", "{0}")});
            this.xrAddr1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrAddr1.Location = new System.Drawing.Point(6, 188);
            this.xrAddr1.Name = "xrAddr1";
            this.xrAddr1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrAddr1.ParentStyleUsing.UseFont = false;
            this.xrAddr1.Size = new System.Drawing.Size(475, 25);
            this.xrAddr1.Text = "xrAddr1";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MyTable.CustomName", "")});
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.Location = new System.Drawing.Point(6, 125);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(633, 62);
            // 
            // myDataSet1
            // 
            this.myDataSet1.DataSetName = "MyDataSet";
            this.myDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MyReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.DataMember = "MyTable";
            this.DataSource = this.myDataSet1;
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        public GoPrinter.DataSet.MyDataSet myDataSet1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrTypePack;
        private DevExpress.XtraReports.UI.XRLabel xrTotalPack;
        private DevExpress.XtraReports.UI.XRLabel xrPackNo;
        private DevExpress.XtraReports.UI.XRLabel xrOrderRoute;
        private DevExpress.XtraReports.UI.XRLabel xrAddr3;
        private DevExpress.XtraReports.UI.XRLabel xrAddr2;
        private DevExpress.XtraReports.UI.XRLabel xrAddr1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrPC;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        
    }
}
