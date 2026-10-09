using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_JHL.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Check(int id)
        {
            if (id == 1) {
                return Json(new { id = 1, name = "Mahir", CGPA = 3.98 });   //anonymous object
            }

            else if (id == 2)
            {
                return Redirect("https://portal.aiub.edu/Login");
            }

            else if (id == 3)
            {
                return RedirectToAction("Privacy","Home");
            }

            else if (id == 4)
            {
                var cssFile = System.IO.File.ReadAllBytes("wwwroot/css/site.css");

                return File(cssFile, "text/css", "FarhatCSS.css");
            }

            else
            {
                return NotFound();
            }
        }

        public IActionResult List()
        {
            ViewBag.Title = "Course List: ";
            ViewData["desc"] = "This is the description of this page";
            return View();

        }

        public IActionResult Details(int cid)
        {
            ViewBag.message = "This is the details of Course " + cid;
            return View();
        }
    }
}
