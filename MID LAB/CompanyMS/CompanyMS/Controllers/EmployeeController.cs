using CompanyMS.EF;
using CompanyMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyMS.Controllers
{
    public class EmployeeController(CompanyDbContext context) : Controller
    {
        public IActionResult Index()
        {
            
            var emp= context.Employees.OrderByDescending(e=>e.JoinedAt).ToList();

            if (emp == null)
            {
                ViewData["Nodata"] = "No Employee found";
            }
            return View(emp);
        }

        public IActionResult Update(int id) {
            var emp = context.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Update(Employee emp) {

            if (ModelState.IsValid)
            {
                context.Employees.Update(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp= context.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SeniorEmployees()
        {
            var emp = context.Employees.Where(e => e.ExperienceYears>=5).ToList();

            return View("Index",emp);
        }

        public IActionResult DeptAvg()
        {
            var result = context.Employees
                        .GroupBy(e => e.Department)
                        .Select(g => new
                        {
                            Department = g.Key,
                            AverageSalary = g.Average(e => e.Salary)
                        })
                        .OrderByDescending(x => x.AverageSalary)
                        .ToList();

            ViewBag.deptavg= result;
            return View();

        }

        [Route("Employee/hppd")]
        public IActionResult HighestPaidPerDepartment()
        {
            var result = context.Employees
                .GroupBy(e => e.Department)
                .Select(g => g.OrderByDescending(e => e.Salary).First())
                .ToList();

            ViewBag.MaxExperience = result.Max(e => e.ExperienceYears);

            return View(result);
        }
    }
}
