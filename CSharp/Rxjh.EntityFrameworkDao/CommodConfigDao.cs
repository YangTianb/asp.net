using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;
using Rxjh.IDao;

namespace Rxjh.EntityFrameworkDao
{
    public class CommodConfigDao : ICommodConfigDao
    {
        public List<CommodConfig> GetAll()
        {
            using (RxjhEntities en = new RxjhEntities())
            {
                return en.CommodConfig.ToList();
            }
        }

        public void Add(CommodConfig config)
        {
            using (RxjhEntities en = new RxjhEntities())
            {
                config.ID = Guid.NewGuid();
                en.CommodConfig.Add(config);
                en.SaveChanges();
            }
        }
    }
}
