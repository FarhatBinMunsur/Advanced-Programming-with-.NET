using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_practice.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [Route("home/{id?}")]
        public IActionResult Index(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [Route("lists")]
        public IActionResult List()
        {
            return View();
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("view/{cid}")]
        public  IActionResult Details(int cid)
        {
            var user =new Models.UserModel()
            {
                id=cid,
                name="Farhat",
                email="farhat@gmail.com"
            };
            return View(user);
        }
    }
}
