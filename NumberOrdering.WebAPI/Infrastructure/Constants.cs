namespace NumberOrdering.WebAPI.Infrastructure
{
    public static class Constants
    {
        public static class HttpCodesErrorMessages
        {
            public static string NotFound(string resourceName) => $"Not Found {resourceName}";
        }

        public static class FileErrorMessages
        {
            public static string IncorrectContentFormat = "Error a file Content has an incorrect format";
        }
    }
}
