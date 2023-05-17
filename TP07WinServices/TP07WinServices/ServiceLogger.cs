using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TP07WinServices
{
    public partial class ServiceLogger : ServiceBase
    {
        System.Timers.Timer timer;
        public static EventLog systemEventLog;
        public ServiceLogger()
        {
            systemEventLog = new EventLog("Application");
            systemEventLog.Source = "MySuperbService";

            InitializeComponent();

            ServiceName = "My Super Service";
            CanStop = true;
            CanPauseAndContinue = true;

            AutoLog = true;
            timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            timer.AutoReset = true;

            // Start the timer
            timer.Enabled = true;
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            systemEventLog.WriteEntry("Timed Event from YNB's service", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            timer.Stop();
            systemEventLog.WriteEntry("Logger Stopped", EventLogEntryType.Information);
            Console.WriteLine("Logger Stoped");

        }
    }
}
