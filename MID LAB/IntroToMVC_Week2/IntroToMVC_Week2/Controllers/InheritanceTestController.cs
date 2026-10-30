using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_Week2.Controllers
{
    [Route("Inhtest")]
    public class InheritanceTestController 
    {
    

        [Route("test")]
        public IActionResult test()

        {

            //UserController class inherits Controller class. IF WE DONT USE THE CONTROLLER INHERITANCE

            var content = new ContentResult();
            content.Content = "This is a page to test return type (Didnt use Controller inheritance)";
            return content;



            //IF WE USE THE CONTROLLER INHERITANCE
            //return Content("This is a page to test return type");
        }
    }
}
