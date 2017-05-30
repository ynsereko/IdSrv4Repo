using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
//using WcfProxies.SecurityProxy;
//using WcfProxies.SecurityProxy;

namespace IdentityServerFour.Extentions
{
   
    public class ResponseInfo
    {
        #region Private Members
        
        private List<MessageInfo> _messages = new List<MessageInfo>();
      
        #endregion

        #region Data Members
        /// <summary>
        /// IsValid
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int ResponseId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public string ResponseIdStr { get; set; }
        /// <summary>
        /// Messages
        /// </summary>
         public List<MessageInfo> Messages { get => _messages; set => _messages = value; }

        /// <summary>
        /// Messages
        /// </summary>
        public List<Parameter> OutputParameters { get; set; }

        #endregion

        #region Public Methods

        public string Message()
        {
            StringBuilder sbMsg = new StringBuilder();

            if (this.Messages != null)
            {
                foreach (MessageInfo info in this.Messages)
                {
                    if (sbMsg.Length > 0)
                    {
                        sbMsg.Append(" ");
                    }
                    sbMsg.Append(info.Message);
                }
            }
            return sbMsg.ToString();
        }

        #endregion

    }
}
