using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAop
{
    class Program
    {
        static void Main(string[] args)
        {
            Exameplec epc = new Exameplec("添加代理的方法");
            epc.say_hello();
            Console.WriteLine("");
            Console.WriteLine("--------------------------这是分隔符--------------------------------");


            Exameplec epcs = new Exameplec("未添加代理的方法");
            epcs.sayByeBye();
            Console.WriteLine("--------------------------这是分隔符--------------------------------");

            
            Console.ReadLine();
        }
    }
}
