using Microsoft.AspNetCore.Mvc;
using QLKS_NGOMANTHUAN_25TH2532.Models;
using System.Diagnostics;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
