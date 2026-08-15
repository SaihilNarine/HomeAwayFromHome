
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAwayFromHome.Models;
using HomeAwayFromHome.Data;

public class ReviewsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReviewsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: REVIEWS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Review.ToListAsync());
    }

    // GET: REVIEWS/Details/5
    public async Task<IActionResult> Details(int? reviewid)
    {
        if (reviewid == null)
        {
            return NotFound();
        }

        var review = await _context.Review
            .FirstOrDefaultAsync(m => m.ReviewID == reviewid);
        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    // GET: REVIEWS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: REVIEWS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReviewID,UserID,User,BookingID,Booking,Rating,Comment,CreatedAt,Status")] Review review)
    {
        if (ModelState.IsValid)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(review);
    }

    // GET: REVIEWS/Edit/5
    public async Task<IActionResult> Edit(int? reviewid)
    {
        if (reviewid == null)
        {
            return NotFound();
        }

        var review = await _context.Review.FindAsync(reviewid);
        if (review == null)
        {
            return NotFound();
        }
        return View(review);
    }

    // POST: REVIEWS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? reviewid, [Bind("ReviewID,UserID,User,BookingID,Booking,Rating,Comment,CreatedAt,Status")] Review review)
    {
        if (reviewid != review.ReviewID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(review.ReviewID))
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
        return View(review);
    }

    // GET: REVIEWS/Delete/5
    public async Task<IActionResult> Delete(int? reviewid)
    {
        if (reviewid == null)
        {
            return NotFound();
        }

        var review = await _context.Review
            .FirstOrDefaultAsync(m => m.ReviewID == reviewid);
        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    // POST: REVIEWS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? reviewid)
    {
        var review = await _context.Review.FindAsync(reviewid);
        if (review != null)
        {
            _context.Review.Remove(review);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReviewExists(int? reviewid)
    {
        return _context.Review.Any(e => e.ReviewID == reviewid);
    }
}
