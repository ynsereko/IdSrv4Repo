using IdentityServerFour.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Mappings
{
    public class MessageInfoMapper
    {
        public MessageInfo MessageInfoProxyToMessageInfo(WcfProxies.SecurityProxy.MessageInfo info)
        {
            return new MessageInfo
            {
                Message = info.Message,
                MessageCode = info.MessageCode,
               MessageParams = info.MessageParams,
                MessageType = new MessageTypeMapper().MessageTypeProxyToMessageType(info.MessageType)

            };

        }

        public List<MessageInfo> ProxyMessagesToMessages(List<WcfProxies.SecurityProxy.MessageInfo> proxyMsgs)
        {
            var messages = new List<MessageInfo>();
            foreach (WcfProxies.SecurityProxy.MessageInfo proxyMsg in proxyMsgs)
            {
                messages.Add(MessageInfoProxyToMessageInfo(proxyMsg));
            }
            return messages;
        }
    }
}
