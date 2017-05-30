using IdentityServerFour.Extentions;
using System;


namespace IdentityServerFour.Mappings
{
    public class UserClientSystemInfoMapper
    {
        public WcfProxies.SecurityProxy.UserClientSystemInfo UserClientSystemInfoToProxyUserClientSystemInfo(UserClientSystemInfo info)
        {
            return new WcfProxies.SecurityProxy.UserClientSystemInfo()
            {
                ID = info.ID,
                EntityType = info.EntityType,
                EntityID = info.EntityID,
                BrowserType = info.BrowserType,
                BrowserVersion = info.BrowserVersion,
                BrowserFamily = info.BrowserFamily,
                IPAddress = info.IPAddress,
                ServerName = info.ServerName,
                UserAgent = info.UserAgent,
                Platform = info.Platform,
                IsJSEnabled = info.IsJSEnabled,
                TimeZone = info.TimeZone,
                Created = info.Created,
                UniqueId = info.UniqueId,
                Lattitude = info.Lattitude,
                Longitude = info.Longitude,
                SessionId = info.SessionId

            };
        }

        public UserClientSystemInfo UserClientSystemInfoProxyToUserClientSystemInfo(WcfProxies.SecurityProxy.UserClientSystemInfo info)
        {
            return new UserClientSystemInfo()
            {
                ID = info.ID,
                EntityType = info.EntityType,
                EntityID = info.EntityID,
                BrowserType = info.BrowserType,
                BrowserVersion = info.BrowserVersion,
                BrowserFamily = info.BrowserFamily,
                IPAddress = info.IPAddress,
                ServerName = info.ServerName,
                UserAgent = info.UserAgent,
                Platform = info.Platform,
                IsJSEnabled = info.IsJSEnabled,
                TimeZone = info.TimeZone,
                Created = info.Created,
                UniqueId = info.UniqueId,
                Lattitude = info.Lattitude,
                Longitude = info.Longitude,
                SessionId = info.SessionId

            };
        }



    }
}
