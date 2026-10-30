using Microsoft.AspNetCore.Mvc;
using IntroToMVC.Models;

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

            var user = new UserModel()
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
