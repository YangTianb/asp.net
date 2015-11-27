using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NewAop
{
    interface IAopOperator
    {
        void PreProcess(IMessage requestMsg);
        void PostProcess(IMessage requestMsg, IMessage Respond);
    }
}
