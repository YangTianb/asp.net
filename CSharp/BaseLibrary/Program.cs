using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringRand(6);

            HttpHelper h = new HttpHelper();
            var s = h.HttpGet("http://192.168.0.113:18081/zhongduan/zyydqk", "");
            Console.WriteLine(s);
            Console.ReadLine();
        }

        private static string StringRand(int length)
        {
            char[] math = new char[] { '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] low = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            char[] randArray = new char[math.Length + low.Length + upper.Length];

            math.CopyTo(randArray, 0);
            low.CopyTo(randArray, math.Length);
            upper.CopyTo(randArray, math.Length + low.Length);
          
            string randstr = string.Empty;
            var j = 0;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                j = rand.Next(1, randArray.Length);
                Console.WriteLine(j);
                randstr += randArray[j];
            }
            return randstr;
        }
    }
}
