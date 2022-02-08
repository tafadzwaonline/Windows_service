using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Windows_service
{
    public partial class windows_service1 : ServiceBase
    {
        private Timer timer1 = null;
        public windows_service1()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 10000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer2_Tick);
            timer1.Enabled = true;
            logic.WriteErrorLog("Windows service has started");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            logic.WriteErrorLog("Timer has stopped");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            logic.validate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
