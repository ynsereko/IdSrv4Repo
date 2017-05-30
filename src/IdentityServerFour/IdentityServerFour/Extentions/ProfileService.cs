using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServerFour.Extentions
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userService;

        public ProfileService(IUserService userService)
        {
            _userService = userService;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context.Subject != null || context.Subject.Claims.Any())
            {
                /*Claims Issued during authentication process*/
                context.IssuedClaims = context.Subject.Claims.ToList();
            }
            return Task.FromResult(0);


            // issue the claims for the user
            //var user = Users.SingleOrDefault(x => x.Subject == context.Subject.GetSubjectId());
            //if (user != null)
            //{
            //    context.IssuedClaims = user.Claims.Where(x => context.RequestedClaimTypes.Contains(x.Type));
            //}
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = context?.Subject != null;
            return Task.FromResult(0);
        }
    }
}
