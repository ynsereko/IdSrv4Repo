using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IdentityServerFour.Extentions
{
    public class LoginRequestInfo
    {
       // internal object clientInfo;

        /// <summary>
        /// username
        /// </summary>

        public string username { get; set; }

        /// <summary>
        /// password
        /// </summary>
       
        public string password { get; set; }

        /// <summary>
        /// Client SessionId
        /// </summary>
       
        public string clientSessionId { get; set; }

        /// <summary>
        /// User SystemInfo
        /// </summary>
       
        public UserClientSystemInfo userSystemInfo { get; set; }

        /// <summary>
        /// Source
        /// </summary>
       
        public string source { get; set; }
        
    }
}
