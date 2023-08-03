using Dept_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dept_Web_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
