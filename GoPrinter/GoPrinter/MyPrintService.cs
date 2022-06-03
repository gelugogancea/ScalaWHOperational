using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
            
namespace GoPrinter
{
    
    
    class MyPrintService
    {
        ~MyPrintService(){}
        
        public void ExecJobs()
        {
            
            int i = 0;
            
            if (MyGlobal.I_CAN_STOP == true)
            {
                Thread.CurrentThread.Abort();
            }
            //System.Diagnostics.EventLog.WriteEntry("StartExecJobs","", System.Diagnostics.EventLogEntryType.Error, 101, 7);
            while (true)
            {
                Thread.Sleep(30);
                for (i = 0; i < MyGlobal.MY_JOB_QUE.GetUpperBound(0) + 1; i++)
                {

                    if (MyGlobal.MY_JOB_QUE[i].STATUS_JOB == 1)
                    {
                        lock (MyGlobal.MY_JOB_QUE)
                        {
                           
                                RunPrintProc(MyGlobal.MY_JOB_QUE[i].ORDER_NUMBER);
                                MyGlobal.InitializeJobQue(i);
                           
                            
                        }
                    }
                    else if(MyGlobal.MY_JOB_QUE[i].STATUS_JOB==2)
                    {
                        lock (MyGlobal.MY_JOB_QUE)
                        {
                            RunPrintPackingProc(MyGlobal.MY_JOB_QUE[i].ORDER_NUMBER);
                            MyGlobal.InitializeJobQue(i);
                        }
                    }
                }
            }
        }
        
        private static int RunPrintProc(string OrderNo)
        {
            int mRet = 0;
            int x = 0;
             
            string packserial = "";
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string orderroute = "";
            int packno = 0;
            int totalpack = 0;
            string packtype = "";
            string actorderno = "";
            string customcode = "";
            string customname = "";
            string myuserinfo = "";
            string contactperson = "";
            string eMSG = "";
            
            XtrReport.MyReport mRep = new GoPrinter.XtrReport.MyReport();


            mRep.DataSource = mRep.myDataSet1;
            mRep.DataMember = mRep.myDataSet1.MyTable.ToString();

            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = null;
           

            using (connection = new SqlConnection(MyGlobal.GoWHSQLDBString))
            {
               
                
                try
                {
                    //command = new SqlCommand("ProcDeliveryPrint", connection);
                    //command = new SqlCommand("ProcDeliveryPrint001", connection);
                    command = new SqlCommand("ProcDeliveryPrint003", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNo",System.Data.SqlDbType.NChar, OrderNo.Trim().Length));
                    command.Parameters["@OrderNo"].Value = OrderNo.Trim();

                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", System.Data.SqlDbType.Int));
                    command.Parameters["@MErr"].Direction=System.Data.ParameterDirection.Output;

                    connection.Open();
                    IAsyncResult result = command.BeginExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    int count = 0;
                    while (!result.IsCompleted)
                    {
                        count += 1;
                        System.Threading.Thread.Sleep(100);
                    }
                    using (reader = command.EndExecuteReader(result))
                    {
                        do{
                            while (reader.Read())
                            {
                                
                                packserial = MyGlobal.Srch2Escape(reader[0].ToString().Trim(), "'")+"."+(MyGlobal.Srch2Escape(reader[1].ToString().Trim(), "'"));
                                a1 = MyGlobal.Srch2Escape(reader[2].ToString().Trim(), "'"); 
                                a2 = MyGlobal.Srch2Escape(reader[3].ToString().Trim(), "'"); 
                                a3 = MyGlobal.Srch2Escape(reader[4].ToString().Trim(), "'"); 
                                orderroute = MyGlobal.Srch2Escape(reader[5].ToString().Trim(), "'");
                                packno = int.Parse(MyGlobal.Srch2Escape(reader[6].ToString().Trim(), "'"));
                                totalpack = int.Parse(MyGlobal.Srch2Escape(reader[7].ToString().Trim(), "'")); ;
                                packtype = MyGlobal.Srch2Escape(reader[8].ToString().Trim(), "'");
                                actorderno = MyGlobal.Srch2Escape(reader[9].ToString().Trim(), "'");
                                customcode = MyGlobal.Srch2Escape(reader[10].ToString().Trim(), "'");
                                customname = MyGlobal.Srch2Escape(reader[11].ToString().Trim(), "'");
                                myuserinfo = MyGlobal.Srch2Escape(reader[12].ToString().Trim(), "'");
                                contactperson = MyGlobal.Srch2Escape(reader[13].ToString().Trim(), "'");
                                eMSG = MyGlobal.Srch2Escape(reader[14].ToString().Trim(), "'");
                                //MyPrintForm.MyTable.AddMyTableRow
                                mRep.myDataSet1.MyTable.AddMyTableRow(packserial, a1, a2, a3, orderroute, packno, totalpack, packtype, actorderno, customcode, customname, myuserinfo, contactperson, eMSG);
                                
                                x++;
                                //System.Diagnostics.EventLog.WriteEntry("DBRec",prefix+ " "+packserial.ToString()+" "+a1+" "+a2+" "+a3+" "+orderroute+" "+packno.ToString()+" "+totalpack.ToString()+" "+packtype, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                            }
                        } while (reader.NextResult());
                    }
                    mRet = (int)command.Parameters["@MErr"].Value;
                    if (mRet >= 0 && x>0)   //daca x>0 avem informatii de tiparit,altfel...NU
                    {
                        mRep.CreateDocument();
                        mRep.ClosePreview();
                        mRep.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
                        mRep.PrintingSystem.Print(MyGlobal.MY_PRINTER);
                    }
                    //System.Diagnostics.EventLog.WriteEntry("PrinterName", m.PrinterName, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("SqlException", string.Format("Error ({0}): {1}", ex.Number, ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (InvalidOperationException ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("InvalidOperationException", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("Exception", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                finally
                {
                    reader.Dispose();
                    Thread.Sleep(100);
                    command.Dispose();
                    command = null;
                    connection.Dispose();
                    connection = null;
                    mRep.myDataSet1.Clear();
                    mRep.myDataSet1.Reset();
                    mRep = null;
                }
                
            }
            return mRet;
        }
        private static string GiveMeDefaultPrinter()
        {
            string Pname = "";
            
            System.Drawing.Printing.PrinterSettings m = new System.Drawing.Printing.PrinterSettings();
            
            foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                System.Diagnostics.EventLog.WriteEntry("SrchPrinter",strPrinter , System.Diagnostics.EventLogEntryType.Error, 101, 7);
                if (strPrinter==m.PrinterName)
                {
                    Pname = strPrinter;
                    break;
                }
            }
            
            m = null;
            return Pname;
        }
        private static int RunPrintPackingProc(string ShippCarNo)
        {
            int mRet = 0;
            int x = 0;
            string packserial="";
            string orderno="";
            string orderroute="";
            string customercode="";
            string customername="";
            string deliverytype="";

            XtrReport.rptSerialBox mRep = new GoPrinter.XtrReport.rptSerialBox();
            
            mRep.DataSource = mRep.serialDataSet1;
            mRep.DataMember = mRep.serialDataSet1.tblSerialBox.ToString();

            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = null;

            using (connection = new SqlConnection(MyGlobal.GoWHSQLDBString))
            {


                try
                {
                    command = new SqlCommand("ProcTranspPrint", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ShippingCarNo", System.Data.SqlDbType.NChar, ShippCarNo.Trim().Length));
                    command.Parameters["@ShippingCarNo"].Value = ShippCarNo.Trim();

                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", System.Data.SqlDbType.Int));
                    command.Parameters["@MErr"].Direction = System.Data.ParameterDirection.Output;

                    connection.Open();
                    IAsyncResult result = command.BeginExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    int count = 0;
                    while (!result.IsCompleted)
                    {
                        count += 1;
                        System.Threading.Thread.Sleep(100);
                    }
                    using (reader = command.EndExecuteReader(result))
                    {
                        do
                        {
                            while (reader.Read())
                            {

                                packserial = MyGlobal.Srch2Escape(reader[0].ToString().Trim(), "'");
                                orderno = MyGlobal.Srch2Escape(reader[1].ToString().Trim(), "'");
                                orderroute = MyGlobal.Srch2Escape(reader[2].ToString().Trim(), "'");
                                customercode = MyGlobal.Srch2Escape(reader[3].ToString().Trim(), "'");
                                customername = MyGlobal.Srch2Escape(reader[4].ToString().Trim(), "'");
                                deliverytype = MyGlobal.Srch2Escape(reader[5].ToString().Trim(), "'"); 
                                
                                mRep.serialDataSet1.tblSerialBox.AddtblSerialBoxRow(packserial, orderno, orderroute, customercode, customername, deliverytype, ShippCarNo);
                                x++;
                                //System.Diagnostics.EventLog.WriteEntry("DBRec",prefix+ " "+packserial.ToString()+" "+a1+" "+a2+" "+a3+" "+orderroute+" "+packno.ToString()+" "+totalpack.ToString()+" "+packtype, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                            }
                        } while (reader.NextResult());
                    }
                    mRet = (int)command.Parameters["@MErr"].Value;
                    if (mRet > 0)
                    {
                        mRep.CreateDocument();
                        mRep.ClosePreview();
                        mRep.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
                        mRep.PrintingSystem.Print(MyGlobal.MY_PRINTER);
                    }
                    else
                    {
                        System.Diagnostics.EventLog.WriteEntry("PRINTDELIVERYPROC", "Nu regasesc etichete pt "+ShippCarNo, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                    }
                    //System.Diagnostics.EventLog.WriteEntry("PrinterName", m.PrinterName, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("SqlException", string.Format("Error ({0}): {1}", ex.Number, ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (InvalidOperationException ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("InvalidOperationException", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("Exception", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                finally
                {   
                    reader.Dispose();
                    Thread.Sleep(100);
                    command.Dispose();
                    command = null;
                    connection.Dispose();
                    connection = null;
                    mRep.serialDataSet1.Clear();
                    mRep.serialDataSet1.Reset();
                    mRep = null;
                }

            }
            return mRet;
        }
 
    }
}
