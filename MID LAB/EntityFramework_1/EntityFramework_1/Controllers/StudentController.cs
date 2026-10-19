using EntityFramework_1.EF;
using EntityFramework_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Runtime.CompilerServices;


namespace EntityFramework_1.Controllers
{
    public class StudentController : Controller
    {

        private readonly AppDbContext adc;

        public StudentController(AppDbContext adc)
        {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            var students = adc.student.ToList(); //List<Student> students = adc.student.ToList();       -> so students type is List
            //return Json(students);

            return View(students);
        }

        public IActionResult Create()
        {
               return View();

        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var students = adc.student.Add(student);
                adc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id) { 
            var students =adc.student.FirstOrDefault(s=>s.id==id);

            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        [HttpPost]
        public IActionResult Update(int id,Student student)
        {
            if (ModelState.IsValid) {
                var std = adc.student.FirstOrDefault(s => s.id == id);

                if (std == null)
                {
                    return NotFound();
                }

                std.name = student.name;
                std.cgpa=student.cgpa;
                std.email = student.email;
                adc.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Index");
            

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var std=adc.student.FirstOrDefault(s=>s.id==id);

            if(std == null)
            {
                return NotFound();
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (ModelState.IsValid)
            {
                var std = adc.student.FirstOrDefault(s => s.id == id);

                adc.student.Remove(std);
                adc.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");

        }

        public IActionResult Filter(string cgfilter)
        {
            double cg =Double.Parse(cgfilter);

            var students = adc.student.Where(s=>s.cgpa>=cg).ToList(); //List<Student> students = adc.student.ToList();       -> so students type is List
            //return Json(students);

            return View("Index",students);


        }
    }
}
