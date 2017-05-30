using IdentityServerFour.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Mappings
{
    public class SessionTokenInfoMapper
    {
        public WcfProxies.SecurityProxy.SessionTokenInfo SessionTokenInfoToProxySessionTokenInfo(SessionTokenInfo info)
        {
            return new WcfProxies.SecurityProxy.SessionTokenInfo()
            {
                Token = info.Token,
                UserId = info.UserId,
                Username = info.Username,
                SessionId = info.SessionId,
                SystemId = info.SystemId,
                InitiatedOn = info.InitiatedOn,
                ExpiresOn = info.ExpiresOn,
                MemberId = info.MemberId,
                ReferenceId = info.ReferenceId,
                AuthenticationLevel = info.AuthenticationLevel,
                TellerId = info.TellerId,
                LastAccessedDate = info.LastAccessedDate,
                ExpirationDurationMinutes = info.ExpirationDurationMinutes, 
                //ServerName = info.ServerName,
                FirstName = info.FirstName,
                LastName = info.LastName
            };
        }


       

        public SessionTokenInfo SessionTokenInfoProxyToSessionTokenInfo(WcfProxies.SecurityProxy.SessionTokenInfo info)
        {
            return new SessionTokenInfo()
            {
                Token = info.Token,
                UserId = info.UserId,
                Username = info.Username,
                SessionId = info.SessionId,
                SystemId = info.SystemId,
                InitiatedOn = info.InitiatedOn,
                ExpiresOn = info.ExpiresOn,
                MemberId = info.MemberId,
                ReferenceId = info.ReferenceId,
                AuthenticationLevel = info.AuthenticationLevel,
                TellerId = info.TellerId,
                LastAccessedDate = info.LastAccessedDate,
                ExpirationDurationMinutes = info.ExpirationDurationMinutes,
                //ServerName = info.ServerName,
                FirstName = info.FirstName,
                LastName = info.LastName

            };
        }
    }
}
