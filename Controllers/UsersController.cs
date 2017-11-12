using System.Collections.Generic;
using InstadateRestApi.Data;
using InstadateRestApi.Models;
using Microsoft.AspNetCore.Mvc;

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
            User user = new User { QbId = id, Portrait = "/portaits/"+id.ToString()+".jpg" };
            _context.User.Add(user);
            _context.SaveChanges();
            return "user";
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
