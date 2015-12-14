using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using Rxjh.IDao;
using System.IO;

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
            SystemConfig cfm = new SystemConfig();
            //读取json文件  
            using (StreamReader sr = new StreamReader(SystemConfigPath))
            {
                try
                {
                    string retString = sr.ReadToEnd();
                    cfm = BaseLibrary.JsonExtend.Deserialize<SystemConfig>(retString);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                sr.Close();
                sr.Dispose();
            }
            return cfm;
        }
    }
}
