namespace Common.Helpers.Http
{
    using System.Web.Helpers;
    using Common.Helpers.Http;
    using Common.Helpers.Configuration;

    public static class SecurityHelper
    {
        public static string GetAntiForgeryToken()
        {
            return HttpHelper.GetCookieValue(ConfigHelper.AnitForgeryTokenKey);
        }

        public static string GenerateAntiForderyToken()
        {
            string cookieToken, formToken;
            AntiForgery.GetTokens(null, out cookieToken, out formToken);

            var token = string.Concat(cookieToken, ":", formToken);

            return token;
        }
    }
}
