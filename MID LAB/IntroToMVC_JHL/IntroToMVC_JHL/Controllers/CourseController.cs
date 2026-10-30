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
                return Json(new { id = 2, name = "Jahid", CGPA = 3.98 });   //anonymous object
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
            else if (id == 5)
            {
                //return RedirectToAction("check", "course" ,"5");    //LOOP - Give [ERR_TOO_MANY_REDIRECTS]
                int cid = id;
                return RedirectToAction("details", "course", new {cid=id}); //3rd parameter of RedirectToAction() expects an object containing route values,not an integer directly
            }
            else
            {
                return RedirectToAction("Index","course");
            }
        }

        public IActionResult List()
        {
            ViewBag.Title = "Course List: ";
            ViewData["desc"] = "This is the description page";      //dictionary
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.message = "This is the details of Course " + id;

            if (id == 1) {
                ViewBag.name = "IP";
            }


            else if (id == 2)
            {
                ViewBag.name = "Java";
            }


            else if (id == 3)
            {
                ViewBag.name = "C#";
            }
            return View();
        }
    }
}
