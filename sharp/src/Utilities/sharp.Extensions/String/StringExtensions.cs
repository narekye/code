using sharp.Extensions.Constants;
using System.Net;
using System.Text.RegularExpressions;

namespace sharp.Extensions.String
{
    public static class StringExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(Regexes.IsValidEmailAddressRegex);
            return regex.IsMatch(s);
        }

        public static bool IsValidUrl(this string text)
        {
            Regex rx = new Regex(Regexes.IsValidUrlRegex);
            return rx.IsMatch(text);
        }

        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", string.Empty);
        }

        public static bool UrlAvailable(this string httpUrl)
        {
            if (!httpUrl.StartsWith(HttpConstant.Http) || !httpUrl.StartsWith(HttpConstant.Https))
                httpUrl = HttpConstant.Http + httpUrl;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(httpUrl);
                myRequest.Method = HttpConstant.GET;
                myRequest.ContentType = ContentType.XFormUrlEncoded;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
