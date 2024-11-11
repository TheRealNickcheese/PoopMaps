using Microsoft.EntityFrameworkCore;

public class ShitmapsContext : DbContext
{
    public ShitmapsContext(DbContextOptions<ShitmapsContext> options) : base(options) { }

    public DbSet<BathroomExperience> BathroomExperiences { get; set; }
}