using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using System.IO;
using BaseLibrary;

namespace Rxjh.JsonDao
{
    public class CommodConfigDaoJson : ICommodConfigDao
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

        public void Add(CommodConfig config)
        {
            throw new NotImplementedException();
        }

        public List<CommodConfig> GetAll()
        {
            List<CommodConfig> listcfm = new List<DataAccesss.CommodConfig>();
            using (StreamReader sr = new StreamReader(CommodConfigPath))
            {
                try
                {
                    string retString = sr.ReadToEnd();
                    listcfm = retString.JSONStringToList<CommodConfig>();
                }
                catch
                  (Exception ex)
                {
                }
                sr.Close();
                sr.Dispose();
            }
            return listcfm;
        }
    }
}
