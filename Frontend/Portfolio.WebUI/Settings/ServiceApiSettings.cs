namespace Portfolio.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public ServiceApi Portfolio { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
