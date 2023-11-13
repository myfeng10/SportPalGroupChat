// GetUserGroups,GetUserName,GetUserId,
// not used: AddUser,GetUser
using GroupChat7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupChat7.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly GroupChatContext _context;

        public UserController(GroupChatContext context)
        {
            _context = context;
        }

        

      

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] string userName)
        {
            // check if user exists
            var existingUser = _context.User.FirstOrDefault(u => u.Username == userName);

            if (existingUser != null)
            {
                return Ok("user already exists");
            }
            else
            {
                var newUser = new User { Username = userName };
                _context.User.Add(newUser);
                _context.SaveChanges();
                return Ok("User added succesfully");
            }
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.User.ToList();
            return Ok(users);
        }
    }
}
