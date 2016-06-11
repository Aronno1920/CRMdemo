using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class ExtendedIdentityModels : RegisterViewModel
    {
        public HttpPostedFileBase UserProfilePicture { get; set; }
    }
}