using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAop
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public  class MethodAopSwitcherAttribute: Attribute
    {
        private int useAspect = 0; //记录类型
        private string userlog = "";    //记录详细信息
        public MethodAopSwitcherAttribute(int useAop, string log)
        {
            this.useAspect = useAop;
            this.userlog = log;
        }

        public int UseAspect
        {
            get
            {
                return this.useAspect;
            }
        }
        public string Userlog
        {
            get
            {
                return this.userlog;
            }
        }
    }
}

