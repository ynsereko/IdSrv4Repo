using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantSharedModels
{
    public class RequestInfo<T>
    {

        public T Info
        {

            get;
            set;
        }


        public SessionTokenInfo TokenInfo { get; set; }


    }
}
