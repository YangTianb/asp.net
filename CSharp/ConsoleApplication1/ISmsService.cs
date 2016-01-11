namespace ConsoleApplication1
{
    internal interface ISmsService
    {
        /// <summary>
        /// 发送注册短信（模板短信）
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        bool SendRegistSms(string phoneNumber, string body);
    }
}
