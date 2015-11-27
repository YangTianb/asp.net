using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopLibrary
{
    public class TalkProxy : ITalk
    {
        private ITalk talker;

        public TalkProxy(ITalk talker)
        {
            this.talker = talker;
        }

        public void Talk(string msg)
        {
            talker.Talk(msg);
        }

        public void Talk(string msg, string singname)
        {
            talker.Talk(msg);
            Sing(singname);
        }

        private void Sing(string singname)
        {
            Console.WriteLine("我唱:{0}", singname);
        }
    }
}
