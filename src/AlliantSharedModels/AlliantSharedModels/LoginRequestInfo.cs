using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantSharedModels
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
