using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Common.Constants
{
  
        public static class Logger
        {
            private static readonly object _lock = new object();
            private static readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log.txt");

            static Logger()
            {
                // Ensure log folder exists
                var logDir = Path.GetDirectoryName(_logFilePath);
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);
            }

            public static void Log(string message)
            {
                WriteLog("INFO", message);
            }

            public static void LogWarning(string message)
            {
                WriteLog("WARNING", message);
            }

            public static void LogError(Exception ex)
            {
                WriteLog("ERROR", $"{ex.Message} | StackTrace: {ex.StackTrace}");
            }

            private static void WriteLog(string level, string message)
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

                // Console log
                Console.WriteLine(logEntry);

                // File log
                lock (_lock)
                {
                    File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
                }
            }
        }
    
}
