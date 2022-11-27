using Microsoft.EntityFrameworkCore;
using Zadanie3_1.Models;

namespace Zadanie3_1.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }



    }

   
}
