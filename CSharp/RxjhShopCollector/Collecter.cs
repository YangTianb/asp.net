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

        public void GetData()
        {
            DataAccesss.SystemConfigServer data = new  DataAccesss.SystemConfigServer();
            var model =  data.Get();
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
            //玄武战衣
            //string sendStr = "595f1000bfdbddba2cdff1c1ebdab2ddcd2cb0da";
            //混元神甲
            string sendStr = "595f1000bfdbddba2cb4e3dba5c6feb3d82cb0da";
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


         
    }
}
