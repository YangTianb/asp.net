using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------无代理测试-----");
            PeopleTalk p = new PeopleTalk("李雷", 18);
            p.Talk("我想见韩梅梅");

            Console.WriteLine("---有代理测试---");
            TalkProxy t = new TalkProxy(p);
            t.Talk("我想见韩美美","不怕不怕啦");

            Console.ReadLine();

        }
    }

}
