namespace DecentralizationUaMapWeb.Extensions
{
    public static class WebAppExtensions
    {
        public static WebApplicationBuilder AddMapConfigure(this WebApplicationBuilder web)
        {
            var provider = web.Services.BuildServiceProvider();
            var hostEnv = provider.GetService<IWebHostEnvironment>();
            var mapKey = Path.Combine(hostEnv.WebRootPath, "keys", "configure.json");
            web.Configuration.AddJsonFile(mapKey);

            return web;
        }
    }
}
