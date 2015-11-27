using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopLibrary
{
    public class PeopleTalk : ITalk
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PeopleTalk(string name,int age) {
            this.Name = name;
            this.Age = age;
        }

        public void Talk(string msg)
        {
            Console.WriteLine("我是说：{0}，我今年{1}岁 ", Name, Age);
        }
        

    }
}
