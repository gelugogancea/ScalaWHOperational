using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
namespace GoPrinter
{
    class GoPrinterServer
    {
        public  Socket MY_SOCKET = null;
        private byte[] incomingBuffer = new Byte[256];
        private MyGlobal.MY_PROTOCOL_DATA MY_PROTO_DATA;
        
        //private string MY_CON_STRING="";
        ~GoPrinterServer(){}
        public void StartChild()
        {
            int myjobid = 0;
            int mRet = 0;
            int RetDBFunc = 0;
            Byte[] time;
            string msg = "";
            string msg2send = "";
            int bytesRead=0;
          
            InitializeProto();
            
            while (true)
            {
                Thread.Sleep(100);
                  
                if (MyGlobal.I_CAN_STOP == true)
                {
                    break;
                }
                try
                {
                    bytesRead = MY_SOCKET.Receive(incomingBuffer);
                }
                catch (Exception mkl)
                {
                     System.Diagnostics.EventLog.WriteEntry("SOCKET - OUT THREAD",mkl.Message, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                     break; /*aici trebuie sa ies din thread pentru ca socket-ul oricum se inchide*/
                }
                if (bytesRead > 0)
                {
                    
                    msg = Encoding.ASCII.GetString(incomingBuffer, 0, bytesRead).Trim() ;
                    mRet=SplitChar4Str(msg);
                    
                    if (mRet == 0)
                    {
                        
                        if(MY_PROTO_DATA.CMD_USER==(long)GO_PRINTER_CMD.GO_PRINT_CONNECT)
                        {
                            MyGlobal.MY_CLIENT_USERNAME = new string('0', 32);   
                            RetDBFunc=RunCommandAsynchronously("select go_users_Def.ID from go_users_Def where go_users_Def.ID=" + MY_PROTO_DATA.SID_USER.ToString() + " and getdate() between go_users_def.ValidFrom and go_users_def.ValidTo;", MyGlobal.GoWHSQLDBString);
                            //RetDBFunc=MyDBConnection(MY_PROTO_DATA.SID_USER);
                                if (RetDBFunc < 0)
                                {
                                    System.Diagnostics.EventLog.WriteEntry("FAIL_AUTH", MY_PROTO_DATA.SID_USER.ToString() + " " + MY_PROTO_DATA.CMD_USER.ToString() + " " + MY_PROTO_DATA.CMD_DATA + " " + MY_PROTO_DATA.CMD_ERR.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                                    MY_PROTO_DATA.CMD_ERR = RetDBFunc;
                                    msg2send = MY_PROTO_DATA.SID_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_DATA + MyGlobal.MY_FIELDS + System.Convert.ToString(MY_PROTO_DATA.CMD_ERR) + MyGlobal.MY_TERMINATOR;
                                    time = Encoding.ASCII.GetBytes(msg2send.ToCharArray());
                                    MY_SOCKET.Send(time);
                                    break;
                                }
                                else
                                {
                                    MyGlobal.MY_CLIENT_USERNAME = null;
                                    MY_PROTO_DATA.CMD_ERR = 65535;
                                    GC.Collect(); 
                                    
                                }
                        }
                        else if(MY_PROTO_DATA.CMD_USER==(long)GO_PRINTER_CMD.GO_PRINT_PRINT)
                        {
                            lock (MyGlobal.MY_JOB_QUE)
                            {
                                myjobid=MyGlobal.GiveMeAvailableJobID();
                                MyGlobal.MY_JOB_QUE[myjobid - 1].ID_JOB = myjobid;
                                MyGlobal.MY_JOB_QUE[myjobid - 1].ORDER_NUMBER = MY_PROTO_DATA.CMD_DATA.Trim();
                                MyGlobal.MY_JOB_QUE[myjobid - 1].STATUS_JOB = 1;    //wait for execute this job
                                //System.Diagnostics.EventLog.WriteEntry("CMD_USER=2Jobs", MyGlobal.MY_JOB_QUE[myjobid - 1].ID_JOB.ToString() + " " + MyGlobal.MY_JOB_QUE[myjobid - 1].ORDER_NUMBER + " " + MyGlobal.MY_JOB_QUE[myjobid - 1].STATUS_JOB.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7); 
                             
                            }
                            //System.Diagnostics.EventLog.WriteEntry("CMD_USER=2", MY_PROTO_DATA.SID_USER.ToString() + " " + MY_PROTO_DATA.CMD_USER.ToString() + " " + MY_PROTO_DATA.CMD_DATA + " " + MY_PROTO_DATA.CMD_ERR.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7); 
                        }
                        else if(MY_PROTO_DATA.CMD_USER==(long)GO_PRINTER_CMD.GO_PRINT_AGAIN)
                        {
                            //System.Diagnostics.EventLog.WriteEntry("CMD_USER=3", MY_PROTO_DATA.SID_USER.ToString() + " " + MY_PROTO_DATA.CMD_USER.ToString() + " " + MY_PROTO_DATA.CMD_DATA + " " + MY_PROTO_DATA.CMD_ERR.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7); 
                        }
                        else if(MY_PROTO_DATA.CMD_USER==(long)GO_PRINTER_CMD.GO_PRINT_CLOSE)
                        {
                            msg2send = msg2send = MY_PROTO_DATA.SID_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_DATA + MyGlobal.MY_FIELDS + System.Convert.ToString(MY_PROTO_DATA.CMD_ERR) + MyGlobal.MY_TERMINATOR; ;
                            time = Encoding.ASCII.GetBytes(msg2send.ToCharArray());
                            MY_SOCKET.Send(time);
                            //System.Diagnostics.EventLog.WriteEntry("CMD_USER=4", MY_PROTO_DATA.SID_USER.ToString() + " " + MY_PROTO_DATA.CMD_USER.ToString() + " " + MY_PROTO_DATA.CMD_DATA + " " + MY_PROTO_DATA.CMD_ERR.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7); 
                            goto MY_END;

                        }
                        else if(MY_PROTO_DATA.CMD_USER==(long)GO_PRINTER_CMD.GO_PRINT_PACKINGLIST)
                        {
                            lock (MyGlobal.MY_JOB_QUE)
                            {
                                myjobid = MyGlobal.GiveMeAvailableJobID();
                                MyGlobal.MY_JOB_QUE[myjobid - 1].ID_JOB = myjobid;
                                MyGlobal.MY_JOB_QUE[myjobid - 1].ORDER_NUMBER = MY_PROTO_DATA.CMD_DATA.Trim();
                                MyGlobal.MY_JOB_QUE[myjobid - 1].STATUS_JOB = 2;    //wait for execute this job
                             }
                        }
                        msg2send = MY_PROTO_DATA.SID_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_USER.ToString() + MyGlobal.MY_FIELDS + MY_PROTO_DATA.CMD_DATA + MyGlobal.MY_FIELDS + System.Convert.ToString(MY_PROTO_DATA.CMD_ERR) + MyGlobal.MY_TERMINATOR;
                        time = Encoding.ASCII.GetBytes(msg2send.ToCharArray());
                        //System.Diagnostics.EventLog.WriteEntry("SEND", msg2send, System.Diagnostics.EventLogEntryType.Error, 101, 7); 
                        MY_SOCKET.Send(time);
                        InitializeBuffer();
                        InitializeProto();
                        bytesRead = 0;
                        msg = "";
                        
                    }
                    else
                    {
                        msg2send = "GoPrinterService\r\nFssss....";
                        time = Encoding.ASCII.GetBytes(msg2send.ToCharArray());
                        MY_SOCKET.Send(time);
                        break;
                        
                    }
                }
            
            }
            
                msg = "";
            
                incomingBuffer = null;
 
  MY_END:
            try
                {
                    MY_SOCKET.Blocking = false;
                }
                catch { 
                }
                try
                {
                    MyGlobal.MY_CLIENT_USERNAME = null;
                    MY_SOCKET.Disconnect(false);
                    MY_SOCKET.Close();

                }
                catch { }
                finally { MY_SOCKET = null; }
                
            
           
            GC.Collect();
            //System.Diagnostics.EventLog.WriteEntry("FinishThread", "Curent Thread : " + Thread.CurrentThread.ManagedThreadId.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                        
            Thread.CurrentThread.Abort();
            

        }
        private void InitializeBuffer()
        {
            int i = 0;
            for (i = 0; i < 256;i++ )
            {
                incomingBuffer[i] = 0;
            }
        }
        private void InitializeProto()
        {
            MY_PROTO_DATA.SID_USER = -1;
            MY_PROTO_DATA.CMD_USER = -1;
            MY_PROTO_DATA.CMD_DATA = "";
            MY_PROTO_DATA.CMD_ERR = -32000;
        }
        private int SplitChar4Str(string mData)
        {
            int x = 0;
            int x1 = 0;
            string tmp = "";
            string tmp1 = "";
            string newstr = "";
            int mCount = 0;
            int mRet = 0;
            tmp1 = mData;

            //System.Diagnostics.EventLog.WriteEntry("Split", mData.Trim(), System.Diagnostics.EventLogEntryType.Error, 101, 7);
            x1 = tmp1.IndexOf(MyGlobal.MY_TERMINATOR);
            if (x1 == -1)
            {
                mRet = -500;  /*nu gasesc caracterul terminator,am iesit*/
                return mRet;
            }
            tmp = tmp1.Substring(0, x1);

            do
            {
                x = tmp.IndexOf(MyGlobal.MY_FIELDS);
                if (x != -1)
                {
                    if (x > 0)
                    {
                        newstr = tmp.Substring(0, x);
                    }
                    tmp = tmp.Substring(x + 1, tmp.Length - (x + 1));
                }
                else
                {
                    newstr = tmp;
                }
                switch (mCount)
                {
                    case 0:
                        try
                        {
                            this.MY_PROTO_DATA.SID_USER = long.Parse(newstr.Trim());
                        }
                        catch { mRet = -100; }
                        break;
                    case 1:
                        try
                        {
                            
                            this.MY_PROTO_DATA.CMD_USER = long.Parse(newstr.Trim());
                            
                        }
                        catch { mRet = -200; }
                        break;
                    case 2:
                        try
                        {
                            this.MY_PROTO_DATA.CMD_DATA = newstr.Trim();
                            
                        }
                        catch
                        {
                            mRet = -300;
                        }
                        break;
                    case 3:
                        try
                        {
                            this.MY_PROTO_DATA.CMD_ERR = int.Parse(newstr.Trim());
                        }
                        catch
                        {
                            mRet = -400;
                        }
                        break;
                    default:
                        break;
                }
                if (mRet < 0)
                {
                    break;
                }
                mCount++;

                newstr = "";
            } while (x > -1);
            if (mCount < 4)
            {
                mRet = -600;  /*Protocol incomplet*/
            }
            return mRet;
        }
        /*
        private static int MyDBConnection(long id_user)
        {
            int mRet = 0;
            int x = 0;
            string mq = "";

            MY_SQL_CON = new System.Data.SqlClient.SqlConnection(MyGlobal.GoWHSQLDBString);
            
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand("select go_users_Def.ID from go_users_Def where go_users_Def.ID=" + id_user.ToString().Trim() + " and getdate() between go_users_def.ValidFrom and go_users_def.ValidTo;");
            mcmd.Connection = MY_SQL_CON;
            try
            {
                MY_SQL_CON.Open();

            }
            catch
            {
                System.Diagnostics.EventLog.WriteEntry("SQL_CONNECTION", "Nu ma pot conecta la SQL Server", System.Diagnostics.EventLogEntryType.Error, 101, 7);
                return -1;
            }

            IAsyncResult iresult = mcmd.BeginExecuteReader();
            mcmd.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlDataReader dataread = mcmd.ExecuteReader();
            
            while (!iresult.IsCompleted)
            {
                System.Threading.Thread.Sleep(100);
            }

            using (dataread = mcmd.EndExecuteReader(iresult))
            {
                while (dataread.Read())
                {
                    if (x == 0)
                    {
                        try
                        {
                            mRet = int.Parse(dataread[0].ToString().Trim());
                        }
                        catch { mRet = -20; break; }
                    }

                    x++;

                }
                if (x == 0)
                {
                    mRet = -30;//user invalid    
                }
                else
                {
                    mRet = 1;
                }
            }
            dataread.Close();
            mcmd.Connection.Close();
           
            mcmd = null;
            dataread = null;
            
            return mRet;

        }
         */
        private static int RunCommandAsynchronously(string commandText, string connectionString)
        {
            int mRet = 0;
            int x = 0;
            SqlDataReader reader = null;
            SqlCommand command = null;
            SqlConnection connection = null;
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    command = new SqlCommand(commandText, connection);

                    connection.Open();
                    IAsyncResult result = command.BeginExecuteReader(System.Data.CommandBehavior.CloseConnection);


                    int count = 0;
                    while (!result.IsCompleted)
                    {
                        count += 1;
                        Console.WriteLine("Waiting ({0})", count);
                        System.Threading.Thread.Sleep(100);
                    }

                    using (reader = command.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            if (x == 0)
                            {
                                try
                                {
                                    mRet = int.Parse(reader[0].ToString().Trim());
                                }
                                catch { mRet = -20; break; }
                            }
                            x++;

                        }
                        if (x == 0)
                        {
                            mRet = -30;//user invalid    
                        }
                        else
                        {
                            mRet = 1;
                        }
                    }
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
                     
                }
                return mRet;
            }
        }
    }
    
}
