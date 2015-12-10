using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;

namespace Rxjh.EntityFrameworkDao
{
    public class SystemConfigDaoDb : ISystemConfigDao
    {
        public SystemConfig GetAll()
        {
           
            using (RxjhEntities en = new RxjhEntities())
            {
                return en.SystemConfig.FirstOrDefault();
            }
        }
    }
}
