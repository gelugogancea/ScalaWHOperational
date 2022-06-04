namespace GoWHMgmAdmin
{
    partial class frmShowReport
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
            this.dsRptWHInternMove01 = new GoWHMgmAdmin.DataSet.dsRptWHInternMove01();
            this.tblRPWHInternMove01BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsRptWHInternMove01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRPWHInternMove01BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsRptWHInternMove01
            // 
            this.dsRptWHInternMove01.DataSetName = "dsRptWHInternMove01";
            this.dsRptWHInternMove01.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblRPWHInternMove01BindingSource
            // 
            this.tblRPWHInternMove01BindingSource.DataMember = "tblRPWHInternMove01";
            this.tblRPWHInternMove01BindingSource.DataSource = this.dsRptWHInternMove01;
            // 
            // frmShowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 392);
            this.Name = "frmShowReport";
            this.ShowIcon = false;
            this.Text = "Show Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShowReport_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dsRptWHInternMove01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRPWHInternMove01BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GoWHMgmAdmin.DataSet.dsRptWHInternMove01 dsRptWHInternMove01;
        private System.Windows.Forms.BindingSource tblRPWHInternMove01BindingSource;

    }
}