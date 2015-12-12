using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;

namespace Rxjh.Bll
{
    public class CommodConfigBll : ICommodConfigDao
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
