using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata;

namespace Practice_Form.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(string name, string email, int age, DateTime dob,string pass,int sthr,string gender,string[] pd,string dept,string addr,IFormFile dp,string role,string type)
        {
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.age= age;
            ViewBag.pass = pass;
            ViewBag.gender = gender;
            ViewBag.sthr = sthr;
            ViewBag.dob=dob.ToString("dd-MM-yyyy");         //***
            ViewBag.pd=string.Join(",",pd);                //***
            ViewBag.dept=dept;
            ViewBag.addr=addr;
            ViewBag.dp=dp.FileName;
            ViewBag.role=role;
            ViewBag.type=type;
            

            return View();
        }
    }
}
