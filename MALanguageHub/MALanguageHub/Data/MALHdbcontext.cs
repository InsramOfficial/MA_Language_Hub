using MALanguageHub.Models;
using Microsoft.EntityFrameworkCore;

namespace MALanguageHub.Data
{
    public class MALHdbcontext : DbContext
    {
        public MALHdbcontext(DbContextOptions<MALHdbcontext> option) : base(option)
        {
            
        }
        public DbSet<Aboutus> tbl_aboutus { get; set; }
        public DbSet<Courses> tbl_courses { get; set; }
        public DbSet<Home> tbl_home { get; set; }
        public DbSet<Login> tbl_login { get; set; }
        public DbSet<OurProfessionals> tbl_ourprofessionals { get; set; }
        public DbSet<StudentReviews> tbl_studentreviews { get; set; }
        public DbSet<Contactus> tbl_contactus { get; set; }
    }
}
