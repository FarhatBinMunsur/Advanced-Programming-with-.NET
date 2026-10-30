using LabTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabTask.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student st)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = st.Fullname;
                ViewBag.email = st.Email;
                ViewBag.crcd = st.CourseCode;
                ViewBag.crh = st.creditHr;
                ViewBag.semf = st.Semfee;
                return View();
            }

            return View("Create");
            
        }
    }
}
