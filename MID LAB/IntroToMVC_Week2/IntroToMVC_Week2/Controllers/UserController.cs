using IntroToMVC_Week2.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_Week2.Controllers
{
    [Route("users")]
    //[Route("[controller]/[action]")]      /** if you want to work this ,comment out the othe routes **/
    public class UserController:Controller
    {
        //[Route("userlist")]

        User[] users;

        [Route("list")]
        public IActionResult Index(int id)
        {

            users = new User[5];

            for (int i = 0; i < 5; i++)
            {
                //var user = new User { id = i + 1, name = "Person" + (i + 1), address = "Kuril", email = "person" + (i + 1) + "@gmail.com", phone = "010101010101" };
                //users[i] = user;

                var user = new User();
                user.id = i + 1;
                user.name = "Person" + (i + 1);
                user.address = "Kuril";
                user.email = "person" + (i + 1) + "@gmail.com";
                user.phone = "010101010101";

                users[i] = user;
            }

            return View(users);
        }

        [Route("profile/details/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.id = id;
            ViewBag.Name = "Person" + id;
            ViewBag.address = "Kuril";
            ViewBag.email = "person" + id + "@gmail.com";
            ViewBag.phone = "010101001010";

            return View();


        }


        [Route("test2")]
        public IActionResult test2() => View();

        [Route("test3")]
        public IActionResult test3() => View("test2");

        [Route("student")]

        public IActionResult Student()
        {

            return View();
        }

        [Route("create")]
        [HttpGet]
        [HttpPost]
        public IActionResult Create(Student student)
        {

            if (ModelState.IsValid)     //ModelState.IsValid checks whether the inputted values follow the validation rules or not
            {
                return View("Result", student);
            }

            return View("Create");
        }
    }
}
