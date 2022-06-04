using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using SqlClientDll = System.Data.SqlClient;

namespace GoWHMgmAdmin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "")
            {
                MessageBox.Show("Nu exista nume utilizator");
                return;
            }
            MyLogin(this.txtUser.Text.Trim(), this.txtPasswd.Text.Trim());
        }
        private int MyLogin(string sUser, string sPasswd)
        {
       
            string[][] mm = new string[4][];
            mm[0] = new string[1];
            mm[1] = new string[1];
            mm[2] = new string[1];
            mm[3] = new string[1];
            string mq = "";
            int x = 0;
            try
			{
				MyGlobal.MY_SQL_CON.Open();
				
			}
			catch(Exception mex){
                string zzz = mex.Message.ToString();  
                MessageBox.Show("Nu ma pot conecta la " + CryptorEngine.Decrypt(MyGlobal.MY_MSSQL_IP.Trim(), true), "GoWHManagementAdmin");
                MyGlobal.MY_SQL_CON.Close();
                return 0;
			}
            System.Data.SqlClient.SqlCommand mcmd = new System.Data.SqlClient.SqlCommand();
			mcmd.Connection = MyGlobal.MY_SQL_CON;
            /*
            mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName,go_users_Def.RealSurname, ";
            mq +="go_users_Def.RoleInOrg,go_users_Def.AccessLevel,go_functions_def.SYM_FUNC, ";
            mq +="go_functions_def.GROUP_FUNC,go_functions_def.MODULE,go_functions_def.FUNC_DESCR ";
            mq +="from go_users_Def,go_functions_def,go_functions_access ";
            mq +="where go_users_def.UserID='"+sUser.Trim()+"' and go_users_def.Passwd='"+sPasswd.Trim()+"' ";
            mq +="and go_users_def.ID=go_functions_access.IDUSER ";
            mq+="and getdate() between go_users_def.ValidFrom and go_users_def.ValidTo ";
            mq+="and getdate() between go_functions_def.ValidFrom and go_functions_def.ValidTo ";
            mq+="and getdate() between go_functions_access.ValidFrom and go_functions_access.ValidTo ";
            mq+="and go_functions_access.IDFUNC=go_functions_def.ID ";
            mq+="order by go_functions_def.MODULE,go_functions_def.GROUP_FUNC;";
            */
            mq = "select go_users_Def.ID,go_users_Def.UserID,go_users_Def.RealName,go_users_Def.RealSurname, ";
            mq += "go_users_Def.RoleInOrg,go_users_Def.AccessLevel,go_functions_def.SYM_FUNC, ";
            mq += "go_functions_def.GROUP_FUNC,go_functions_def.MODULE,go_functions_def.FUNC_DESCR ";
            mq += "from go_users_Def,go_functions_def,go_functions_access ";
            mq += "where go_users_def.UserID='" + sUser.Trim() + "' and go_users_def.Passwd='" + sPasswd.Trim() + "' ";
            mq += "and go_users_def.ID=go_functions_access.IDUSER ";
            mq += "and getdate() between go_users_def.ValidFrom and go_users_def.ValidTo ";
            mq += "and getdate() between go_functions_def.ValidFrom and go_functions_def.ValidTo ";
            mq += "and getdate() between go_functions_access.ValidFrom and go_functions_access.ValidTo ";
            mq += "and go_functions_access.IDFUNC=go_functions_def.ID and go_functions_def.SCOPE>0";
            mq += " order by go_functions_def.MODULE,go_functions_def.GROUP_FUNC;";

            mcmd.CommandText = mq;
			mcmd.CommandType = System.Data.CommandType.Text;
			System.Data.SqlClient.SqlDataReader dataread =mcmd.ExecuteReader();

            while (dataread.Read())
            {
                if (x == 0)
                {
                    try
                    {
                        MyGlobal.MyUserInfo.MyID = long.Parse(dataread[0].ToString().Trim());
                    }
                    catch { MessageBox.Show("IDUSER este invalid.", "GoWHManagementAdmin"); return 0; }
                    MyGlobal.MyUserInfo.MyUser = dataread[1].ToString();
                    MyGlobal.MyUserInfo.MyRealName = dataread[2].ToString();
                    MyGlobal.MyUserInfo.MyRealSurName = dataread[3].ToString();
                    MyGlobal.MyUserInfo.MyOrgRole = dataread[4].ToString();
                    try
                    {
                        MyGlobal.MyUserInfo.MyAccessLevel = long.Parse(dataread[5].ToString().Trim());
                    }
                    catch { MessageBox.Show("ACCESS_LEVEL este invalid.", "GoWHManagementAdmin"); return 0; }
                }


                mm[0][x] = dataread[8].ToString();
                mm[1][x] = dataread [7].ToString();
                mm[2][x] = dataread[6].ToString();
                mm[3][x] = dataread [9].ToString();
                x++;
                mm[0] = (string[])MyGlobal.ResizeArray(mm[0], mm[0].GetUpperBound(0) + 2);
                mm[1] = (string[])MyGlobal.ResizeArray(mm[1], mm[1].GetUpperBound(0) + 2);
                mm[2] = (string[])MyGlobal.ResizeArray(mm[2], mm[2].GetUpperBound(0) + 2);
                mm[3] = (string[])MyGlobal.ResizeArray(mm[3], mm[3].GetUpperBound(0) + 2);

            }
            if (x == 0)
            {
                MessageBox.Show("User/Parola incorecta sau ati lansat inca o sesiune a acestei aplicatii.", "GoWHManagementAdmin");
                MyGlobal.MY_SQL_CON.Close();
            }
            else
            {
                mRegistry mreg = new mRegistry();
                if (mreg.CreateValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MyUSER", sUser.Trim()) == false)
                {
                    MessageBox.Show("Nu pot salva USER in registry.", "GoWHManagamenetAdmin");
                    
                }
                mreg = null; 
                MyGlobal.mFrmLog.Hide();
                frmMain kk = new frmMain();
                kk.LoadTreeView(mm);
                kk.Show();
            }
            dataread.Close();
            mcmd = null;
            return 1;
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            try
            {
                MyGlobal.MY_SQL_CON.Close();
                MyGlobal.MY_SCALA_CON.Close();
                MyGlobal.mFrmLog.Close();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
             mRegistry mreg = new mRegistry();

             try
             {
                 this.txtUser.Text = mreg.QueryValue(ERegistryPossibleRoots.HKEY_LOCALE_MACHINE, "Software\\GoNET\\GoWHAdmin", "MyUSER", "");
                 if (txtUser.Text.Trim() != "")
                 {
                     this.txtPasswd.Focus();
                     txtPasswd.Text = "";
                 }
             }
             finally
             {
                 mreg = null;
             }

        }
        private static int RunPrintProc(string OrderNo)
        {
            int mRet = 0;
            int x = 0;
            string prefix = "";
            long packserial = 0;
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string orderroute = "";
            int packno = 0;
            int totalpack = 0;
            string packtype = "";

            System.Data.SqlClient.SqlDataReader reader = null;
            System.Data.SqlClient.SqlCommand command = null;
            System.Data.SqlClient.SqlConnection connection = null;

            using (connection = new System.Data.SqlClient.SqlConnection(MyGlobal.GoWHSQLDBString))
            {
                System.Diagnostics.EventLog.WriteEntry("InFunction", OrderNo + " " + OrderNo.Length.ToString(), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                try
                {
                    command = new System.Data.SqlClient.SqlCommand("ProcDeliveryPrint", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNo", System.Data.SqlDbType.NChar, OrderNo.Trim().Length));
                    command.Parameters["@OrderNo"].Value = OrderNo.Trim();

                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MErr", System.Data.SqlDbType.Int));
                    command.Parameters["@MErr"].Direction = System.Data.ParameterDirection.Output;

                    connection.Open();
                    IAsyncResult result = command.BeginExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    int count = 0;
                    while (!result.IsCompleted)
                    {
                        count += 1;
                        //System.Threading.Thread.Sleep(100);
                    }
                    using (reader = command.EndExecuteReader(result))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                prefix = MyGlobal.Srch2Escape(reader[0].ToString().Trim(), "'");
                                packserial = long.Parse(MyGlobal.Srch2Escape(reader[1].ToString().Trim(), "'"));
                                a1 = MyGlobal.Srch2Escape(reader[2].ToString().Trim(), "'");
                                a2 = MyGlobal.Srch2Escape(reader[3].ToString().Trim(), "'");
                                a3 = MyGlobal.Srch2Escape(reader[4].ToString().Trim(), "'");
                                orderroute = MyGlobal.Srch2Escape(reader[5].ToString().Trim(), "'");
                                packno = int.Parse(MyGlobal.Srch2Escape(reader[6].ToString().Trim(), "'"));
                                totalpack = int.Parse(MyGlobal.Srch2Escape(reader[7].ToString().Trim(), "'")); ;
                                packtype = MyGlobal.Srch2Escape(reader[8].ToString().Trim(), "'");
                                x++;
                                System.Diagnostics.EventLog.WriteEntry("DBRec", prefix + " " + packserial.ToString() + " " + a1 + " " + a2 + " " + a3 + " " + orderroute + " " + packno.ToString() + " " + totalpack.ToString() + " " + packtype, System.Diagnostics.EventLogEntryType.Error, 101, 7);
                            }
                        } while (reader.NextResult());
                    }
                    mRet = (int)command.Parameters["@MErr"].Value;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //System.Diagnostics.EventLog.WriteEntry("SqlException", string.Format("Error ({0}): {1}", ex.Number, ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.ToString());
                    //System.Diagnostics.EventLog.WriteEntry("InvalidOperationException", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                catch (Exception ex)
                {
                    //System.Diagnostics.EventLog.WriteEntry("Exception", string.Format("Error: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Error, 101, 7);
                }
                finally
                {
                    reader.Dispose();
                    command.Dispose();
                    command = null;
                    connection.Dispose();
                    connection = null;
                }

            }
            return mRet;
        }
    }
}