using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantSharedModels
{
    public class SessionTokenInfo
    {
        #region Public Properties


        public string Token { get; set; }


        public int UserId { get; set; }


        public string Username { get; set; }


        public string SessionId { get; set; }


        public string SystemId { get; set; }


        public DateTime InitiatedOn { get; set; }


        public DateTime ExpiresOn { get; set; }


        public string MemberId { get; set; }


        public string ReferenceId { get; set; }


        public int AuthenticationLevel { get; set; }


        public int TellerId { get; set; }


        public DateTime LastAccessedDate { get; set; }


        public int ExpirationDurationMinutes { get; set; }

        public string ServerName { get; set; }



        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        #endregion
    }
}
