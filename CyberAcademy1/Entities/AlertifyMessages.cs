//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace CyberAcademy1.Entities
//{
//    public class AlertifyMessages
//    {
//        public List<AlertifyMessage> Messages { get; private set; } = new List<AlertifyMessage>();
//        public void Add(AlertifyType type, string message, string callbackUrl = null)
//        {
//            Messages.Add(new AlertifyMessage(type, message, callbackUrl));
//        }
//    }
//    public class AlertifyMessage
//    {
//        public AlertifyType Type { get; set; }
//        public string Message { get; set; }
//        public string CallbackUrl { get; set; }
//        public AlertifyMessage(AlertifyType type, string message, string callbackUrl)
//        {
//            Type = type;
//            Message = message;
//            CallbackUrl = callbackUrl;
//        }
//    }

//    public enum AlertifyType
//    {
//        Log,
//        Error,
//        Success
//    }
//}