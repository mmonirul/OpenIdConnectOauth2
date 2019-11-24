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
                },
                new Client {
                    ClientId = "openIdConnectMvcClient",
                    ClientName = "Example Hybrid/Implicit MVC Client Application (Library)",
                    ClientSecrets = new List<Secret> {
                        new Secret("secret".Sha256()),
                    },
                    AllowedGrantTypes = GrantTypes.Hybrid, //GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "west-test-api",
                        "WestApi.write"
                    },
                    RedirectUris = new List<string> 
                    {
                        "https://localhost:44330/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string> 
                    {
                        "https://localhost:44330/signout-callback-oidc"
                    }
                }
            };
        }
    }
}
