using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sqlite_20220723.EFDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Region> Region { get; set; }
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoPath { get; set; }
    }

    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string RegionDescription { get; set; }
    }
}
