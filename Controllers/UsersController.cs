using System.Collections.Generic;
using InstadateRestApi.Data;
using InstadateRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

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
        public void Post()
        {
            /**
             * Convert Post Keys to Dictionary
             */
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (string f in Request.Form.Keys)
            {
                form.Add(f, Request.Form[f]);
            }

            /**
             * @Todo Add More Validation
             * @Author Phil Kohberger
             * Simple validation
             */
            if (form.Count < 6 || Request.Form.Files.Count <= 0)
            {
                throw new ValidationException("There is missing form data.");
            }

            /**
             * Create Baseline User
             */
            User user = new User();
            user.QbID = Convert.ToInt32(form["QbID"]);
            user.AccessToken = form["AccessToken"];
            user.Birthday = form["Birthday"];
            user.Title = form["Title"];
            user.About = form["About"];
            user.Location = form["Location"];
            user.FilePaths = new List<FilePath>();

            /**
             * Get image(s) from Post
             */
            if (Request.Form.Files.Count > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var file = Request.Form.Files[0];
                string fileExtension = Path.GetExtension(file.FileName);

                string pathOld = Path.Combine(
                    Directory.GetCurrentDirectory(), "Uploads",file.FileName);

                using (var stream = new FileStream(pathOld, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                string pathNew = Path.Combine(
                    Directory.GetCurrentDirectory(), "Uploads", fileName + fileExtension);

                System.IO.File.Move(pathOld, pathNew);


                user.FilePaths.Add(new FilePath
                {
                    FileName = fileName,
                    FileType = fileExtension
                });
            }

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
