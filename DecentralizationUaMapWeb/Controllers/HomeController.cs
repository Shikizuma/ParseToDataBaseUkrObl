using DecentralizationGovUa.Services;
using DecentralizationUaMapWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace DecentralizationUaMapWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] IConfiguration configuration)
        {
            ViewBag.Key = configuration["key_map"]!;
            return View();
        }

        public async Task<IActionResult> Privacy([FromServices] GeoPointService geoPointService)
        {
            var response = await geoPointService.SelectAllGeoPointsFromCommunities();
            if (response == null)
            {

            }
            return Json(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}