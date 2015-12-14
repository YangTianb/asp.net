using Rxjh.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesss;

namespace Rxjh.EntityFrameworkDao
{
    public class CommodCache : ICommodDao
    {
        /// <summary>
        /// 缓存对象
        /// </summary>
        private string CacheKey = "CommodDataCache";

        public void Add(Commod commod)
        {
            List<Commod> list = GetAll();
            //如果存在相同名字的就移除，然后添加新的
            if (list!=null&&list.Count>0&&list.Where(i => i.Name.Equals(commod.Name)).FirstOrDefault() != null)
            {
                var removeModel = list.First(i => i.Name.Equals(commod.Name));
                list.Remove(removeModel);
                
            }
            commod.ID = Guid.NewGuid();
            list.Add(commod);

            BaseLibrary.CacheHelper.RemoveCache(CacheKey);

            BaseLibrary.CacheHelper.Add(CacheKey, list,true);
        }

        public List<Commod> GetAll()
        {
            var list = (List<Commod>)BaseLibrary.CacheHelper.GetCache(CacheKey);
            return list == null ? new List<Commod>() : list;
        }
    }
}
