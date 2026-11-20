using EFCoreDFPractice.EF;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EFCoreDFPractice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context= context;
        }


        public IActionResult Index()
        {
           
            
            var emp = _context.Employees.OrderByDescending(e => e.JoinedAt).ToList();
            

            if (emp.Count == 0)
            {
                ViewBag.empty = "No records Found";
            }

            return View(emp);
        }

        public IActionResult SeniorEmployees()
        {
            var emp=_context.Employees.Where(e=>e.ExperienceYears>5).OrderByDescending(e=>e.Salary).ToList();

            return View("Index",emp);
        }

        public IActionResult DepartmentAverage()
        {
            //SELECT Depertment AS Dept,AVG(Salary) AS avgSal FROM Employees GROUP BY Depertment;
            var dept = _context.Employees.GroupBy(e => e.Depertment).Select(g=>new { Dept= g.Key, avgSal=g.Average(em=>em.Salary)}).ToList();

            return View(dept);
        }

        public IActionResult HighestPaid()

        {
            //select empname, salary from Employee e where salary=(select max(Salary) from Employee where Depertment=e.depertment) 

            return NotFound();
        }



    }
}
