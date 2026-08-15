
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAwayFromHome.Models;
using HomeAwayFromHome.Data;

public class PropertiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public PropertiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PROPERTYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Property.ToListAsync());
    }

    // GET: PROPERTYS/Details/5
    public async Task<IActionResult> Details(int? propertyid)
    {
        if (propertyid == null)
        {
            return NotFound();
        }

        var property = await _context.Property
            .FirstOrDefaultAsync(m => m.PropertyID == propertyid);
        if (property == null)
        {
            return NotFound();
        }

        return View(property);
    }

    // GET: PROPERTYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROPERTYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PropertyID,PropertyName,Description,Address,MaximumGuests,Bedrooms,Bathrooms,PricePerNight,Bookings,Availabilities,PropertyAmenities,FinancialTransactions")] Property property)
    {
        if (ModelState.IsValid)
        {
            _context.Add(property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(property);
    }

    // GET: PROPERTYS/Edit/5
    public async Task<IActionResult> Edit(int? propertyid)
    {
        if (propertyid == null)
        {
            return NotFound();
        }

        var property = await _context.Property.FindAsync(propertyid);
        if (property == null)
        {
            return NotFound();
        }
        return View(property);
    }

    // POST: PROPERTYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? propertyid, [Bind("PropertyID,PropertyName,Description,Address,MaximumGuests,Bedrooms,Bathrooms,PricePerNight,Bookings,Availabilities,PropertyAmenities,FinancialTransactions")] Property property)
    {
        if (propertyid != property.PropertyID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(property);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(property.PropertyID))
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
        return View(property);
    }

    // GET: PROPERTYS/Delete/5
    public async Task<IActionResult> Delete(int? propertyid)
    {
        if (propertyid == null)
        {
            return NotFound();
        }

        var property = await _context.Property
            .FirstOrDefaultAsync(m => m.PropertyID == propertyid);
        if (property == null)
        {
            return NotFound();
        }

        return View(property);
    }

    // POST: PROPERTYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? propertyid)
    {
        var property = await _context.Property.FindAsync(propertyid);
        if (property != null)
        {
            _context.Property.Remove(property);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PropertyExists(int? propertyid)
    {
        return _context.Property.Any(e => e.PropertyID == propertyid);
    }
}
