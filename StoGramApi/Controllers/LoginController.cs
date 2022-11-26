using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoGramApi.Data;
using StoGramApi.Models;

namespace StoGramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IUserRepo userRepository;
        public LoginController(IUserRepo repo)
        {
            userRepository = repo;
        }
        
        [HttpPost("create")]
        public ActionResult<bool> Create(UserModel user)
        {
            var createdUser = userRepository.CreateUser(user.Login, user.Password);
            return Ok(createdUser);
        }

        [HttpPost]
        public ActionResult<bool> Login(UserModel user)
        {
            var loggedUser = userRepository.LogInUser(user.Login, user.Password);
            return Ok(loggedUser);
        }
    }
}
