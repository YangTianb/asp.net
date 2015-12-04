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
            string sendStr = "昊天护手";
            //创建bytes字节数组以转换发送串 
            byte[] bytesSendStr = new byte[1024];
            //将发送内容字符串转换成字节byte数组 
            bytesSendStr = Encoding.ASCII.GetBytes(sendStr);
            try
            {
                //向主机发送请求 
                socket.Send(bytesSendStr, bytesSendStr.Length, 0);
            }
            catch (Exception ce)
            {
                Console.WriteLine("发送错误:" + ce.Message);
            }
            //声明接收返回内容的字符串 
            string recvStr = "";
            //声明字节数组，一次接收数据的长度为1024字节 
            byte[] recvBytes = new byte[1024];
            //返回实际接收内容的字节数 
            int bytes = 0;
            //循环读取，直到接收完所有数据 
            while (true)
            {
                bytes = socket.Receive(recvBytes, recvBytes.Length,SocketFlags.None);
                //读取完成后退出循环 
                if (bytes <= 0)
                    break;
                //将读取的字节数转换为字符串 
                recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            }
            //将所读取的字符串转换为字节数组 
            byte[] content = Encoding.ASCII.GetBytes(recvStr);
            try
            {
                //创建文件流对象实例 
                FileStream fs = new FileStream("1111.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //写入文件 
                fs.Write(content, 0, content.Length);
            }
            catch (Exception fe)
            {
                Console.WriteLine("文件创建/写入错误:" + fe.Message, "提示信息");
            }
            //禁用Socket 
            socket.Shutdown(SocketShutdown.Both);
            //关闭Socket 
            socket.Close();
            Console.ReadLine();

        }
    }
}
