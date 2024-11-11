using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shitmaps.Models;
using Microsoft.EntityFrameworkCore;
namespace BathroomExperiencesController;
public class BathroomExperiencesController : Controller
{
    private readonly ShitmapsContext _context;

    public BathroomExperiencesController(ShitmapsContext context)
    {
        _context = context;
    }

    // GET: BathroomExperiences
    public async Task<IActionResult> Index()
    {
        return View(await _context.BathroomExperiences.ToListAsync());
    }

    // POST: BathroomExperiences/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LocationName,Description,Rating,Latitude,Longitude")] BathroomExperience bathroomExperience)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bathroomExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bathroomExperience);
    }
}