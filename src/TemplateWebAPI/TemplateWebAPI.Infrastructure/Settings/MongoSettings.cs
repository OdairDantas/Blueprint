namespace $safeprojectname$.Settings
{
    public static class MongoSettings
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
    }
}
