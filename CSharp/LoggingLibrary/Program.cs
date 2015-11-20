using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            LogEntry logEntry = new LogEntry();

            logEntry.EventId = 1;
            logEntry.Priority = 1;
            logEntry.Title = "标题党";
            logEntry.Message = "http://www.cnblogs.com/huangcong/";
            logEntry.Categories.Add("C#学习");
            logEntry.Categories.Add("Microsoft Enterprise Library学习");

            Logger.Writer.Write(logEntry, "General");
            Console.WriteLine("日志写入完成!");
            Console.WriteLine();
        }
    }
}
