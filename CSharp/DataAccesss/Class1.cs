using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss
{
    public class SystemConfigServer
    {
        public DataAccesss.SystemConfig Get()
        {
            using (RxjhEntities en = new RxjhEntities())
            {
                return en.SystemConfig.FirstOrDefault();
            }
        }
    }
}
