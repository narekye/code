namespace sharp.Extensions.Constants
{
    public static class ContentTypes
    {
        public const string XFormUrlEncoded = "application/x-www-form-urlencoded";
        public const string Json = "application/json";
    }

    public static class HttpConstants
    {
        public const string Http = "http://";
        public const string Https = "https://";
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
    }

    public static class Regexes
    {
        public const string IsValidUrlRegex = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        public const string IsValidEmailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }

    public static class Exceptions
    {
        public const string ArgumentCannotBeNull = "Argument cannot be null";
    }
}
