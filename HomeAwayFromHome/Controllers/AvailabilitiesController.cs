
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAwayFromHome.Models;
using HomeAwayFromHome.Data;

public class AvailabilitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public AvailabilitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: AVAILABILITYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Availability.ToListAsync());
    }

    // GET: AVAILABILITYS/Details/5
    public async Task<IActionResult> Details(int? availabilityid)
    {
        if (availabilityid == null)
        {
            return NotFound();
        }

        var availability = await _context.Availability
            .FirstOrDefaultAsync(m => m.AvailabilityID == availabilityid);
        if (availability == null)
        {
            return NotFound();
        }

        return View(availability);
    }

    // GET: AVAILABILITYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AVAILABILITYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AvailabilityID,PropertyID,Property,AvailableFrom,AvailableTo,Status")] Availability availability)
    {
        if (ModelState.IsValid)
        {
            _context.Add(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(availability);
    }

    // GET: AVAILABILITYS/Edit/5
    public async Task<IActionResult> Edit(int? availabilityid)
    {
        if (availabilityid == null)
        {
            return NotFound();
        }

        var availability = await _context.Availability.FindAsync(availabilityid);
        if (availability == null)
        {
            return NotFound();
        }
        return View(availability);
    }

    // POST: AVAILABILITYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? availabilityid, [Bind("AvailabilityID,PropertyID,Property,AvailableFrom,AvailableTo,Status")] Availability availability)
    {
        if (availabilityid != availability.AvailabilityID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(availability);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(availability.AvailabilityID))
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
        return View(availability);
    }

    // GET: AVAILABILITYS/Delete/5
    public async Task<IActionResult> Delete(int? availabilityid)
    {
        if (availabilityid == null)
        {
            return NotFound();
        }

        var availability = await _context.Availability
            .FirstOrDefaultAsync(m => m.AvailabilityID == availabilityid);
        if (availability == null)
        {
            return NotFound();
        }

        return View(availability);
    }

    // POST: AVAILABILITYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? availabilityid)
    {
        var availability = await _context.Availability.FindAsync(availabilityid);
        if (availability != null)
        {
            _context.Availability.Remove(availability);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AvailabilityExists(int? availabilityid)
    {
        return _context.Availability.Any(e => e.AvailabilityID == availabilityid);
    }
}
