using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProj.Api.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual List<UserRoute> UserRoutes { get; set; }
    }
    public class UserRoute
    {
        public int UserRouteId { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public bool Completed { get; set; }
        public string Notes { get; set; }
        public virtual User User { get; set; }
    }
}
