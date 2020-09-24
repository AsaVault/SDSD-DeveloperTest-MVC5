using System.Data.Entity;

namespace SDSD_DeveloperTest_MVC5.Models
{
    public class DeveloperTestDbContext: DbContext
    {
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserUpload> UserUpload { get; set; }
    }
}