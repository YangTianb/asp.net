using System.Collections.Generic;
using System.Configuration;

namespace ConsoleApplication1
{
    public class SmsService : ISmsService
    {
        private readonly string _accountsid = ConfigurationManager.AppSettings["ACCOUNTSID"].ToString();
        private readonly string _authToken = ConfigurationManager.AppSettings["AUTHTOKEN"].ToString();
        private readonly string _restServerip = ConfigurationManager.AppSettings["RESTSERVERIP"].ToString();
        private readonly string _restPort = ConfigurationManager.AppSettings["RESTPORT"].ToString();
        private readonly string _appId = ConfigurationManager.AppSettings["APPID"].ToString();
        private readonly string _registTemplateId = ConfigurationManager.AppSettings["RegistTemplateId"].ToString();
        private CCPRestSDK.CCPRestSDK _api;
        
        public CCPRestSDK.CCPRestSDK Api
        {
            get {
                if (_api == null)
                {
                    _api = new CCPRestSDK.CCPRestSDK();
                  
                    return _api;
                }
                else
                {
                    return _api;
                }
            }
            set { _api = value; }
        }

        private bool Init(CCPRestSDK.CCPRestSDK restSdk)
        {
            var isInit = Api.init(_restServerip, _restPort);
            Api.setAccount(_accountsid, _authToken);
            Api.setAppId(_appId);
            return isInit;
        }

        public bool SendRegistSms(string phoneNumber, string body)
        {
            string ret = null;
            bool isInit = Init(Api);
            if (isInit)
            {
                Dictionary<string, object> retData = Api.SendTemplateSMS(phoneNumber, _registTemplateId, new string[]
                {
                    $"你的验证码为：{body}"
                });
                ret = getDictionaryData(retData);
            }
            else
            {
                ret = "初始化失败";
            }
            return false;
        }

        private string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value?.ToString() ?? "null") + ";";
                }
            }
            return ret;
        }
    }
}
