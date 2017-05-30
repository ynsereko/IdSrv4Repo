using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerFour.Extentions
{
    public interface IUserService
    {
       Task<HttpResponseMessage> CheckPasswordAsync(string userName, string password);
        Task<List<Claim>> GetClaimsAsync(string userName);
    }
}