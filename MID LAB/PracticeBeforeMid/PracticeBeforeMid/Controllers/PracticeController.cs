using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PracticeBeforeMid.Models;

namespace PracticeBeforeMid.Controllers
{
    public class PracticeController : Controller
    {
        [HttpGet("{name}/{id}")]
        public IActionResult Index([FromRoute]string name,[FromRoute]int id)
        {
            return Ok($"Name= {name} + id= {id}");
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]string name,[FromForm]int id)
        {
            return Ok($"Name= {name} + id= {id}");
        }

        [Route("rp")]
        public IActionResult RegisterPassport()
        {
            ViewBag.depts = this.LSD();
            return View();
        }


        [Route("rp")]
        [HttpPost]
        public IActionResult RegisterPassport(Passport pp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.depts = this.LSD();
                return View();
            }

            ViewBag.Success = "Success";
            return View();
        }


        public List<SelectListItem> LSD()
        {
            var depts = new List<SelectListItem>(){ new SelectListItem { Text = "CSE", Value = "cse" }, new SelectListItem { Text = "EEE", Value = "eee" } };

            depts.Add(new SelectListItem()
            {
                Text = "COE",
                Value = "coe"
            });

            return depts;
        }

    }
}
