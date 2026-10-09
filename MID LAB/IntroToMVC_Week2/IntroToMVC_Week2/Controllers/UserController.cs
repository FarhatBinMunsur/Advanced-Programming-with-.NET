using Microsoft.AspNetCore.Mvc;
using IntroToMVC_Week2.Models;
 
namespace IntroToMVC_Week2.Controllers
{
    //[Route("users")]   
    public class UserController : Controller
    {
        //[Route("userlist")]

        User[] users;
        public IActionResult Index()
        {
            users = new User[5];

            for (int i = 0; i < 5; i++)
            {
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

        //[Route("details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.id = id;
            ViewBag.Name = "Person" + id;
            ViewBag.address = "Kuril";
            ViewBag.email = "person" + id + "@gmail.com";
            ViewBag.phone = "010101001010";

            return View();


        }

        public IActionResult test()

        {

            /*IF WE DONT USE THE CONTROLLER INHERITANCE
                        *******************
            var content = new ContentResult();
            content.Content = "This is a page to test return type (Didnt use Controller inheritance)";
            return content;
                        *******************
             */
            
            //IF WE USE THE CONTROLLER INHERITANCE
            return Content("This is a page to test return type");
        }
    }
}
