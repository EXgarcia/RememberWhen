using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using RememberWhen.Models;
using RememberWhen.Models.DTO;
using RememberWhen.Properties.Services;

namespace RememberWhen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
        //login
        [HttpPost]
        [Route("Login")]

        public IActionResult Login([FromBody]LoginDTO User)
        {
            return _data.Login(User);
        }
        //add a user
        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }
        //update user account
        // [HttpPost]
        // [Route("UpdateUser")]
        // public bool UpdateUser(UserModel userToUpdate)
        // {
        //     return _data.UpdateUser(userToUpdate);
        // }

        [HttpPost]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }

        //delete user account
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]

        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

         [HttpGet]
        [Route("userbyusername/{username}")]
        public UserIdDTO GetUserIdDTOByUsername(string username){
            return _data.GetUserIdDTOByUsername(username);
        }
        
    }
}