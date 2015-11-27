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
            StringCount();
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

        private static void StringCount()
        {
            string s = "This is jikexuyuan c# tutorial!";
            int i = s.WordCount();
            Console.WriteLine(s + " have {0} word", i);
            Console.ReadLine();
        }

    }

    public static class StringExtension{
        public static int WordCount(this string str) {
            return str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
        } 
    }
}
