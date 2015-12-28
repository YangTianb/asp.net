$(function () {
    var hub = $.connection.buyer;
    console.log(hub);
          function init() {
                  return hub.server.getNeastBuyerInfo().done(function (buyers) {
                          //从BuyerHub获取buyer数组，就是这里的参数
                          //遍历显示，如果现在列表中不包含，则插入到第一条
                          var div = $("#shower");
                          $.each(buyers, function (index, item) {
                                 
                              div.prepend("昵称：" + item.Nick);
                              });
                    });
             }
          $.extend(hub.client, {
                 updateInfo: function () {//为client创建一个方法updateInfo一会会用到
                          return init();
                     }
          });
          $.connection.hub.start().pipe(init);//开启客户端SignalR，并首次运行init
});