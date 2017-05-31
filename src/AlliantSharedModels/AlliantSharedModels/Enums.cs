using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
//using System.Runtime.Serialization;

namespace AlliantSharedModels
{
    public class Enums
    {
        public enum AccountType
        {
            [EnumMember]
            NOTSET = 0,
            [EnumMember]
            Share = 1,
            [EnumMember]
            CreditCard = 2,
            //[EnumMember]
            Loan = 3,
            [EnumMember]
            Mortgage = 4,
            [EnumMember]
            FICS = 5,
            [EnumMember]
            DebitCard = 6
        }
    }

    public enum MessageType : int
    {


        Information = 0,


        Warning = 1,


        Error = 2,


        AccountTypeRestriction = 3,


        Success = 4,


        UNKNOWN = -1,
    }
}
