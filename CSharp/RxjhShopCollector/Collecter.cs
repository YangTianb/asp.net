using BaseLibrary;
using DataAccesss;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RxjhShopCollector
{
    public  class Collecter
    {

        private Socket commodSocket = null;


        //应用程序路劲
        private string applicationPath =@""+ Environment.CurrentDirectory;
        private string SystemConfigPath {
            get { return @"" + applicationPath + @"\config\" + @"SystemConfig.json"; }
        }

        private string CommodConfigPath
        {
            get
            {
                return @""+applicationPath + @"\config\" + @"CommodConfig.json";
            }
        }

        private string CommodDataPath {
            get {
                return @"" + applicationPath + @"\Data\" + @"Commod.json";
            }
        }

        public  Socket CommodSocket
        {
            get
            {
                if (commodSocket == null)
                {
                    var model = ReadSystemConfig();
                    //远程主机 
                    string hostName = model.IP;
                    //端口 
                    int port = model.Port;

                    commodSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        //尝试连接 
                        commodSocket.Connect(hostName, port);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("连接错误");
                    }
                }
               
               return commodSocket;
            }

            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexData"></param>
        public void GetData(string hexData)
        {
            //发送给远程主机的请求内容串 
            string sendStr = hexData;
            //创建bytes字节数组以转换发送串 
            byte[] bytesSendStr = new byte[1024];
            //将发送内容字符串转换成字节byte数组 
            var b = StringToBytes(sendStr);
            try
            {
                //向主机发送请求             
                CommodSocket.Send(b, SocketFlags.None);
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
                while ((length = CommodSocket.Receive(buffer)) > 0)
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

            foreach (var tempcommod in commods)
            {

                var _tempCommod = new Commod();
                if (tempcommod.IndexOf('?') > 0)
                    continue;
                var arrayAtt = tempcommod.Split('#');
                if (arrayAtt.Length == 1 || arrayAtt.Length <= 6)
                    continue;
                _tempCommod.MerName = arrayAtt[0].ToString();
                _tempCommod.Axes = arrayAtt[1].ToString();
                _tempCommod.Line = arrayAtt[3].ToString();
                _tempCommod.DateTimes = arrayAtt[4].ToString();
                _tempCommod.Name = arrayAtt[5].ToString();
                //价格
                long _price = 0;
                if (arrayAtt.Length >= 7)
                {
                    long.TryParse(arrayAtt[6], out _price);
                    _tempCommod.Price = _price;
                    //属性
                    _tempCommod.ValueAdd = arrayAtt.Length >= 8 ? arrayAtt[7].ToString() : "";
                }

                listCommod.Add(_tempCommod);

            }
            LowPrice(listCommod.ToArray());

            //禁用Socket 
            //socket.Shutdown(SocketShutdown.Both);
            //关闭Socket 
            CommodSocket.Close();
            commodSocket = null;

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


        public List<DataAccesss.CommodConfig> MoinList()
        {
            return ReadCommodConfig();
        }

        public List<Commod> GetLowData()
        {
            CommodServer server = new CommodServer();
            return server.GetAll();
        }

        public void LowPrice(DataAccesss.Commod[] commods)
        {
            if (commods.Length == 0)
                return;
            DataAccesss.Commod low = commods.Where(t => t.Price != 0).OrderBy(i => i.Price).First();

            CommodServer commodserver = new CommodServer();
            commodserver.Add(low);

        }

        public void AddCommodConfig(DataAccesss.CommodConfig config)
        {
            CommodConfigServer server = new CommodConfigServer();
            server.Add(config);
        }

        public SystemConfig ReadSystemConfig()
        {
            SystemConfig cfm = new SystemConfig();
            //读取json文件  
            using (StreamReader sr = new StreamReader(SystemConfigPath))
            {
                try
                {                   
                    string retString = sr.ReadToEnd();
                    cfm = Deserialize<SystemConfig>(retString);

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                sr.Close();
                sr.Dispose();
            }
            return cfm;
        }

        public List<CommodConfig> ReadCommodConfig() {
            List<CommodConfig> listcfm = new List<DataAccesss.CommodConfig>();
            using (StreamReader sr = new StreamReader(CommodConfigPath)) {
                try {
                    string retString = sr.ReadToEnd();
                    listcfm= retString.JSONStringToList<CommodConfig>();
                } catch
                    (Exception ex){
                }
                sr.Close();
                sr.Dispose();
            }
            return listcfm;
        }

        public List<Commod> LoadLowData() {
            List<Commod> list = new List<Commod>();
            using (StreamReader sr = new StreamReader(CommodDataPath)) {
                try
                {
                    string jsondata = sr.ReadToEnd();
                    list = jsondata.JSONStringToList<Commod>();
                    sr.Close();
                    sr.Dispose();
                }
                catch (Exception ex) {
                    ex.Message.ToString();
                }
            }
            return list;
        }
        
        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

    }


}
