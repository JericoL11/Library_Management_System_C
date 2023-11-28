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
    public class Category_BookController : Controller
    {
        private readonly Library_Management_System_CContext _context;

        public Category_BookController(Library_Management_System_CContext context)
        {
            _context = context;
        }

        // GET: Category_Book
        public async Task<IActionResult> Index()
        {
              return _context.Category_Book != null ? 
                          View(await _context.Category_Book.ToListAsync()) :
                          Problem("Entity set 'Library_Management_System_CContext.Category_Book'  is null.");
        }

        // GET: Category_Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Category_Book == null)
            {
                return NotFound();
            }

            var category_Book = await _context.Category_Book
                .FirstOrDefaultAsync(m => m.categoryId == id);
            if (category_Book == null)
            {
                return NotFound();
            }

            return View(category_Book);
        }

        // GET: Category_Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category_Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("categoryId,categoryName")] Category_Book category_Book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category_Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category_Book);
        }

        // GET: Category_Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Category_Book == null)
            {
                return NotFound();
            }

            var category_Book = await _context.Category_Book.FindAsync(id);
            if (category_Book == null)
            {
                return NotFound();
            }
            return View(category_Book);
        }

        // POST: Category_Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("categoryId,categoryName")] Category_Book category_Book)
        {
            if (id != category_Book.categoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category_Book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category_BookExists(category_Book.categoryId))
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
            return View(category_Book);
        }

        // GET: Category_Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Category_Book == null)
            {
                return NotFound();
            }

            var category_Book = await _context.Category_Book
                .FirstOrDefaultAsync(m => m.categoryId == id);
            if (category_Book == null)
            {
                return NotFound();
            }

            return View(category_Book);
        }

        // POST: Category_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Category_Book == null)
            {
                return Problem("Entity set 'Library_Management_System_CContext.Category_Book'  is null.");
            }
            var category_Book = await _context.Category_Book.FindAsync(id);
            if (category_Book != null)
            {
                _context.Category_Book.Remove(category_Book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category_BookExists(int id)
        {
          return (_context.Category_Book?.Any(e => e.categoryId == id)).GetValueOrDefault();
        }
    }
}
