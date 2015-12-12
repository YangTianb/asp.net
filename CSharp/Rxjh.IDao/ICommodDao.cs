using DataAccesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rxjh.IDao
{
    public interface ICommodDao
    {
        void Add(Commod commod);
        List<Commod> GetAll();
    }
}
