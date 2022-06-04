using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoWHMgmAdmin
{
    public partial class frmShowReport : Form
    {
        public frmShowReport()
        {
            InitializeComponent();
        }
        public void ShowReport(string DateFrom, string DateTo, int rOption, string PartnerName,string ArtCode,string LocSymbol)
        {
            int x = 0;
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
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return; }
            }
            
            this.Cursor = Cursors.WaitCursor;
            //Reports.xtrRptWHInternMove01 mRep = new GoWHMgmAdmin.Reports.xtrRptWHInternMove01();

            Microsoft.Reporting.WinForms.ReportViewer mRep = new Microsoft.Reporting.WinForms.ReportViewer();

            if (rOption == 1)
            {
                ShowReportInternalMove(ref mRep, DateFrom, DateTo);
            }
            else if (rOption == 2)
            {
                ShowReportStock(ref mRep,ArtCode.Trim(),LocSymbol.Trim());     
            }
            mRep.RefreshReport() ;
            mRep.Dock = DockStyle.Fill;
            this.Controls.Add(mRep);
            mRep.Refresh();
            this.Cursor = Cursors.Default;
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();

            mRep = null;  
            this.Cursor = Cursors.Default;

        }
        public void ShowReportStock(ref Microsoft.Reporting.WinForms.ReportViewer mRep,string ArtCode,string LocatorSymbol)
        {
            int x = 0;
            MyGlobal.dsRptStock.EnforceConstraints = false;
            MyGlobal.dsRptStock.Clear();
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("rptShowMeStock");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ArtCode", SqlDbType.NVarChar, ArtCode.Trim().Length));
            mcmd.Parameters["@ArtCode"].Value = ArtCode.Trim();

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LocSymbol", SqlDbType.NVarChar, LocatorSymbol.Trim().Length   ));
            mcmd.Parameters["@LocSymbol"].Value = LocatorSymbol.Trim();
            
            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();

            do
            {
                while (dataread.Read())
                {

                    try
                    {
                        MyGlobal.dsRptStock.tblStock.AddtblStockRow(
                                MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'")                            
                            );    

                    }
                    catch
                    {

                    }
                    finally { MyGlobal.dsRptStock.EnforceConstraints = true; }

                    x++;
                }
            } while (dataread.NextResult());
            if (x > 0)
            {
                mRep.LocalReport.DataSources.Clear();
                mRep.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                mRep.LocalReport.ReportPath = Application.StartupPath + "\\rptStock.rdlc";
                mRep.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsStock_tblStock", MyGlobal.dsRptStock.Tables[0]));

            }
            dataread.Close();
            mcmd = null;

            
        }
        public void ShowReportInternalMove(ref Microsoft.Reporting.WinForms.ReportViewer mRep,string DateFrom, string DateTo)
        {
            int x = 0;
            MyGlobal.dsMRptWHInternMove01.EnforceConstraints = false;
            MyGlobal.dsMRptWHInternMove01.Clear();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("rp_DefragMovement");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", SqlDbType.NVarChar, (DateFrom.Trim() + " 00:00:00").Length));
            mcmd.Parameters["@DateFrom"].Value = DateFrom.Trim() + " 00:00:00";

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTo", SqlDbType.NVarChar, (DateFrom.Trim() + " 00:00:00").Length));
            mcmd.Parameters["@DateTo"].Value = DateTo.Trim() + " 00:00:00";

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();

            do
            {
                while (dataread.Read())
                {

                    try
                    {
                        MyGlobal.dsMRptWHInternMove01.tblRPWHInternMove01.AddtblRPWHInternMove01Row(
                                    MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                    MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'")
                            );
                    }
                    catch
                    {

                    }
                    finally { MyGlobal.dsMRptWHInternMove01.EnforceConstraints = true; }

                    x++;
                }
            } while (dataread.NextResult());
            if (x > 0)
            {
                mRep.LocalReport.DataSources.Clear();
                mRep.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                mRep.LocalReport.ReportPath = Application.StartupPath + "\\rptWHInternMove.rdlc";
                mRep.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsRptWHInternMove01_tblRPWHInternMove01", MyGlobal.dsMRptWHInternMove01.Tables[0]));

            }
            dataread.Close();
            mcmd = null;
        }
        public void ShowReport1(string DateFrom,string DateTo)
        {
            int x = 0;
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
                catch { MessageBox.Show("Nu pot restabili conexiunea", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); GC.Collect(); return; }
            }

            this.Cursor = Cursors.WaitCursor;
            Reports.xtrRptWHInternMove01 mRep = new GoWHMgmAdmin.Reports.xtrRptWHInternMove01();

            mRep.DataSource = mRep.dsRptWHInternMove011;
            mRep.DataMember = mRep.dsRptWHInternMove011.tblRPWHInternMove01.ToString();

            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("rp_DefragMovement");
            mcmd.Connection = MyGlobal.MY_SQL_CON;
            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", SqlDbType.NVarChar, (DateFrom.Trim() + " 00:00:00").Length));
            mcmd.Parameters["@DateFrom"].Value = DateFrom.Trim() + " 00:00:00";

            mcmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTo", SqlDbType.NVarChar, (DateFrom.Trim() + " 00:00:00").Length));
            mcmd.Parameters["@DateTo"].Value = DateTo.Trim() + " 00:00:00";

            mcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();

            do
            {
                while (dataread.Read())
                {

                    mRep.dsRptWHInternMove011.tblRPWHInternMove01.Rows.Add(new object[]{
                                MyGlobal.Srch2Escape(dataread[0].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[1].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[2].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[3].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[4].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[5].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[6].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[7].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[8].ToString().Trim(), "'"),
                                MyGlobal.Srch2Escape(dataread[9].ToString().Trim(), "'")});
                    x++;
                }
            } while (dataread.NextResult());
            if (x > 0)
            {
                
                //mRep.CreateDocument();
                //mRep.ShowPreview();



                /*mRep.Clear();
                mRep.Reset();
                mRep.LocalReport.DataSources.Clear();
                mRep.Proc ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                if (rOption == 1)
                {
                    mrpt.LocalReport.ReportPath = Application.StartupPath + "\\rptPeriod.rdlc";
                    mrpt.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("MyRepo1_mReport", ReportGlobal.MyReport.Tables[0]));
                }
                 */ 
            }

            this.Cursor = Cursors.Default;
            dataread.Close();
            mcmd = null;
        }

        private void frmShowReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MyGlobal.mFrmShowReport = null;  
            }
            catch { }
        }
    }
}
