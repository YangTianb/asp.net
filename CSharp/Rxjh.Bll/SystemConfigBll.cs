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
    public class SystemConfigBll : ISystemConfigBll
    {
        private ISystemConfigDao systemConfigDao;

        public ISystemConfigDao SystemConfigDao
        {
            get
            {
                return systemConfigDao;
            }

            set
            {
                systemConfigDao = value;
            }
        }

        public SystemConfig GetAll()
        {
            return SystemConfigDao.GetAll();
        }
    }
}
