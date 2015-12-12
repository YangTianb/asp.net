using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;

namespace Rxjh.EntityFrameworkDao
{
    public class CommodDao : ICommodDao
    {
        /// <summary>
        /// 添加一个最低价格装备
        /// 如果存在同一天的就修改价格
        /// </summary>
        /// <param name="commod">要添加的装备</param>
        public void Add(Commod commod)
        {
            using (RxjhEntities en = new RxjhEntities())
            {
                //先找到当天是否已经存在该装备
                var thisDateCommod = en.Commod.Where(i => i.Name == commod.Name).FirstOrDefault();
                //存在就更新
                if (thisDateCommod != null)
                {
                    en.Commod.Remove(thisDateCommod);
                    commod.ID = Guid.NewGuid();
                    en.Commod.Add(commod);
                    en.SaveChanges();
                }
                else
                {
                    commod.ID = Guid.NewGuid();
                    en.Commod.Add(commod);
                    en.SaveChanges();
                }
            }
        }

        public List<Commod> GetAll()
        {
            using (RxjhEntities en = new RxjhEntities())
            {
                return en.Commod.OrderBy(i => i.Price).ToList();
            }
        }
    }
}
