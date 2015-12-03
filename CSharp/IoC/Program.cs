using Dao;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethod();
            IoCMethod();
            Console.ReadLine();
        }


        private static void FactoryMethod()
        {
            IPersonDao dao = DataAccess.CreatePersonDao();
            dao.Save();
            Console.WriteLine("我是工厂方法");
        }
        private static void NormalMethod()
        {
            IPersonDao dao = new PersonDao();
            dao.Save();
            Console.WriteLine("我是一般方法");
        }

        private static void IoCMethod()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IPersonDao dao = ctx.GetObject("PersonDao") as IPersonDao;
            if (dao != null)
            {
                dao.Save();
                Console.WriteLine("我是IoC方法");
            }
        }
    }
}
