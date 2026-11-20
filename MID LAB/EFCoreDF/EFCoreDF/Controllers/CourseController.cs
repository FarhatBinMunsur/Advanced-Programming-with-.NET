 using EFCoreDF.EF;
using EFCoreDF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics.Contracts;

namespace EFCoreDF.Controllers
{
    public class CourseController : Controller
    {
        private DotNetContext _context;

        public CourseController(DotNetContext context)
        {
            _context = context;

        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();


            return View(courses);
        }

        public IActionResult Delete(int id)
        {

            var crs = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (crs != null)
            {
                _context.Courses.Remove(crs);
                _context.SaveChanges();
                return Content("Deleted");
            }

            return RedirectToAction("Courses");
        }

        public IActionResult Update(int id)
        {
            var crs = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (crs != null)
            {
                return View(crs);
            }

            return NotFound();
        }

        public IActionResult Save(int id, Course ucrs)
        {
            if (ModelState.IsValid)
            {
                var crs = _context.Courses.FirstOrDefault(c => c.Id == id);

                if (crs == null)
                {
                    return NotFound();
                }

                crs.CourseName = ucrs.CourseName;
                crs.Credit = ucrs.Credit;
                _context.SaveChanges();

                return RedirectToAction("Courses");

            }


            return RedirectToAction("Courses");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Course crs)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(crs);
                _context.SaveChanges();

                return RedirectToAction("Courses");
            }
            return View();

        }

        //Login - Added Later
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(int Id,Student st)
        {
            var std = _context.Students.FirstOrDefault(s=>s.Id == Id);

            if (std != null)
            {

                if (Id == std.Id && st.Password == std.Password)
                {
                    //return Content("Login Success");
                    return RedirectToAction("Courses");
                }

            }

            TempData["login_Error"] = "Invalid UN or Pass!";
            return View();




        }
    }
}
