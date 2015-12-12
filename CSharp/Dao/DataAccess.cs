﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DataAccess
    {
        public static IPersonDao CreatePersonDao()
        {
            return new PersonDao();
        }
    }
}
