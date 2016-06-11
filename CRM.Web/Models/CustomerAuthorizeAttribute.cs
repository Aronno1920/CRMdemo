using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Web.Models
{
    //public class CustomerAuthorizeAttribute : AuthorizeAttribute
    //{
    //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        throw new NotAuthorizedHttpException(Roles);
    //    }
    //}
    //public class NotAuthorizedHttpException : HttpException
    //{
    //    public NotAuthorizedHttpException(string missingRoles)
    //      : base(401, string.Format("You do not have the required role(s) '{0}'.", string.Join(", ", missingRoles)))
    //    {
    //    }
    //}
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomerAuthorizeAttribute : AuthorizeAttribute
    {
        public string RedirectUrl = "~/Error/Unauthorize";

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(RedirectUrl);
            }
        }
    }
}