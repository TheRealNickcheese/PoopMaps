public class BathroomExperience
{
    public int Id { get; set; }
 public string? LocationName { get; set; }  // Marked as nullable
    public string? Description { get; set; }   // Marked as nullable
    public int Rating { get; set; }  // Could be a value between 1-5
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}