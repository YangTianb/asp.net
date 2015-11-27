using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAop
{
    interface IAopProxyFactory
    {
        AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type);
    }
}
