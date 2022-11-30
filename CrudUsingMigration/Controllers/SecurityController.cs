using CrudUsingMigration.Data;
using CrudUsingMigration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudUsingMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IJwtSecurity _jwtSecurity;

        public SecurityController(IJwtSecurity jwtSecurity)
        {
            this._jwtSecurity = jwtSecurity;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Login usersdata)
        {
            var token = _jwtSecurity.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
       
       
    }
}
