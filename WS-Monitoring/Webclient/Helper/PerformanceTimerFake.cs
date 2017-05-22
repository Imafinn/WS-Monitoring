using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Timers;
using System.Web;
using Webclient.Models;

namespace Webclient.Helper
{
    public class PerformanceTimerFake : IPerformanceTimer
    {

        public PerformanceTimerFake(List<ServiceFull> list)
        {
            string services = "";
            foreach (ServiceFull s in list)
            {
                services += "- " + s.DisplayName + " \n";
            }

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("G:\\PUBLIC\\winflex\\test.txt");
            file.WriteLine(services);

            file.Close();
        }

        public void OnTickEvent(object source, ElapsedEventArgs e)
        {
            
        }

        public void TimerInit()
        {

        }

    }
}