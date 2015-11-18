using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoLinq();
        }

        private static void DemoLinq()
        {
            int[] ints = { 10, 20, 3, 33, 4 };
            var result = ints.OrderBy(g => g);

            foreach (var i in result)
            {
                Console.WriteLine("{0}", i);
            }
            Console.ReadLine();
        }

  
    }
}
