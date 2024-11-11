using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shitmaps.Pages
{
    public class MapModel : PageModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    public string? BusinessName { get; set; }  // Marked as nullable

        public void OnGet()
        {
            // Set default values for testing
            Latitude = 51.505;
            Longitude = -0.09;
            BusinessName = "Sample Business";
        }
    }
}