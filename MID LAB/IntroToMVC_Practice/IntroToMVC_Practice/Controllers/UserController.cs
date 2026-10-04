using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_practice.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [Route("home")]
        public IActionResult Index()
        {
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

        [Route("view/{id}")]
        public  IActionResult Details(int id)
        {
            var user =new Models.UserModel()
            {
                id=id,
                name="Farhat",
                email="farhat@gm.com"
            };
            return View(user);
        }
    }
}
