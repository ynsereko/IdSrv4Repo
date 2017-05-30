using System;

namespace IdentityServerFour.Extentions
{
    public class UserClientSystemInfo
    {
        
        public long ID { get; set; }

       
        public string EntityType { get; set; }

        
        public int EntityID { get; set; }

        
        public string BrowserType { get; set; }

       
        public string BrowserVersion { get; set; }

       
        public string BrowserFamily { get; set; }

        public string BrowserName
        {
            get { return BrowserFamily + " " + BrowserVersion; }
        }

       
        public string IPAddress { get; set; }

        
        public string ServerName { get; set; }

       
        public string UserAgent { get; set; }

        
        public string Platform { get; set; }

       
        public bool IsJSEnabled { get; set; }

        
        public decimal TimeZone { get; set; }

       
        public DateTime Created { get; set; }

        
        public string UniqueId { get; set; }

        
        public decimal Lattitude { get; set; }

       
        public decimal Longitude { get; set; }

        
        public string SessionId { get; set; }
    }
}