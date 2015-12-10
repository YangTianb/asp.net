using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;

namespace Rxjh.JsonDao
{
    public class SystemConfigDaoJson : ISystemConfigDao
    {
        //应用程序路劲
        private string applicationPath = @"" + Environment.CurrentDirectory;
        private string SystemConfigPath
        {
            get { return @"" + applicationPath + @"\config\" + @"SystemConfig.json"; }
        }

        private string CommodConfigPath
        {
            get
            {
                return @"" + applicationPath + @"\config\" + @"CommodConfig.json";
            }
        }

        private string CommodDataPath
        {
            get
            {
                return @"" + applicationPath + @"\Data\" + @"Commod.json";
            }
        }

        public SystemConfig GetAll()
        {
            return new SystemConfig() { IP = "", Port = 11 };
        }
    }
}
