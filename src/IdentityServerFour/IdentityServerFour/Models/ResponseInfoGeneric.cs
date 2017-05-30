using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IdentityServerFour.Extentions
{
  
    public class ResponseInfoGeneric<T> : ResponseInfo
    {
        private T _info;

        /// <summary>
        /// Info Object of any type.
        /// </summary>
         public T Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /// <summary>
        /// Base class
        /// </summary>
        public ResponseInfo Response
        {
            set
            {
                IsValid = value.IsValid;
                Messages = value.Messages;
                //OutputParameters = value.OutputParameters;
                ResponseId = value.ResponseId;
                ResponseIdStr = value.ResponseIdStr;
            }
        }

    }
}
