using Microsoft.EntityFrameworkCore;

namespace Olydispay_api_backend.Models
{
    public class OlydispayApiContext : DbContext
    {
        public OlydispayApiContext(DbContextOptions<OlydispayApiContext> options) : base (options) 
        {
            
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<GradeHistory> gradeHistories { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
