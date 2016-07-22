namespace Common.Objects.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ApiSecurityToken : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                ValidateRequestCookie(actionContext);
            }
            catch (Exception ex)
            {
                throw new Exception("This is not an authorized request");
            }
        }

        private void ValidateRequestCookie(HttpActionContext actionContext)
        {
            var request = System.Web.HttpContext.Current.Request;

            if (!request.IsLocal)
            {
                if (!request.IsSecureConnection)
                {
                    throw new Exception();
                }
                else
                {
                    var cookieToken = String.Empty;
                    var formToken = String.Empty;

                    var header =
                        actionContext
                        .Request
                        .Headers
                        .GetValues(ConfigurationManager.AppSettings["AnitForgeryTokenKey"]);

                    if (header != null && header.Count() == 1)
                    {
                        var tokenValue = header.First();

                        if (!String.IsNullOrEmpty(tokenValue))
                        {
                            string[] tokens = tokenValue.Split(':');
                            if (tokens.Length == 2)
                            {
                                cookieToken = tokens[0].Trim();
                                formToken = tokens[1].Trim();
                            }
                        }
                    }

                    AntiForgery.Validate(cookieToken, formToken);
                }
            }
        }
    }
}
