using IntroToMVC_Week2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroToMVC_Week2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()

        {
            //List<string> name=new List<string>();
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
