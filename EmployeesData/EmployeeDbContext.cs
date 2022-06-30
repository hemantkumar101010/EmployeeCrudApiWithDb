
using EmployeesData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesData
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }


        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions options)
       : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Database=CrudWebApiDb;Trusted_Connection=True");


        }
    }
}
