using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using Rxjh.IBll;

namespace Rxjh.Bll
{
    public class CommodConfigBll : ICommodConfigBll
    {
        private ICommodConfigDao commodConfigDao;

        public ICommodConfigDao CommodConfigDao
        {
            get
            {
                return commodConfigDao;
            }

            set
            {
                commodConfigDao = value;
            }
        }

        public void Add(CommodConfig config)
        {
            CommodConfigDao.Add(config);
        }

        public List<CommodConfig> GetAll()
        {
            return CommodConfigDao.GetAll();
        }
    }
}
