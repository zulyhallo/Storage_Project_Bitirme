using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Authentication.Models;
using Authentication.Authentication;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly List<Members> lstMember = new List<Members>()
        {
            new Members{Id=1, Name="Zeynep", Role="admin" },
            new Members {Id=2, Name="Fatih",Role="üye"},
            new Members{Id=3, Name="Ayşe",Role="üye"}
        };
        public MemberController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<Members> AllMembers()
        {
            return lstMember;
        }


        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public Members MemberByid(int id)
        {
            return lstMember.Find(x => x.Id == id);
        }

        [AllowAnonymous]
        // POST api/<MemberController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }


        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
