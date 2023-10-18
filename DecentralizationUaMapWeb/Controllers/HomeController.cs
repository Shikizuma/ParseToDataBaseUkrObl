using DecentralizationUaMapWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace DecentralizationUaMapWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static string Token = GetJson("C:\\Users\\myros\\source\\repos\\ParseToDataBaseUkrObl\\DecentralizationUaMapWeb\\configure.json");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Key = Token;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static string GetJson(string filePath)
        {
            string key = string.Empty;

            try
            {
                string jsonString = System.IO.File.ReadAllText(filePath);
                JObject json = JObject.Parse(jsonString);
                key = (string)json["key_map"]!;
                return key;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зчитуванні JSON файлу: {ex.Message}");
                return "";
            }
        }
    }
}