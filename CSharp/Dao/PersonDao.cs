﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class PersonDao : IPersonDao
    {
        public void Save()
        {
            Console.WriteLine("PersonDao保存成功！");
        }



       
    }
}
