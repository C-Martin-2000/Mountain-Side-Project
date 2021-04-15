using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestProj.Api.DAL;
using TestProj.Api.Models;

namespace mountiansideproject.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoutesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserRoutesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/<UserRoutesController>
        [HttpGet("{id}")]
        public IActionResult getUserRoutes(int id)
        {
            List<UserRoute> routes = _context.UserRoutes.Where(x => x.UserId == id).ToList();
            if (routes != null)
            {
                return StatusCode(StatusCodes.Status200OK, routes);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        // POST api/<UserRoutesController
        [HttpPost]
        public IActionResult Post([FromBody] UserRoute route) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            _context.Add<UserRoute>(route);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // PUT api/<UserRoutesController>
        [HttpPut]
        public IActionResult Put(int id, [FromBody] UserRoute route)
        {
            var entity = _context.UserRoutes.FirstOrDefault(e => e.UserRouteId == id);
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            entity.Completed = route.Completed;
            entity.Notes = route.Notes;

            _context.SaveChanges();

            return StatusCode(StatusCodes.Status202Accepted);
        }

        // DELETE api/<UserRoutesController>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.UserRoutes.FirstOrDefault(e => e.UserRouteId == id);
            if(entity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);

        }
    }
}
