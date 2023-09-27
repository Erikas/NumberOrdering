namespace NumberOrdering.WebAPI.Infrastructure
{
    public static class Constants
    {
        public static class HttpCodesErrorMessages
        {
            public static string NotFound(string resourceName) => $"Not Found {resourceName}";
            public const string InternalServerError = "Something went wrong. A code monkey is fixing it";
        }
    }
}
