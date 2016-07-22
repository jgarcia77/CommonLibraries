namespace Common.Objects.Attributes
{
    using System;
    using System.Web.Mvc;
    using System.Web.Helpers;
    using System.Web;
    using System.Configuration;


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RequireAntiForgeryToken : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                ValidateRequestCookie(filterContext.HttpContext.Request);
            }
            catch (HttpAntiForgeryException ex)
            {
                throw new HttpAntiForgeryException("Anti forgery token cookie not found");
            }
        }

        private void ValidateRequestCookie(HttpRequestBase request)
        {
            if (!request.IsLocal && request.IsSecureConnection)
            {
                var cookieToken = String.Empty;
                var formToken = String.Empty;

                var cookie = request.Cookies[ConfigurationManager.AppSettings["AnitForgeryTokenKey"]];

                if (cookie != null)
                {
                    var tokenValue = cookie.Value;

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
