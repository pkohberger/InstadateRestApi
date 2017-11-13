using System.Collections.Generic;
using InstadateRestApi.Data;
using InstadateRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace InstadateRestApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly InstadateRestApiContext _context;

        public UsersController(InstadateRestApiContext context)
        {
            _context = context;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "user_1", "user_2" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "user";
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            if (user != null)
            {
                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    String message = ex.Message;
                }
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
