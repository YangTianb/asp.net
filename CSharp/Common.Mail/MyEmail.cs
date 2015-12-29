using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Common.Mail
{
    public class MyEmail
    {
        private MailMessage mMailMessage;   //主要处理发送邮件的内容（如：收发人地址、标题、主体、图片等等）  
        private SmtpClient mSmtpClient; //主要处理用smtp方式发送此邮件的配置信息（如：邮件服务器、发送端口号、验证方式等等）  
        private int mSenderPort;   //发送邮件所用的端口号（htmp协议默认为25）  
        private string mSenderServerHost;    //发件箱的邮件服务器地址（IP形式或字符串形式均可）  
        private string mSenderPassword;    //发件箱的密码  
        private string mSenderUsername;   //发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）  
        private bool mEnableSsl;    //是否对邮件内容进行socket层加密传输  
        private bool mEnablePwdAuthentication;  //是否对发件人邮箱进行密码验证  

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="server">发件箱的邮件服务器地址</param>  
        /// <param name="toMail">收件人地址（可以是多个收件人，程序中是以“;"进行区分的）</param>  
        /// <param name="fromMail">发件人地址</param>  
        /// <param name="subject">邮件标题</param>  
        /// <param name="emailBody">邮件内容（可以以html格式进行设计）</param>  
        /// <param name="displayName">发送后显示发送人邮件地址的别名</param>  
        /// <param name="username">发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）</param>  
        /// <param name="password">发件人邮箱密码</param>  
        /// <param name="port">发送邮件所用的端口号（htmp协议默认为25）</param>  
        /// <param name="sslEnable">true表示对邮件内容进行socket层加密传输，false表示不加密</param>  
        /// <param name="pwdCheckEnable">true表示对发件人邮箱进行密码验证，false表示不对发件人邮箱进行密码验证</param>  
        public MyEmail(string server, string toMail, string fromMail, string subject, string emailBody, string displayName, string username, string password, string port, bool sslEnable, bool pwdCheckEnable)
        {
            try
            {
                mMailMessage = new MailMessage();
                mMailMessage.To.Add(toMail);
                mMailMessage.From = new MailAddress(fromMail, displayName);
                mMailMessage.Subject = subject;
                mMailMessage.Body = emailBody;
                mMailMessage.IsBodyHtml = true;
                mMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mMailMessage.Priority = MailPriority.Normal;
                this.mSenderServerHost = server;
                this.mSenderUsername = username;
                this.mSenderPassword = password;
                this.mSenderPort = Convert.ToInt32(port);
                this.mEnableSsl = sslEnable;
                this.mEnablePwdAuthentication = pwdCheckEnable;
            }
            catch (Exception ex)
            {
                //TODO：异常处理
            }
        }

        /// <summary>  
        /// 添加附件  
        /// </summary>  
        /// <param name="attachmentsPath">附件的路径集合，以分号分隔</param>  
        public void AddAttachments(string attachmentsPath)
        {
            try
            {
                string[] path = attachmentsPath.Split(';'); //以什么符号分隔可以自定义  
                Attachment data;
                ContentDisposition disposition;
                for (int i = 0; i < path.Length; i++)
                {
                    data = new Attachment(path[i], MediaTypeNames.Application.Octet);
                    disposition = data.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(path[i]);
                    disposition.ModificationDate = File.GetLastWriteTime(path[i]);
                    disposition.ReadDate = File.GetLastAccessTime(path[i]);
                    mMailMessage.Attachments.Add(data);
                }
            }
            catch (Exception ex)
            {
                //TODO:异常处理
            }
        }

        /// <summary>  
        /// 邮件的发送  
        /// </summary>  
        /// <returns>true:发送成功</returns>  
        public bool Send()
        {
            if (!GetMailSetting.IsEnable)
            {
                return false;
            }
            bool flag = false;
            try
            {
                if (mMailMessage != null)
                {
                    mSmtpClient = new SmtpClient();
                    mSmtpClient.Host = this.mSenderServerHost;
                    mSmtpClient.Port = this.mSenderPort;
                    mSmtpClient.UseDefaultCredentials = false;
                    mSmtpClient.EnableSsl = this.mEnableSsl;
                    if (this.mEnablePwdAuthentication)
                    {
                        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(this.mSenderUsername, this.mSenderPassword);
                        mSmtpClient.Credentials = nc.GetCredential(mSmtpClient.Host, mSmtpClient.Port, "NTLM");
                    }
                    else
                    {
                        mSmtpClient.Credentials = new System.Net.NetworkCredential(this.mSenderUsername, this.mSenderPassword);
                    }
                    mSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    mSmtpClient.Send(mMailMessage);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                //TODO:异常处理
            }
            return flag;
        }
        /// <summary>  
        /// 获取邮件配置  
        /// </summary>  
        public static MailSetting GetMailSetting
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Environment.CurrentDirectory+@"\Config\Mail.config");
                MailSetting smtpSetting = new MailSetting();
                smtpSetting.Server = doc.DocumentElement.SelectSingleNode("SmtpServer").InnerText;
                smtpSetting.Authentication = Convert.ToBoolean(doc.DocumentElement.SelectSingleNode("Authentication").InnerText);
                smtpSetting.From = doc.DocumentElement.SelectSingleNode("From").InnerText;
                smtpSetting.Password = doc.DocumentElement.SelectSingleNode("Pwd").InnerText;
                smtpSetting.ShowName = doc.DocumentElement.SelectSingleNode("ShowName").InnerText;
                smtpSetting.SmtpPort =Convert.ToInt32(doc.DocumentElement.SelectSingleNode("SmtpPort").InnerText);
                smtpSetting.IsEnable = Convert.ToBoolean(doc.DocumentElement.SelectSingleNode("Enable").InnerText);
                return smtpSetting;
            }
        }
        #region 邮件发送  
        /// <summary>  
        /// 发送邮件  
        /// </summary>  
        /// <param name="to">收件人地址</param>  
        /// <param name="title">标题</param>  
        /// <param name="body">内容</param>  
        /// <returns></returns>  
        public static bool SendMail(string to, string title, string body, string attachPath)
        {
            bool flag = false;
            try
            {
                body = string.Format("{0}<br/><br/><span style='color:#f00;font-size:15px;'>此邮件由系统发出，无需直接回复！<a href='{1}' target='_blank'>{1}</a></span>", body, System.Web.Configuration.WebConfigurationManager.AppSettings["webDomain"]);
                MyEmail email = new MyEmail(GetMailSetting.Server, to, GetMailSetting.From, title, body, GetMailSetting.ShowName, GetMailSetting.From, GetMailSetting.Password, Convert.ToString(GetMailSetting.SmtpPort), false, false);
                email.AddAttachments(attachPath);
                email.Send();
                flag = true;
            }
            catch (Exception ex)
            {
                //TODO：异常处理
            }
            return flag;
        }
        #endregion
    }
}
