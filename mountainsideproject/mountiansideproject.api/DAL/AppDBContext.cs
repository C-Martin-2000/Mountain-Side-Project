using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Api.Models;

namespace TestProj.Api.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {
        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoute> UserRoutes { get; set; }
    }
}
