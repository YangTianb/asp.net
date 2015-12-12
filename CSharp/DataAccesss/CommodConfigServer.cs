using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss
{
    public  class CommodConfigServer
    {
        public List<CommodConfig> GetAll() {
            using (RxjhEntities en = new RxjhEntities())
            {
                return en.CommodConfig.ToList();
            }
        }

        public void Add(CommodConfig config) {
            using (RxjhEntities en = new RxjhEntities()) {
                config.ID = Guid.NewGuid();
                en.CommodConfig.Add(config);
                en.SaveChanges();
            }
        }
    }
}
