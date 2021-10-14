using SecuredAPI.SharedKernel.Contracts;

namespace SecuredAPI.Identity.Configuration
{
    public class ClientSettings : IClientSettings
    {
        public const string CONFIG_NAME = "ClientSettings";

        public static ClientSettings Instance { get; } = new ClientSettings();
        private ClientSettings() { }

        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
