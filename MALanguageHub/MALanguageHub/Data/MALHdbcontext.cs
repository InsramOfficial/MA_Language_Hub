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
        public DbSet<Settings> tbl_settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding data for Aboutus table
            modelBuilder.Entity<Aboutus>().HasData(
                new Aboutus { Id = 1,Title = "Software",Description = "Software Engineer"}
            );

            // Seeding data for Courses table
            modelBuilder.Entity<Courses>().HasData(
                new Courses { Id = 1, Title = "Course 1", Description = "Description for Course 1",Duration = "2 Month",StartingDate = DateTime.Now,AllocatedTeacher = 1,Status = "Available"},
                new Courses { Id = 2, Title = "Course 2", Description = "Description for Course 2",Duration = "2 Month", StartingDate = DateTime.Now, AllocatedTeacher = 1, Status = "Available" }
            );

            // Seeding data for Home table
            modelBuilder.Entity<Home>().HasData(
                new Home { Id = 1,Title = "Software Engineer",Description = "I am Software Engineer"},
                new Home { Id = 2,Title = "Civil Engineer",Description = "I am Civil Engineer"}
            );

            // Seeding data for Login table
            modelBuilder.Entity<Login>().HasData(
                new Login { Id = 1, Username = "admin", Password = "admin",FullName = "Muhammad Naseer" } // Use hashed passwords in production!
            );

            // Seeding data for OurProfessionals table
            modelBuilder.Entity<OurProfessionals>().HasData(
                new OurProfessionals { Id = 1, Title = "Muhammad Naseer",Description = "I am a BS Computer Science student",FacebookLink = "https://www.facebook.com/muhammad.naseer039",InstagramLink = "https://www.facebook.com/muhammad.naseer039", WhatsAppLink = "https://www.facebook.com/muhammad.naseer039",LinkedInLink = "https://www.facebook.com/muhammad.naseer039" },
                new OurProfessionals { Id = 2, Title = "Muhammad Insram",Description = "I am a BS Information student",FacebookLink = "https://www.facebook.com/muhammad.naseer039",InstagramLink = "https://www.facebook.com/muhammad.naseer039", WhatsAppLink = "https://www.facebook.com/muhammad.naseer039",LinkedInLink = "https://www.facebook.com/muhammad.naseer039" },
                new OurProfessionals { Id = 3, Title = "Muhammad Sultan",Description = "I am a BS Mathematics student",FacebookLink = "https://www.facebook.com/muhammad.naseer039",InstagramLink = "https://www.facebook.com/muhammad.naseer039", WhatsAppLink = "https://www.facebook.com/muhammad.naseer039", LinkedInLink = "https://www.facebook.com/muhammad.naseer039" },
                new OurProfessionals { Id = 4, Title = "Muhammad Ali",Description = "I am a BS English student",FacebookLink = "https://www.facebook.com/muhammad.naseer039",InstagramLink = "https://www.facebook.com/muhammad.naseer039", WhatsAppLink = "https://www.facebook.com/muhammad.naseer039",LinkedInLink = "https://www.facebook.com/muhammad.naseer039" }
            );

            // Seeding data for StudentReviews table
            modelBuilder.Entity<StudentReviews>().HasData(
                new StudentReviews { Id = 1,Name = "Insram",Designation = "Student", Review = "Great learning experience!"},
                new StudentReviews { Id = 2,Name = "Naseer",Designation = "Student", Review = "Great learning experience!"},
                new StudentReviews { Id = 3,Name = "Sultan",Designation = "Student", Review = "Great learning experience!"},
                new StudentReviews { Id = 4,Name = "Ali",Designation = "Student", Review = "Great learning experience!"}
            );

            // Seeding data for Contactus table
            modelBuilder.Entity<Contactus>().HasData(
                new Contactus { Id = 1, Address1 = "Kotli Azad Kashmir", Address2 = "Islamabad Pakistan", EmailAddress1 = "info@gmail.com", EmailAddress2 = "contact@malanguagehub.com",PhoneNumber = "923425464039",WhatsappNumber = "923425464039", Facebook = "https://www.facebook.com/muhammad.naseer039", TikTok = "https://www.facebook.com/muhammad.naseer039", Instagram = "https://www.facebook.com/muhammad.naseer039" }
            );
            modelBuilder.Entity<Settings>().HasData(
                new Settings {Id = 1,Name = "MALanguageHub" }
                );
        }
    }
}
