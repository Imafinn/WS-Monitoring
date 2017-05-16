﻿using System;
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
    public class PerformanceTimer : IPerformanceTimer
    {
        /// <summary>
        /// Creates a new timer for monitoring CPU and RAM usage of service processes.
        /// </summary>
        /// <param name="list">The list of services</param>
        public PerformanceTimer(List<ServiceFull> list)
        {
            ServiceList = list;
            TimerInit();
        }

        /// <summary>
        /// This is run every time the timer ticks
        /// </summary>
        private void OnTickEvent(object source, ElapsedEventArgs e)
        {
            foreach (ServiceFull service in ServiceList)
            {
                string query = $"SELECT ProcessId FROM Win32_Service WHERE Name = '{service.ServiceName}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);


                foreach (ManagementObject obj in searcher.Get())
                {
                    int processId = Int32.Parse(obj["processId"].ToString());
                    Process process = null;
                    try
                    {
                        process = Process.GetProcessById((int)processId);
                    }
                    catch (ArgumentException)
                    {
                        // Thrown if the process specified by processId
                        // is no longer running.
                    }
                    try
                    {
                        if (process != null)
                        {
                            PerformanceCounter myAppCpu = new PerformanceCounter(
                                "Process", "% Processor Time", process.ProcessName, true);
                            PerformanceCounter myAppRam = new PerformanceCounter(
                                "Process", "Working Set - Private", process.ProcessName, true);
                            myAppCpu.NextValue();
                            service.PerformanceRAM = (myAppRam.NextValue() / (int)(1024)).ToString();
                            Thread.Sleep(250);
                            service.PerformanceCPU = (myAppCpu.NextValue() / Environment.ProcessorCount).ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new timer ticking after 5 seconds
        /// </summary>
        public void TimerInit()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTickEvent);
            aTimer.Interval = 500;
            aTimer.Enabled = true;
        }

        List<ServiceFull> ServiceList { get; set; }
    }
}