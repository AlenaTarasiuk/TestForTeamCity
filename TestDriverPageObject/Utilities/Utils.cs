namespace AutomatedTest.Utilities
{
    public static class Utils
    {
        public static readonly string username = System.Configuration.ConfigurationSettings.AppSettings["username"];
        public static readonly string password = System.Configuration.ConfigurationSettings.AppSettings["password"];

        public static readonly string themeLetter =
            System.Configuration.ConfigurationSettings.AppSettings["themeLetter"];

        public static readonly string messageUser =
            System.Configuration.ConfigurationSettings.AppSettings["messageUser"];

        public static readonly int timeout =
            int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TimeoutSeconds"]);

        public static readonly string BaseUrl = System.Configuration.ConfigurationSettings.AppSettings["BaseUrl"] +
                                                System.Configuration.ConfigurationSettings.AppSettings["DraftsPage"];

        public static readonly string emptyMessage =
            System.Configuration.ConfigurationSettings.AppSettings["emptyMessage"];

        public static readonly string BaseUrlIndoxPage =
            System.Configuration.ConfigurationSettings.AppSettings["BaseUrl"] +
            System.Configuration.ConfigurationSettings.AppSettings["InboxPage"];

        public static readonly string BaseUrlLoginPage =
            System.Configuration.ConfigurationSettings.AppSettings["LoginPage"];

        public static readonly string BaseUrlSentPage =
            System.Configuration.ConfigurationSettings.AppSettings["BaseUrl"] +
            System.Configuration.ConfigurationSettings.AppSettings["SentPage"];
    }
}