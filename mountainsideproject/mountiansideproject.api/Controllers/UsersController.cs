using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Api.DAL;
using TestProj.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _AppDBContext;
        public UsersController (AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = _AppDBContext.Users.ToList();
            if (users != null)
            {
                return StatusCode(StatusCodes.Status200OK, users);
            }
            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _AppDBContext.Users.Find(id);
            if (user != null)
            {
                return StatusCode(StatusCodes.Status200OK, user);
            }
            return StatusCode(StatusCodes.Status404NotFound, null);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid data");
            }

            _AppDBContext.Add<User>(user);
            _AppDBContext.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var entity = _AppDBContext.Users.FirstOrDefault(e => e.UserId == id);
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.UserRoutes = user.UserRoutes;

            _AppDBContext.SaveChanges();

            return StatusCode(StatusCodes.Status202Accepted);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var entity = _AppDBContext.Users.FirstOrDefault(e => e.UserId == id);
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            _AppDBContext.Remove(entity);
            _AppDBContext.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}