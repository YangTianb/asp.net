using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NewAop
{
    public class AopControlProxy : AopProxyBase
    {
        public AopControlProxy(MarshalByRefObject obj, Type type)
            : base(obj, type)   //指定调用基类中的构造函数
        {
        }

        public override void PreProcess(IMessage requestMsg)
        {

            Console.WriteLine("目标方法运行开始之前");
            return;
        }

        public override void PostProcess(IMessage requestMsg, IMessage Respond)
        {
            Console.WriteLine("目标方法运行结束之后");
        }

        
    }
}
