namespace MetroOffice.AuthServer.Domain
{
    public class AuthServerDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string? DbSchema { get; set; } = null;

        public const string ConnectionStringName = "IdentityService";

        public const string DefaultAdminEmailAddress = "admin@metrooffice.in";

        public const string DefaultAdminPassword = "12345_qwerty";
    }
}
