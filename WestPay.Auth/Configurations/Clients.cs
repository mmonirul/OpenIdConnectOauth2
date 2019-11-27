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
                        "roles",
                        "west-test-api",
                        "country",
                        "subscriptionlevel"
                    }
                },
                new Client 
                {
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
                        "WestApi.write",
                        "country",
                        "subscriptionlevel"
                    },
                    RedirectUris = new List<string> 
                    {
                        "https://localhost:44330/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string> 
                    {
                        "https://localhost:44330/signout-callback-oidc"
                    }
                },
                new Client
                {
                    ClientId = "ngImplicitClient",
                    ClientName = " Angular SPA implicit/hybrid client",

                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    
                    IdentityTokenLifetime = 30,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200",
                        "http://localhost:4200/auth-callback"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/unauthorized",
                        "http://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "west-test-api",
                        "country",
                        "subscriptionlevel"
                    },
                }
            };
        }
    }
}
