using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantSharedModels
{
    public partial class MessageInfo
    {
        public MessageInfo()
        {

        }

        public MessageInfo(string msgCode, string msg, MessageType msgType)
        {
            Message = msg;
            MessageCode = msgCode;
            MessageType = msgType;
        }

        public MessageInfo(string msgCode, string msg)
        {
            Message = msg;
            MessageCode = msgCode;
            MessageType = MessageType.Error;
        }

        public string Message { get; set; }
        public string MessageCode { get; set; }
        public Dictionary<string, string> MessageParams { get; set; }
        public MessageType MessageType { get; set; }

    }
}
