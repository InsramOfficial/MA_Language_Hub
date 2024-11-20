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
    }
}
