using System;
using Nancy.Hosting.Self;
using SevenDigital.Content.Ingestion.Spike.Web;

namespace SevenDigital.Content.Ingestion.Spike.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            DefaultModule importThisToGetTheHostingToSeeTheDll;

            var address = "http://localhost:1212";
            Console.WriteLine("Starting Content Ingestion Spike Host...");
            var host = new NancyHost(new Uri(address));
            host.Start();
            Console.WriteLine("Started at: {0}", address);
            Console.WriteLine("Press the any key to stop the service.");
            Console.ReadKey();
            host.Stop();
        }
    }
}
