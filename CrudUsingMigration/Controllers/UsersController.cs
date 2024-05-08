using CrudUsingMigration.Context;
using CrudUsingMigration.Data;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudUsingMigration.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly MainContext _mainContext;

        private IUserDetails _userRepository;

        public UsersController(IUserDetails userdetails, MainContext context)
        {
            _userRepository = userdetails;
            _mainContext = context;
        }
      
        [HttpPost]
        [Route("RegisterUserDetails")]
        public async Task<ActionResult> UserdetailsPosta([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                await _userRepository.UserdetailsPost(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
       
        [HttpGet]
        [Route("GetUserList")]
        
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            var UserList = await _userRepository.GetUserList();
            if (UserList == null)
            {
                throw new ArgumentNullException(nameof(UserList));
            }
            return Ok(UserList);
        }
    }
}
