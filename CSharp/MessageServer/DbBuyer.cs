using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageServer
{
    public class DbBuyer
    {
        // <summary>
        /// 自增Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// uid
        /// </summary>
        public string BuyerUid { get; set; }
    }
}
