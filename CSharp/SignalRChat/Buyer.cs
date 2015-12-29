using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MessageServer;

namespace SignalRChat
{
    public class Buyer : Hub
    {
        private const int TakeCount = 20;

        public List<DbBuyer> GetNeastBuyerInfo(string groupName)
        {
            //消息分组  
            Groups.Add(Context.ConnectionId, groupName);
         
            //Clients.Group(groupName).addMessage(lisByer);
            var lisByer = new List<DbBuyer>();
            var _buyerid = new Random().Next(232432432);
            lisByer.Add(new DbBuyer() { BuyerUid = _buyerid.ToString(), Nick = "张三", Id = 1 , GoupName=groupName});
            return lisByer;
        }
    }
}