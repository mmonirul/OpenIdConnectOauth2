using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Auth.Configurations
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[] {
                new Client
                {
                    ClientId = "west-admin",
                    ClientSecrets = new List<Secret> {
                        new Secret("secret".Sha256()),
                        new Secret("superSecretPassword".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "west-test-api",
                        "WestApi.read"
                    }
                }
            };
        }
    }
}
