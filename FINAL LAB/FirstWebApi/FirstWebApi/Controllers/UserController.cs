using FirstWebApi.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Azure.Messaging;
using FirstWebApi.Guard;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext context;

        public UserController(UserDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [HttpGet("fetchusers")]
        [SessionAuthorizer]
        public IActionResult GetUsers()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return Ok();
        }


        //insert more than 1 user at a time

        [HttpPost("manyuser")]
        public IActionResult CreateUser(List<User> user)
        {
            foreach (var u in user)
            {
                context.Users.Add(u);
                
            }
            context.SaveChanges();


            return Ok();
        }



        [HttpPatch("{id}")]         //in postman, url is {{base_url}}/api/user?/07ad6a03-12ea-4f4c-ca2a-08df48b5c0c1
        public IActionResult UpdateUser(Guid id,User user)
        {
            var targetUser = context.Users.Find(id);

            if (targetUser == null)
            {
                return NotFound();
            }
            targetUser.Id=user.Id;
            targetUser.Name= user.Name;
            targetUser.Email= user.Email;
            targetUser.Password= user.Password;
            targetUser.role=user.role;

            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid id) {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            context.SaveChanges();

            return Ok(new { successMessage="Success"});
        }


        //Login functionality

        [HttpPost("login")]
        
        public IActionResult Login(User user)
        {
            var authUser=context.Users.FirstOrDefault(u=>u.Email==user.Email && u.Password==user.Password);
            
            if(authUser == null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            HttpContext.Session.SetString("Email",authUser.Email);
            return Ok("Login Successful");
        }

    }
}
