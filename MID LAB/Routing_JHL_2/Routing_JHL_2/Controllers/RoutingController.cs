using Microsoft.AspNetCore.Mvc;

namespace Routing_JHL_2.Controllers
{
    [Route("farhat")]
    public class RoutingController : Controller
    {
        [Route("First/{id?}")]
        [Route("First/Conflict/{id?}")]
        public IActionResult Index(int? id)
        {
            ViewBag.id= id;
            return View();
        }

        [Route("second/{p1:int?}/{p2:int:min(10)?}")]
        public IActionResult Twoparam(int p1,int p2)
        {
            var result = p1 + p2;
            return Content(result.ToString() +" "+ p1+p2);

            //return Content(p1.ToString()+p3.ToString());
        }

        [Route("Testing")]
        [Route("mahir/Test")]
        [Route("[Controller]/[Action]")]
        public IActionResult TestName() => Content("Farhat mahir");
        

        //Ques-Ans
        [Route("getday/{year:min(1900):max(9999):length(4)}/{month:int:min(1):max(12)}/{day:int:min(1):max(31)}")]
        public IActionResult getdayofDate(int year,int month,int day)
        {
            if (month == 2 && day>28) {
                return Content("Invalid Date");
            }
            return Content("The day of " + $"{day}/{month}/{year}" + " was: I dont know!");

        }

        [Route("R3")]
        public IActionResult Testing() => Content("mahir");


        //Explicitly specify a different view
        [Route("[Action]")]
        public ViewResult ExplicitView()
        {
            //return View();
            return View("ExplicitViewTwo");
        }

    }
}
