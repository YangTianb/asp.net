using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rxjh
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = StringHex.ToHex("玄武战衣","gb2312",false);


            Console.WriteLine("玄武战衣="+s);
            Console.WriteLine(s + "=" + StringHex.UnHex(s, "gb2312"));

            Console.ReadLine();
        }
        private static string hexstr2str(string hexstring) {
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
            byte[] b = new byte[hexstring.Length / 2];
            for (int i = 0; i < hexstring.Length / 2; i++)
            {
                b[i] = Convert.ToByte(hexstring.Substring(i * 2, 2), 16);
            }
            return encode.GetString(b);
        }
        public static string ConvertTo_UTF8_String(string Msg)
        {
            byte[] buff = new byte[Msg.Length / 2];
            string Message = "";
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Convert.ToByte(Msg.Substring(i * 2, 2));
            }
            Message = System.Text.UTF8Encoding.UTF8.GetString(buff);
            return Message;
        }

        public static byte[] StringToHex(string input)
        {
            byte[] result = new byte[input.Length / 2];
            var charArray = input.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                string a = new string(charArray, i * 2, 2);
                result[i] = Convert.ToByte(a, 16);
            }
            return result;
        }

        private static void  Getultstr(string strcontent)
        {
            Encoding e = System.Text.Encoding.GetEncoding("gb2312");
            byte [] gb =  e.GetBytes("玄武战衣");

            string returnStr = "";
            if (gb != null)
            {
                for (int i = 0; i < gb.Length; i++)
                {
                    returnStr += gb[i].ToString("X2");
                }
            }
            
            byte[] asdf = StringToHex(strcontent);
                       
            Console.WriteLine("GB2312={0}", e.GetString(asdf));
            Console.WriteLine("UTF8={0}",System.Text.Encoding.UTF8.GetString(asdf));
            Console.WriteLine("ASCII={0}", System.Text.Encoding.ASCII.GetString(asdf));
            Console.WriteLine("Default={0}", System.Text.Encoding.Default.GetString(asdf));
        }


        private static void RxbbTest()
        {
            //远程主机 
            string hostName = "218.30.83.84";
            //端口 
            int port = 2001;
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
            //string sendStr = "595f1000bfdbddba 2c dff1c1ebdab2ddcd 2c b0da";
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
