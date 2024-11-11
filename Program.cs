using Microsoft.EntityFrameworkCore;
using Shitmaps.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext to interact with the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings_DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Build the app
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

app.UseStaticFiles();

// Use routing for MVC
app.UseRouting();

// Set up default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Use environment variable for dynamic port binding
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000"; // Default to 5000 if not set
app.Run($"http://0.0.0.0:{port}");
