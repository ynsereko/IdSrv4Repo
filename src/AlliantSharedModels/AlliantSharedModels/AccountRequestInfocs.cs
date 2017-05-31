using System;
using System.Collections.Generic;
using System.Text;
using static AlliantSharedModels.Enums;

namespace AlliantSharedModels
{
    public class AccountRequestInfo
    {
        /// </summary>

        public string Id { get; set; }

        /// <summary>
        /// get/set is load closed boolean value
        /// </summary>

        public bool LoadClosed { get; set; }
        /// <summary>
        /// check if request is for light account info
        /// </summary>

        public bool IsLight { get; set; }
        /// <summary>
        /// get/set accounttype
        /// </summary>

        public AccountType AccountType { get; set; }

        /// <summary>
        /// Filter Required flag indicated service to append default select and where filters.
        /// </summary>

        public bool FilterRequired { get; set; }

        /// <summary>
        /// get/set string, To get the other member Loan and share information
        /// </summary>

        public string OtherMemberId { get; set; }
    }
}
