using Microsoft.EntityFrameworkCore;

namespace Shitmaps.Data  // This namespace must match the one in your Program.cs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<BathroomExperience> BathroomExperiences { get; set; }
    }

    // Model for BathroomExperience (data you're storing in the database)
    public class BathroomExperience
    {
        public int Id { get; set; }
 public string? BusinessName { get; set; }  // Marked as nullable
    public string? ExperienceDetails { get; set; }  // Marked as nullable
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}