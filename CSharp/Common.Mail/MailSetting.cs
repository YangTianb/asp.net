using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mail
{
    #region 邮件配置参数实体  
    /// <summary>  
    /// 邮件配置参数实体  
    /// </summary>  
    public class MailSetting
    {
        /// <summary>  
        /// 是否启用邮件  
        /// </summary>  
        public bool IsEnable
        {
            get;
            set;
        }
        /// <summary>  
        /// 端口  
        /// </summary>  
        public int SmtpPort
        {
            get;
            set;
        }
        /// <summary>  
        /// 邮件服务器地址  
        /// </summary>  
        public string Server
        {
            get;
            set;
        }
        /// <summary>  
        /// 是否验证发件人用户名和密码  
        /// </summary>  
        public bool Authentication
        {
            get;
            set;
        }
        /// <summary>  
        /// 发件人地址  
        /// </summary>  
        public string From
        {
            get;
            set;
        }
        /// <summary>  
        /// 发件人地址的别名  
        /// </summary>  
        public string ShowName
        {
            get;
            set;
        }
        /// <summary>  
        /// 发件人密码  
        /// </summary>  
        public string Password
        {
            get;
            set;
        }
    }
    #endregion
}
