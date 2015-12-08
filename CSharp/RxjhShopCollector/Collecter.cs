using DataAccesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RxjhShopCollector
{
    class Collecter
    {

        public void GetData(string hexData)
        {
            DataAccesss.SystemConfigServer dataServer = new  DataAccesss.SystemConfigServer();
            var model = dataServer.Get();
            //远程主机 
            string hostName = model.IP;
            //端口 
            int port = model.Port;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //尝试连接 
                socket.Connect(hostName, port);
            }
            catch (Exception se)
            {
                Console.WriteLine("连接错误");
            }
            //发送给远程主机的请求内容串 
          
            string sendStr = hexData;
            //创建bytes字节数组以转换发送串 
            byte[] bytesSendStr = new byte[1024];
            //将发送内容字符串转换成字节byte数组 
            var b = StringToBytes(sendStr);
            try
            {
                //向主机发送请求             
                socket.Send(b, SocketFlags.None);
            }
            catch (Exception ce)
            {
                Console.WriteLine("发送错误:" + ce.Message);
            }

            Encoding encode = Encoding.Default;
            string result = string.Empty;
            List<byte> data = new List<byte>();
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                while ((length = socket.Receive(buffer)) > 0)
                {
                    //6为前6个字节无用的字节
                    for (int j = 6; j < length; j++)
                    {
                        data.Add(buffer[j]);
                    }
                    if (length < buffer.Length)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (data.Count > 0)
            {
                result = encode.GetString(data.ToArray(), 0, data.Count);
            }

            var commods = result.Split('|');
            List<Commod> listCommod = new List<Commod>();
            
            foreach (var tempcommod in commods) {
                
                var _tempCommod = new Commod();
                if (tempcommod.IndexOf('?') > 0)
                    continue;
                var arrayAtt = tempcommod.Split('#');
                if (arrayAtt.Length ==1||arrayAtt.Length<=6)
                    continue;
                _tempCommod.MerName = arrayAtt[0].ToString();
                _tempCommod.Axes = arrayAtt[1].ToString();
                _tempCommod.Line = arrayAtt[3].ToString();
                _tempCommod.DateTimes = arrayAtt[4].ToString();
                _tempCommod.Name = arrayAtt[5].ToString();
                //价格
                long _price = 0;
                if (arrayAtt.Length >= 7) {
                    long.TryParse(arrayAtt[6], out _price);
                    _tempCommod.Price = _price;
                    //属性
                    _tempCommod.ValueAdd = arrayAtt.Length >= 8 ? arrayAtt[7].ToString() : "";
                }
                
                listCommod.Add(_tempCommod);

            }
            LowPrice(listCommod.ToArray());
                        
            //禁用Socket 
            socket.Shutdown(SocketShutdown.Both);
            //关闭Socket 
            socket.Close();
            Console.ReadLine();
        }
        /// <summary>
        /// 把一个存储16进制数的字符串转化为存储16进制数的字节数组
        /// </summary>
        /// <param name="HexString">存储16进制数的字符串</param>
        /// <returns>返回一个字节数组</returns>
        public static byte[] StringToBytes(string HexString)
        {
            byte[] temdata = new byte[HexString.Length / 2];
            for (int i = 0; i < temdata.Length; i++)
            {
                temdata[i] = Convert.ToByte(HexString.Substring(i * 2, 2), 16);
            }
            return temdata;
        }


        public List<DataAccesss.CommodConfig> MoinList() {

            DataAccesss.CommodConfigServer config = new DataAccesss.CommodConfigServer();
            return config.GetAll();                
        }

        public List<Commod> GetLowData() {
            CommodServer server = new CommodServer();
            return server.GetAll();
        }

        public void LowPrice(DataAccesss.Commod[] commods)
        {
            if (commods.Length == 0)
                return;
            DataAccesss.Commod low = commods.Where(t=>t.Price!=0).OrderBy(i => i.Price).First();

            CommodServer commodserver = new CommodServer();
            commodserver.Add(low);

        }

        public void AddCommodConfig(DataAccesss.CommodConfig config) {
            CommodConfigServer server = new CommodConfigServer();
            server.Add(config);
        }
    }
}
