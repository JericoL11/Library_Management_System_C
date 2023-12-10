using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C.Data;
using Library_Management_System_C.Models;

namespace Library_Management_System_C.Controllers
{
    public class RecordsController : Controller
    {
        private readonly Library_Management_System_CContext _context;

        public RecordsController(Library_Management_System_CContext context)
        {
            _context = context;
        }

        // GET: Records
        public async Task<IActionResult> Index()
        {
            var library_Management_System_CContext = _context.Records.Include(r => r.FK_borrower).Include(r => r.FK_librarian);
            return View(await library_Management_System_CContext.ToListAsync());
        }

        // GET: Records/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Records == null)
            {
                return NotFound();
            }

            var records = await _context.Records
                .Include(r => r.FK_borrower)
                .Include(r => r.FK_librarian)
                .FirstOrDefaultAsync(m => m.record_id == id);
            if (records == null)
            {
                return NotFound();
            }

            return View(records);
        }

        // GET: Records/Create
        public IActionResult Create()
        {
            ViewData["borrowerId"] = new SelectList(_context.Borrower, "borrowerId", "borrowerId");


            // Fetching data from your database context
            var data = _context.User.Select(x => new {
                CombinedValue = x.FirstName + " " + x.LastName,
                Id = x.id // Assuming you have an Id property or some unique identifier
            }).ToList();
                
            // Creating a SelectList
            ViewData["librarianId"] = new SelectList(data, "Id", "CombinedValue");

    
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("record_id,borrowerId,due_date,librarianId,transac_date")] Records records)
        {
            if (ModelState.IsValid)
            {
                _context.Add(records);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["borrowerId"] = new SelectList(_context.Borrower, "borrowerId", "borrower_Course", records.borrowerId);
            ViewData["librarianId"] = new SelectList(_context.User, "id", "FirstName", records.librarianId);
            return View(records);
        }

        // GET: Records/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Records == null)
            {
                return NotFound();
            }

            var records = await _context.Records.FindAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            ViewData["borrowerId"] = new SelectList(_context.Borrower, "borrowerId", "borrower_Course", records.borrowerId);
            ViewData["librarianId"] = new SelectList(_context.User, "id", "FirstName", records.librarianId);
            return View(records);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("record_id,borrowerId,due_date,librarianId,transac_date")] Records records)
        {
            if (id != records.record_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(records);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordsExists(records.record_id))
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
            ViewData["borrowerId"] = new SelectList(_context.Borrower, "borrowerId", "borrower_Course", records.borrowerId);
            ViewData["librarianId"] = new SelectList(_context.User, "id", "FirstName", records.librarianId);
            return View(records);
        }

        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Records == null)
            {
                return NotFound();
            }

            var records = await _context.Records
                .Include(r => r.FK_borrower)
                .Include(r => r.FK_librarian)
                .FirstOrDefaultAsync(m => m.record_id == id);
            if (records == null)
            {
                return NotFound();
            }

            return View(records);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Records == null)
            {
                return Problem("Entity set 'Library_Management_System_CContext.Records'  is null.");
            }
            var records = await _context.Records.FindAsync(id);
            if (records != null)
            {
                _context.Records.Remove(records);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordsExists(int id)
        {
          return (_context.Records?.Any(e => e.record_id == id)).GetValueOrDefault();
        }
    }
}
