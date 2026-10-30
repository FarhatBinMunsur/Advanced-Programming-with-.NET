using Errors_JHL_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Errors_JHL_4.Controllers
{
    public class FacultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var deptList = new List<SelectListItem>();

            var male = new SelectListItem();
            male.Text = "CSE";
            male.Value = "1";
            deptList.Add(male);

            //Or we can do this way
            deptList.Add(new SelectListItem
            {
                Text = "EEE",
                Value = "2"
            });

            deptList.Add(new SelectListItem("BBA", "3"));

            ViewBag.deptList = deptList;

            return View(new Faculty());
        }

        [HttpPost]
        public IActionResult Create(Faculty student)
        {

            //Dropdown Data
            /*
            var deptList = new List<SelectListItem>();

            var male = new SelectListItem();
            male.Text = "CSE";
            male.Value = "1";
            deptList.Add(male);

            //Or we can do this way
            deptList.Add(new SelectListItem
            {
                Text = "EEE",
                Value = "2"
            });

            deptList.Add(new SelectListItem("BBA", "3"));

            ViewBag.deptList = deptList;
            */

            //OOP approach
            this.LoadSupportingData();


            //Validation
            //Error - stay in the same page
            //No Error - Success page
            if (student.Name == "Mahir")
            {
                ModelState.AddModelError("Name", "Mahir Already Exists");   //will show in asp-validation-summary="All"
            }

            if (student.Age == 8)
            {
                ModelState.AddModelError("", "Age cant be 8");       //will show in asp-validation-summary="ModelOnly"
            }


            /*dept cse,age < 18 ; cant enroll
                if(student.Age<18 && student.Dept == "1")
                {
                    ModelState.AddModelError("","Age must be grater than 18 to enroll in CSE");
                }
            */



            //calculate age from given DOB
            var dt = student.Dob;
            var age = (DateTime.Now - dt).TotalDays / 365;
            student.Age = (int)age;         //age field will be filled with this age value

            //error
            if (!ModelState.IsValid)
            {
                return View(student);
            }




            else
            {
                return View("Success", student);
            }


            //return View(student);
        }



        //customFunction to make it easier to work with supporting data
        private void LoadSupportingData()
        {
            var deptList = new List<SelectListItem>();

            var male = new SelectListItem();
            male.Text = "CSE";
            male.Value = "1";
            deptList.Add(male);

            //Or we can do this way
            deptList.Add(new SelectListItem
            {
                Text = "EEE",
                Value = "2"
            });

            deptList.Add(new SelectListItem("BBA", "3"));

            ViewBag.deptList = deptList;
        }
    }
}
