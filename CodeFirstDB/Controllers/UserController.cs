using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService user)
        {
            userService = user;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/User/GetUser")]
        public IEnumerable<User> GetUser()
        {
            return userService.GetUser();
        }



        [HttpPost]
        [Route("[action]")]
        [Route("api/User/AddUser")]

        public User AddUser(User user)
        {
            return userService.AddUser(user);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/User/UpdateUser")]

        public User UpdateUser(User user)
        {
            return userService.UpdateUser(user);
        }
    }
}
