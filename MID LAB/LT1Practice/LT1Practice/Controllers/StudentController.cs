using LT1Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace LT1Practice.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(Student st)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Student = st;
                return View();
            }
            return View("Create");
            
        }

        public IActionResult Create() { 
            return View();
        }

        public IActionResult Details(int id,string name,string cgpa,string dept)
        {
            ViewBag.id=id;
            ViewBag.name = name;
            ViewBag.cgpa = cgpa;
            ViewBag.dept=dept;
            return View();
        }

        
    }
}
