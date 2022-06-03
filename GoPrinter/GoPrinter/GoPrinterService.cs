using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GoPrinter
{
    public partial class GoPrinterService : ServiceBase
    {
       
        private readonly int port = 48888;
        private readonly IPAddress ip = IPAddress.Parse("0.0.0.0");
        private TcpListener listener;
        private Thread t = null;
        private Thread tExec = null;
        private int[] MY_INSTANCE=new int[100];
                
        public GoPrinterService()
        {
            InitializeComponent();
            this.CanShutdown = true;
            this.CanPauseAndContinue = true;
            this.CanStop = true;
            this.AutoLog = true;
            this.CanHandleSessionChangeEvent = true;
            this.ServiceName = "GoPrinterService";
            this.listener = new TcpListener(ip, port);
            
        }
        protected override void OnStart(string[] args)
        {
       
            t= new Thread(new ThreadStart(this.Start));
            t.SetApartmentState(ApartmentState.MTA);
            t.IsBackground = true;
            t.Start();
            t.Join(2000);
            MyGlobal.MY_JOB_QUE = new MyGlobal.MY_JOB[300];
            MyGlobal.InitializeJobQue(0);

            MyPrintService mprn = new MyPrintService();
            tExec = new Thread(new ThreadStart(mprn.ExecJobs));
            tExec.Start();
            tExec.Join(2000);
            
        }
        protected override void OnShutdown()
        {
            this.OnStop();
        }
        protected override void OnStop()
        {
            this.listener.Stop();
            
            lock (this)
            {
                MyGlobal.I_CAN_STOP = true;
            }
            this.RequestAdditionalTime(1000);

            if ((t != null) && (t.IsAlive))
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() +
                    " - Stopping the service worker thread.");
#endif
                Thread.Sleep(200);
                t.Abort();
                tExec.Abort();

            }
            if (t != null)
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() +
                    " - OnStop Worker thread state = " +
                    workerThread.ThreadState.ToString());
#endif
            }

            MyStopService ms = new MyStopService();
            ms.Stop();
            ms = null;
            this.ExitCode = 0;

            
            
        }
        public void Start()
        {
            this.listener.Start(1000);
            
            Socket s = null ;
            while (true)
            {
                
                    if (MyGlobal.I_CAN_STOP == true)
                    {
                        this.listener.Stop();
                        break;
                    }
                try
                {
                    s = this.listener.AcceptSocket();
                    
                }
                catch { GC.Collect(); }
                if (s != null)
                {
                    GoPrinterServer msrv = new GoPrinterServer();
                    
                    msrv.MY_SOCKET = s;
                    
                    Thread tchild = new Thread(new ThreadStart(msrv.StartChild));
                    tchild.SetApartmentState(ApartmentState.STA);
                    tchild.IsBackground = true ;
                    tchild.Start();
                    tchild.Join(1000); 
                    s = null;
                    msrv = null; 
                    
                }
            }
            try
            {
                //System.Diagnostics.EventLog.WriteEntry("LISTEN", "UNBLOCK SOCKET", System.Diagnostics.EventLogEntryType.Error, 101, 7);
                s.Blocking = false;
            }
            catch { }
            try
            {

                //System.Diagnostics.EventLog.WriteEntry("LISTEN", "CLOSE SOCKET", System.Diagnostics.EventLogEntryType.Error, 101, 7);
                s.Close();
            }
            catch { }

        }
        private int GiveMeInstanceID()
        {
            int i = 0;
            int x=0;
            for (i = 0; i < 100; i++)
            {
                if (MY_INSTANCE[i] == 0)
                {
                    x = i;
                    break;
                }
            }
            MY_INSTANCE[x] = x+1;
            return MY_INSTANCE[x];
        }
        /*
        private void CloseAll()
        {
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                                   
                if (MyGlobal.MY_OPEN_SOCK[i] != null)
                {
                    try
                    {
                        MyGlobal.MY_OPEN_SOCK[i].Close();
                    }
                    catch { GC.Collect(); }
                    //try
                    //{
                    //    MyGlobal.MY_OPEN_THREAD[i].Join(10);
                    //    //MyGlobal.MY_OPEN_THREAD[i].Abort();
                    //}
                    //catch { GC.Collect(); }
                }


            }
        }
        */ 
    }
}
