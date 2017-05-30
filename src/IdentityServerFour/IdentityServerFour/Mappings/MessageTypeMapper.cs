using IdentityServerFour.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Mappings
{
    public class MessageTypeMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public WcfProxies.SecurityProxy.MessageType MessageTypeToProxyMessageType(MessageType msgType)
        {
            WcfProxies.SecurityProxy.MessageType proxyMsgType = WcfProxies.SecurityProxy.MessageType.UNKNOWN;
            switch (msgType)
            {
                case MessageType.AccountTypeRestriction:
                    proxyMsgType = WcfProxies.SecurityProxy.MessageType.AccountTypeRestriction;
                    break;
                case MessageType.Error:
                    proxyMsgType = WcfProxies.SecurityProxy.MessageType.Error;
                    break;
                case MessageType.Information:
                    proxyMsgType = WcfProxies.SecurityProxy.MessageType.Information;
                    break;
                case MessageType.Success:
                    proxyMsgType = WcfProxies.SecurityProxy.MessageType.Success;
                    break;
                default:
                    proxyMsgType = WcfProxies.SecurityProxy.MessageType.UNKNOWN;
                    break;
            }
            return proxyMsgType;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxyMessageType"></param>
        /// <returns></returns>
        public MessageType MessageTypeProxyToMessageType(WcfProxies.SecurityProxy.MessageType proxyMessageType)
        {
            MessageType msgType = MessageType.UNKNOWN;
            switch (proxyMessageType)
            {
                case WcfProxies.SecurityProxy.MessageType.AccountTypeRestriction:
                    msgType = MessageType.AccountTypeRestriction;
                    break;
                case WcfProxies.SecurityProxy.MessageType.Error:
                    msgType = MessageType.Error;
                    break;
                case WcfProxies.SecurityProxy.MessageType.Information:
                    msgType = MessageType.Information;
                    break;
                case WcfProxies.SecurityProxy.MessageType.Success:
                    msgType = MessageType.Success;
                    break;
                default:
                    msgType = MessageType.UNKNOWN;
                    break;
            }
            return msgType;

        }
    }
}
