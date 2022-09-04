namespace Gateway.Configuration
{
    public class Routes
    {
        public string Path { get; set; }
        public string Method { get; set; }
    }

    public class GatewayConfig
    {
        public IEnumerable<Routes> Routes { get; set; }
    }
}
