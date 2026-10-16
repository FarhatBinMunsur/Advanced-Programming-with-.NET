using Microsoft.AspNetCore.Mvc;

namespace Designing_JHL_2.Controllers
{
    public class DesignController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [Route("exc")]
        public IActionResult DataExchange()
        {

            return View(5);
        }

        public IActionResult checkData(int id)
        {
            switch (id)
            {
                case 1:
                    return View(5); //int data
                case 2:
                    return View(5.10);  //double data
                case 3:
                    return View("checkdata","Farhat mahir");     //string data
                case 4:
                    return View(new { name = "Mahir", ID = 10 });      //anonymous object
            }
            return View();
        }

        [Route("subjects/{cid?}")]
        public IActionResult TagHelper(int cid)
        {
            ViewBag.cid = cid;
            return View();
        }

        public IActionResult SubjectList() { 
            return View();
        }

    }
}
