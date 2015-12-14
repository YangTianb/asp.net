using Rxjh.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using Rxjh.IDao;

namespace Rxjh.Bll
{
    public class CommodBll : ICommodBll
    {
        private ICommodDao commodDao;

        public ICommodDao CommodDao
        {
            get
            {
                return commodDao;
            }

            set
            {
                commodDao = value;
            }
        }

        public void Add(Commod commod)
        {
            CommodDao.Add(commod);
        }

        public List<Commod> GetAll()
        {
            return CommodDao.GetAll();
        }
    }
}
