using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mail
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEmail.SendMail("bayker@foxmail.com", "你好", "这是一个测试邮件", "service@scpo.cn");
        }
    }
}
