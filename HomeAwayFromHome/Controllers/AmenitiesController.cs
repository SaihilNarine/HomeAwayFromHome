
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAwayFromHome.Models;
using HomeAwayFromHome.Data;

public class AmenitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public AmenitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: AMENITYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Amenity.ToListAsync());
    }

    // GET: AMENITYS/Details/5
    public async Task<IActionResult> Details(int? amenityid)
    {
        if (amenityid == null)
        {
            return NotFound();
        }

        var amenity = await _context.Amenity
            .FirstOrDefaultAsync(m => m.AmenityID == amenityid);
        if (amenity == null)
        {
            return NotFound();
        }

        return View(amenity);
    }

    // GET: AMENITYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AMENITYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AmenityID,Name,Description,PropertyAmenities")] Amenity amenity)
    {
        if (ModelState.IsValid)
        {
            _context.Add(amenity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(amenity);
    }

    // GET: AMENITYS/Edit/5
    public async Task<IActionResult> Edit(int? amenityid)
    {
        if (amenityid == null)
        {
            return NotFound();
        }

        var amenity = await _context.Amenity.FindAsync(amenityid);
        if (amenity == null)
        {
            return NotFound();
        }
        return View(amenity);
    }

    // POST: AMENITYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? amenityid, [Bind("AmenityID,Name,Description,PropertyAmenities")] Amenity amenity)
    {
        if (amenityid != amenity.AmenityID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(amenity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(amenity.AmenityID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(amenity);
    }

    // GET: AMENITYS/Delete/5
    public async Task<IActionResult> Delete(int? amenityid)
    {
        if (amenityid == null)
        {
            return NotFound();
        }

        var amenity = await _context.Amenity
            .FirstOrDefaultAsync(m => m.AmenityID == amenityid);
        if (amenity == null)
        {
            return NotFound();
        }

        return View(amenity);
    }

    // POST: AMENITYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? amenityid)
    {
        var amenity = await _context.Amenity.FindAsync(amenityid);
        if (amenity != null)
        {
            _context.Amenity.Remove(amenity);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AmenityExists(int? amenityid)
    {
        return _context.Amenity.Any(e => e.AmenityID == amenityid);
    }
}
