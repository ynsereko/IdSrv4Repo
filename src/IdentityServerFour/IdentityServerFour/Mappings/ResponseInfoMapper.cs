using IdentityServerFour.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Mappings
{
    public class ResponseInfoMapper
    {
        public ResponseInfo ProxyResponseInfoToResponseInfo(WcfProxies.SecurityProxy.ResponseInfo info)
        {
            return new ResponseInfo
            {
                IsValid = info.IsValid,
                ResponseId = info.ResponseId,
                ResponseIdStr = info.ResponseIdStr,
                Messages = new MessageInfoMapper().ProxyMessagesToMessages(info.Messages.ToList())

            };
        }

        public ResponseInfoGeneric<SessionTokenInfo> ProxyResponseInfoGenToResponseInfoGen(WcfProxies.SecurityProxy.ResponseInfoGenericSessionTokenInfo proxyResponseGeneric)
        {
            var responseGeneric = new ResponseInfoGeneric<SessionTokenInfo>()
            {
                IsValid = proxyResponseGeneric.IsValid,
                ResponseId = proxyResponseGeneric.ResponseId,
                ResponseIdStr = proxyResponseGeneric.ResponseIdStr,
                Info = new SessionTokenInfoMapper().SessionTokenInfoProxyToSessionTokenInfo(proxyResponseGeneric.Info),
                Messages = new MessageInfoMapper().ProxyMessagesToMessages(proxyResponseGeneric.Messages.ToList())
            };
            //response.Response = new ResponseInfoMapper().ProxyResponseInfoToResponseInfo(responseGeneric.r)


            return responseGeneric;
        }



    }
}
