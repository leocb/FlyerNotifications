using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Logging
{
    public static class Log
    {
        private static void WriteToLog(string message)
        {
            Debug.WriteLine(message);
        }
        public static void Info(string message)
        {
            WriteToLog($"Info: {message}");
        }
        public static void Warning(string message)
        {
            WriteToLog($"Warning: {message}");
        }
        public static void Error(string message)
        {
            WriteToLog($"Error: {message}");
        }
    }
}
