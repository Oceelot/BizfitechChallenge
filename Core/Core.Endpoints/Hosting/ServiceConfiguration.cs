using System.Configuration;

namespace Core.Endpoints.Hosting
{
    public class ServiceConfiguration
    {
        public int PortNumber { get; set; }
        public string HostName { get; set; }
        public string Scheme { get; set; }
        public string Path { get; set; }

        public ServiceConfiguration()
        {
            PortNumber = int.Parse(ConfigurationManager.AppSettings["port"]);
            HostName = ConfigurationManager.AppSettings["server"];
            Scheme = ConfigurationManager.AppSettings["scheme"];
            Path = ConfigurationManager.AppSettings["path"];
        }
        public string Url()
        {
            var url = $"{Scheme}://{HostName}:{PortNumber}{Path}";
            if (!url.EndsWith("/"))
                url += "/";
            return url;
        }
    }
}