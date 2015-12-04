using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRegistry();
        }

        static void AppRegistry()
        {
            MyXmlFactory ctx = new MyXmlFactory(@"D:\Objects.xml");
            Console.WriteLine(ctx.GetObject("PersonDao").ToString());
            Console.ReadLine();
        }
    }
}
