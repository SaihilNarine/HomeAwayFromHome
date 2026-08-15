
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAwayFromHome.Models;
using HomeAwayFromHome.Data;

public class FinancialTransactionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FinancialTransactionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: FINANCIALTRANSACTIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.FinancialTransaction.ToListAsync());
    }

    // GET: FINANCIALTRANSACTIONS/Details/5
    public async Task<IActionResult> Details(int? financialtransactionid)
    {
        if (financialtransactionid == null)
        {
            return NotFound();
        }

        var financialtransaction = await _context.FinancialTransaction
            .FirstOrDefaultAsync(m => m.FinancialTransactionID == financialtransactionid);
        if (financialtransaction == null)
        {
            return NotFound();
        }

        return View(financialtransaction);
    }

    // GET: FINANCIALTRANSACTIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FINANCIALTRANSACTIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FinancialTransactionID,PropertyID,Property,BookingID,Booking,TransactionType,Description,Amount,TransactionDate")] FinancialTransaction financialtransaction)
    {
        if (ModelState.IsValid)
        {
            _context.Add(financialtransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(financialtransaction);
    }

    // GET: FINANCIALTRANSACTIONS/Edit/5
    public async Task<IActionResult> Edit(int? financialtransactionid)
    {
        if (financialtransactionid == null)
        {
            return NotFound();
        }

        var financialtransaction = await _context.FinancialTransaction.FindAsync(financialtransactionid);
        if (financialtransaction == null)
        {
            return NotFound();
        }
        return View(financialtransaction);
    }

    // POST: FINANCIALTRANSACTIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? financialtransactionid, [Bind("FinancialTransactionID,PropertyID,Property,BookingID,Booking,TransactionType,Description,Amount,TransactionDate")] FinancialTransaction financialtransaction)
    {
        if (financialtransactionid != financialtransaction.FinancialTransactionID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(financialtransaction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialTransactionExists(financialtransaction.FinancialTransactionID))
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
        return View(financialtransaction);
    }

    // GET: FINANCIALTRANSACTIONS/Delete/5
    public async Task<IActionResult> Delete(int? financialtransactionid)
    {
        if (financialtransactionid == null)
        {
            return NotFound();
        }

        var financialtransaction = await _context.FinancialTransaction
            .FirstOrDefaultAsync(m => m.FinancialTransactionID == financialtransactionid);
        if (financialtransaction == null)
        {
            return NotFound();
        }

        return View(financialtransaction);
    }

    // POST: FINANCIALTRANSACTIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? financialtransactionid)
    {
        var financialtransaction = await _context.FinancialTransaction.FindAsync(financialtransactionid);
        if (financialtransaction != null)
        {
            _context.FinancialTransaction.Remove(financialtransaction);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FinancialTransactionExists(int? financialtransactionid)
    {
        return _context.FinancialTransaction.Any(e => e.FinancialTransactionID == financialtransactionid);
    }
}
