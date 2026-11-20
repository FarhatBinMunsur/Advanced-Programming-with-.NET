using EFCoreCF.EF;
using EFCoreCF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCF.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext adc;
        public StudentController(AppDbContext adc) {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            Depertment dt = new Depertment
            {
                //Deptname = "CSE"
                Deptname = "EEE"
            };


            //CSE 2 bar add hoi gesilo, oita delete korlam
            //var deletedept=adc.Depertments.FirstOrDefault(d => d.Deptname == "EEE");
            //adc.Depertments.Remove(deletedept);
            //adc.SaveChanges();

            //adc.Depertments.Add(dt);
            //adc.SaveChanges();


            return View();
        }

    }
}
