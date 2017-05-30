using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using IdentityServerFour.Configuration;
using IdentityServer4.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Net.Http;
using IdentityModel;

namespace IdentityServerFour.Extentions
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public  Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            GrantValidationResult grantValidationResult = null;
            var result = _userService.CheckPasswordAsync(context.UserName, context.Password).Result;
            ResponseInfoGeneric<SessionTokenInfo> sessTokenInfoResponse = null;
            if (result != null && result.Content != null)
            {

                sessTokenInfoResponse = result.Content.ReadAsAsync<ResponseInfoGeneric<SessionTokenInfo>>().Result;
            }


            if (sessTokenInfoResponse != null && sessTokenInfoResponse.IsValid)
            {
                var claims = new List<Claim>
                    {

                        //new Claim(JwtClaimTypes.GivenName, sessTokenInfoResponse.Info.FirstName),
                        //new Claim(JwtClaimTypes.FamilyName, sessTokenInfoResponse.Info.LastName),
                        new Claim("MemberId", sessTokenInfoResponse.Info.MemberId),
                        new Claim("IsValid", sessTokenInfoResponse.IsValid.ToString()),
                        new Claim("ResponseIdStr", sessTokenInfoResponse.ResponseIdStr),
                        new Claim("ResponseId", sessTokenInfoResponse.ResponseId.ToString()),
                        new Claim(JwtClaimTypes.SessionId,sessTokenInfoResponse.Info.SessionId),
                        new Claim("SessionInfoToken", sessTokenInfoResponse.Info.Token),
                         new Claim("OLbWebUser", new StringBuilder(sessTokenInfoResponse.Info.FirstName)
                         .Append(sessTokenInfoResponse.Info.LastName).ToString())

                    };


                grantValidationResult = new GrantValidationResult(subject: context.Request.Subject.ToString(), authenticationMethod: "custom", claims:claims);
            }
            else
            {
                var errorMsgs = new StringBuilder();
                foreach (var msg in sessTokenInfoResponse.Messages)
                {
                    errorMsgs.AppendLine(msg.MessageCode + ":" + msg.Message);

                }
                grantValidationResult = new GrantValidationResult(TokenRequestErrors.InvalidGrant,errorMsgs.ToString()/* "invalid custom credential"*/);
            }
            context.Result = grantValidationResult;
            return Task.FromResult(grantValidationResult);
        }

       
    }
}
