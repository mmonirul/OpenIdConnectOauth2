﻿using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace WestPay.Auth.Configurations
{
    public class Users
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "7E8BB676-A15F-485A-99AE-D59086538E5E",
                    Username = "moni@westpay.se",
                    Password = "Password@1234!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "moni@westpay.se"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "6C7F0FB4-939C-440D-B87C-C7FE9F327F5B",
                    Username = "user@westpay.se",
                    Password = "Password@1234!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "user@westpay.se"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                },
                new TestUser
                {
                    SubjectId = "CAB52483-1B4C-45A8-828B-10D5AE816241",
                    Username = "paiduser@westpay.se",
                    Password = "Password@1234!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "paiduser@westpay.se"),
                        new Claim(JwtClaimTypes.Role, "paid-user")
                    }
                }

            };
        }
    }
}