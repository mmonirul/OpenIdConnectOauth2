using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.API.Authorization
{
    public class SuperAdminOrOwnerRequirement : IAuthorizationRequirement
    {
        public SuperAdminOrOwnerRequirement()
        {

        }
    }
}
