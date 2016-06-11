using CRM.Entity.Authentication;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Authentication
{
  public static  class GenerateUserIdentity
    {
        public static async Task<ClaimsIdentity>
           GenerateUserIdentityAsync(ApplicationUserManager manager, ApplicationUser user)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
