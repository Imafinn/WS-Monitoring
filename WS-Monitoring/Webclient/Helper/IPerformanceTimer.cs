using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using Webclient.Models;

namespace Webclient.Helper
{
    public interface IPerformanceTimer
    {
        void TimerInit();

        void OnTickEvent(object source, ElapsedEventArgs e);
    }
}