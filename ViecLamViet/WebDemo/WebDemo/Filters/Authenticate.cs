using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Utils;

namespace WebDemo.Filters
{
    public class AuthenticateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (XSession.User == null)
            {
                XSession.ReturnUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}