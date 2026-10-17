using Microsoft.AspNetCore.Mvc;

namespace Designing_JHL_2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(string name,string age)
        {
            ViewBag.name=name;
            ViewBag.age=age;

            return View();
        }
    }
}
