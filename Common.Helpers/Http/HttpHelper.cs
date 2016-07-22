namespace Common.Helpers.Http
{
    using System.Web;
    using Common.Helpers.Configuration;

    public static class HttpHelper
    {
        public static string GetCookieValue(string name)
        {
            var returnValue = string.Empty;

            var request = HttpContext.Current.Request;

            var cookie = request.Cookies[ConfigHelper.AnitForgeryTokenKey];

            if (cookie != null)
            {
                returnValue = cookie.Value;
            }

            return returnValue;
        }

        public static void SetCookie(string name, string value)
        {
            var request = HttpContext.Current.Request;
            var response = HttpContext.Current.Response;

            var cookie = request.Cookies[name];

            if (cookie != null)
            {
                response.Cookies.Remove(name);
            }

            response.Cookies.Add(new HttpCookie(name, value));
        }
    }
}
