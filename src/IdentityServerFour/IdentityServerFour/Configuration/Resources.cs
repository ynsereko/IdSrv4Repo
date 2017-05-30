using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Configuration
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Address(),
            new IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource {
                Name = "api1",
                DisplayName = "API One",
                Description = "API One Access",
                Enabled = true,
                /*include the follwing user claims in access token - in addition to subject, id*/
                UserClaims = new List<string> {"role"},
                ApiSecrets = new List<Secret> {new Secret("superSecretPassword".Sha256())},
                Scopes = new List<Scope> {
                    new Scope("api1.read", "API 1 READ"),
                     new Scope("api1.write", "API 1 WRITE")
                }
            },
            new ApiResource {
                Name = "customAPI",
                DisplayName = "Custom API",
                Description = "Custom API Access",
                UserClaims = new List<string> {"role"},
                ApiSecrets = new List<Secret> {new Secret("superSecretPassword".Sha256())},
                Scopes = new List<Scope> {
                    new Scope("customAPI.read"),
                    new Scope("customAPI.write")
                }
            }
        };
        }
    }
}
