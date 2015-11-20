using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayker.LogLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
            logWriter.Write("Test");
            Console.ReadLine();
        }
    }
}
