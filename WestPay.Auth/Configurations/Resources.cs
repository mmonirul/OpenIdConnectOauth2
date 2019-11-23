﻿using IdentityServer4.Models;
using System.Collections.Generic;

namespace WestPay.Auth.Configurations
{
    internal class Resources
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[] {
                new ApiResource
                {
                    Name = "WestApi",
                    DisplayName = "Westpay APIs",
                    Description = "Westpay resource access",
                    UserClaims = new List<string> { "role"},
                    ApiSecrets = new List<Secret> { new Secret("scopeSecret".Sha256()) },
                    Scopes = new List<Scope>
                    {
                        new Scope("WestApi.read"),
                        new Scope("WestApi.write")
                    }

                },
                new ApiResource("west-test-api", "Westpay test apis")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
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