﻿using DataAccesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rxjh.IBll
{
    public interface ICommodConfigBll
    {

        List<CommodConfig> GetAll();
        void Add(CommodConfig config);
    }
}
