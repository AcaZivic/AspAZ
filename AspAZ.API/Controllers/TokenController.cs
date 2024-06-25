using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspAZ.Api.Core;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager manager;

        public TokenController(JwtManager manager)
        {
            this.manager = manager;
        }

        // POST api/<TokenController>
        [HttpPost]
        //[FromBody] request.Username, request.Password
        //LoginRequest request
        public IActionResult Post()
        {
            //request.Username, request.Password
            var token = manager.MakeToken();

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
