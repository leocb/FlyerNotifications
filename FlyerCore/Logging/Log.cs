using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flyer.Core.Logging
{
    public static class Log
    {
        private static void WriteToLog(string message)
        {
            Debug.WriteLine(message);
        }
        private static string BaseLogInfoText { get => $"{DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss.ffff")} {Thread.CurrentThread.ManagedThreadId}"; }
        public static void Trace(string message)
        {
            WriteToLog($"{BaseLogInfoText} TRACE: {message}");
        }
        public static void Info(string message)
        {
            WriteToLog($"{BaseLogInfoText}  INFO: {message}");
        }
        public static void Warning(string message)
        {
            WriteToLog($"{BaseLogInfoText}  WARN: {message}");
        }
        public static void Error(string message)
        {
            WriteToLog($"{BaseLogInfoText} ERROR: {message}");
        }
    }
}
