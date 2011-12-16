using Nancy;

namespace SevenDigital.Content.Ingestion.Spike.Web
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            Get["/"] = _ => "Alive, but not really doing anything";
        }
    }
}
