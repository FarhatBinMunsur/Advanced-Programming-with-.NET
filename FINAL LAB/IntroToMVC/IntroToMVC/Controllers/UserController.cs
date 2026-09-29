using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {

            var user = new Models.UserModel()
            {
                id = id,
                name = "Farhat",
                email = "mahir@gmail.com",
                password = "1234"


            };
            return View(user);
        }

    }
}
