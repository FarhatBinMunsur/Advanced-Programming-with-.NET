using Microsoft.AspNetCore.Mvc;

namespace Routing_JHL_2.Controllers
{
    [Route("farhat")]
    public class RoutingController : Controller
    {
        [Route("First/{id?}")]
        public IActionResult Index(int id)
        {
            ViewBag.id= id;
            return View();
        }

        [Route("second/{p1:int?}/{p3:int:min(10)?}")]
        public IActionResult Twoparam(int p1,int p3)
        {
            var result = p1 + p3;
            return Content(result.ToString());

            //return Content(p1.ToString()+p3.ToString());
        }

        [Route("Testing")]
        [Route("mahir/Test")]
        public IActionResult TestName()
        {
            return Content("Farhat mahir");
        }

        //Ques-Ans
        [Route("getday/{year:min(1900):max(9999):length(4)}/{month:int:min(1):max(12)}/{day:int:min(1):max(31)}")]
        public IActionResult getdayofDate(int year,int month,int day)
        {
            return Content("The day of " + $"{day}/{month}/{year}" + " was: I dont know!");

        }
    }
}
