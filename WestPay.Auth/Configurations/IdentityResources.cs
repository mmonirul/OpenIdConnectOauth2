using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace WestPay.Auth.Configurations
{
    public class IdentityRes
    {
        public static IEnumerable<IdentityResource> All()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource 
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };
        }
    }
}
