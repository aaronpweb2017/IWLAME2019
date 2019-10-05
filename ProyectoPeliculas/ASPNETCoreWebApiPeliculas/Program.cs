using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ASPNETCoreWebApiPeliculas
{
    public class Program
    {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).UseUrls("https://192.168.1.68:443").Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}