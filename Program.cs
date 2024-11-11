using Microsoft.EntityFrameworkCore;
using Shitmaps.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext to interact with the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other necessary services, such as for authentication or logging if needed
// builder.Services.AddAuthentication() // Add authentication if needed
// builder.Services.AddLogging() // Add logging if needed

// Create the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Serve static files, including the map (Leaflet.js assets)
app.UseStaticFiles();

// Use routing for Razor Pages or MVC
app.UseRouting();

// Map the default page, like a home page or Map page
app.MapRazorPages();

// Example: If you have custom endpoints
app.MapGet("/api/experiences", async (ApplicationDbContext db) =>
{
    return Results.Ok(await db.BathroomExperiences.ToListAsync());
});

// Run the application
app.Run();